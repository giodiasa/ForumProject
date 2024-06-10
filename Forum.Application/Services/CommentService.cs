using AutoMapper;
using Forum.Application.DTOs;
using Forum.Application.Interfaces;
using Forum.Core.Common.Enums;
using Forum.Core.Common.Exceptions;
using Forum.Core.Entities;
using Forum.Core.Interfaces;

namespace Forum.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        private readonly ITopicRepository _topicRepository;

        public CommentService(ICommentRepository commentRepository, IAuthService authService, ITopicRepository topicRepository)
        {
            _commentRepository = commentRepository;
            _mapper = MappingInitializer.Initialize();
            _authService = authService;
            _topicRepository = topicRepository;
        }
        public async Task AddCommentAsync(CommentForCreatingDTO model)
        {
            var topic = await _topicRepository.GetSingleTopicAsync(x=> x.Id == model.TopicId);
            if (topic == null) { throw new TopicNotFoundException(); }
            if(topic.Status == Status.Inactive)
            {
                throw new UnauthorizedAccessException("Cant comment on inactive topic");
            }
            if (model == null) throw new ArgumentNullException("Invalid argument passed");
            var result = _mapper.Map<Comment>(model);
            result.CreationDate = DateTime.Now;
            result.UserId = _authService.GetAuthenticatedUserId();
            await _commentRepository.AddCommentAsync(result);
            await _commentRepository.Save();
        }

        public async Task DeleteCommentAsync(int Id)
        {
            if (Id <= 0) throw new ArgumentOutOfRangeException("Invalid argument passed");
            var comment = await _commentRepository.GetSingleCommentAsync(x => x.Id == Id);
            if (comment == null) throw new CommentNotFoundException();
            if (comment.UserId != _authService.GetAuthenticatedUserId() && _authService.GetAuthenticatedUserRole() != "Admin")
            {
                throw new UnauthorizedAccessException("Cant delete other users comments");
            }
            else
            {
                _commentRepository.DeleteComment(comment);
                await _commentRepository.Save();
            }
        }

        public async Task<List<CommentForGettingDTO>> GetAllCommentsOfTopicAsync(int topicId)
        {
            if (topicId <= 0) throw new ArgumentOutOfRangeException("Invalid argument passed");
            var topic = await _topicRepository.GetSingleTopicAsync(x => x.Id == topicId);
            if (topic == null) throw new TopicNotFoundException();
            var comments = await _commentRepository.GetAllCommentsAsync(x => x.TopicId == topicId);
            var result = _mapper.Map<List<CommentForGettingDTO>>(comments);
            return result;
        }

        public async Task<CommentForGettingDTO> GetSingleCommentAsync(int Id)
        {
            if (Id <= 0) throw new ArgumentOutOfRangeException("Invalid argument passed");
            var comment = await _commentRepository.GetSingleCommentAsync(x => x.Id == Id);
            if (comment == null) throw new CommentNotFoundException();
            if (comment.UserId != _authService.GetAuthenticatedUserId() && _authService.GetAuthenticatedUserRole() != "Admin")
            {
                throw new UnauthorizedAccessException("Cant view other users comment details");
            }
            var result = _mapper.Map<CommentForGettingDTO>(comment);
            return result;

        }

        public async Task UpdateCommentAsync(CommentForUpdatingDTO model)
        {
            if (model == null) throw new ArgumentNullException("Invalid argument passed");
            var commentToUpdate = await _commentRepository.GetSingleCommentAsync(x => x.Id == model.Id);
            if (commentToUpdate == null) throw new CommentNotFoundException();
            if (commentToUpdate.UserId != _authService.GetAuthenticatedUserId() && _authService.GetAuthenticatedUserRole() != "Admin")
            {
                throw new UnauthorizedAccessException("Cant update other users comments");
            }
            var result = _mapper.Map<Comment>(model);
            result.UserId = commentToUpdate.UserId;
            result.TopicId = commentToUpdate.TopicId;
            result.CreationDate = commentToUpdate.CreationDate;
            await _commentRepository.UpdateCommentAsync(result);
            await _commentRepository.Save();
        }
    }
}
