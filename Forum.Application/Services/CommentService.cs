using AutoMapper;
using Forum.Application.DTOs;
using Forum.Application.Interfaces;
using Forum.Core.Common.Exceptions;
using Forum.Core.Entities;
using Forum.Core.Interfaces;
using System.Linq.Expressions;

namespace Forum.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public CommentService(ICommentRepository commentRepository, IAuthService authService)
        {
            _commentRepository = commentRepository;
            _mapper = MappingInitializer.Initialize();
            _authService = authService;
        }
        public async Task AddCommentAsync(CommentForCreatingDTO model)
        {
            if (model == null) throw new ArgumentNullException("Invalid argument passed");
            if(model.UserId != _authService.GetAuthenticatedUserId())
            {
                throw new UnauthorizedAccessException("User is not authorized to add comment for another user.");
            }
            var result = _mapper.Map<Comment>(model);
            await _commentRepository.AddCommentAsync(result);
            await _commentRepository.Save();
        }

        public async Task DeleteCommentAsync(int Id)
        {
            if(Id <= 0) throw new ArgumentOutOfRangeException("Invalid argument passed");
            var comment = await _commentRepository.GetSingleCommentAsync(x=> x.Id ==  Id);
            if (comment == null) throw new CommentNotFoundException();
            if(comment.UserId != _authService.GetAuthenticatedUserId() && _authService.GetAuthenticatedUserRole() != "Admin")
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
            var comments = await _commentRepository.GetAllCommentsAsync(x=> x.TopicId ==  topicId);
            var result = _mapper.Map<List<CommentForGettingDTO>>(comments);
            return result;
        }

        public async Task<CommentForGettingDTO> GetSingleCommentAsync(int Id)
        {
            if (Id <= 0) throw new ArgumentOutOfRangeException("Invalid argument passed");
            var comment = await _commentRepository.GetSingleCommentAsync(x=> x.Id ==Id);
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
            if(model  == null) throw new ArgumentNullException("Invalid argument passed");
            if(model.UserId != _authService.GetAuthenticatedUserId() && _authService.GetAuthenticatedUserRole() != "Admin")
            {
                throw new UnauthorizedAccessException("Cant update other users comments");
            }
            await _commentRepository.UpdateCommentAsync(_mapper.Map<Comment>(model));
            await _commentRepository.Save();
        }
    }
}
