using AutoMapper;
using Forum.Application.DTOs;
using Forum.Application.Identity;
using Forum.Application.Interfaces;
using Forum.Core.Common.Enums;
using Forum.Core.Common.Exceptions;
using Forum.Core.Entities;
using Forum.Core.Interfaces;
using Forum.Infrastructure.Repositories;
using Microsoft.AspNetCore.JsonPatch;

namespace Forum.Application.Services
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public TopicService(ITopicRepository topicRepository, IAuthService authService)
        {
            _topicRepository = topicRepository;
            _authService = authService;
            _mapper = MappingInitializer.Initialize();
        }
        public async Task AddTopicAsync(TopicForCreatingDTO model)
        {
            if (model == null) throw new ArgumentNullException("Invalid argument passed");
            var result = _mapper.Map<Topic>(model);
            result.CreationDate = DateTime.Now;
            result.UserId = _authService.GetAuthenticatedUserId();
            result.Status = Status.Active;
            result.State = State.Pending;
            await _topicRepository.AddTopicAsync(result);
            await _topicRepository.Save();
        }

        public async Task ChangeStateOfTopic(int Id, JsonPatchDocument<TopicForUpdatingDTO> patchDocument)
        {
            if (Id <= 0) throw new ArgumentOutOfRangeException("Invalid argument passed");
            var topic = await _topicRepository.GetSingleTopicAsync(x => x.Id == Id);
            if (topic == null) throw new TopicNotFoundException();

            var topicToChange = _mapper.Map<TopicForUpdatingDTO>(topic);
            patchDocument.ApplyTo(topicToChange);
            _mapper.Map(topicToChange, topic);
            await _topicRepository.Save();
        }

        public async Task DeleteTopicAsync(int Id)
        {
            if (Id <= 0) throw new ArgumentOutOfRangeException("Invalid argument passed");
            var topic = await _topicRepository.GetSingleTopicAsync(x => x.Id == Id);
            if (topic == null) throw new TopicNotFoundException();
            if (topic.UserId != _authService.GetAuthenticatedUserId() && _authService.GetAuthenticatedUserRole() != "Admin")
            {
                throw new UnauthorizedAccessException("Cant delete other users topics");
            }
            else
            {
                _topicRepository.DeleteTopic(topic);
                await _topicRepository.Save();
            }
        }

        public async Task<List<TopicForGettingDTO>> GetAllTopicsAsync()
        {
            var topics = await _topicRepository.GetAllTopicsAsync(x => x.State == State.Show);
            if (topics.Count == 0 || topics == null)
            {
                throw new TopicNotFoundException();
            }
            var result = _mapper.Map<List<TopicForGettingDTO>>(topics);
            return result;
        }


        public async Task<TopicForGettingDTO> GetSingleTopicAsync(int Id)
        {
            if (Id <= 0) throw new ArgumentOutOfRangeException("Invalid argument passed");
            var topic = await _topicRepository.GetSingleTopicAsync(x => x.Id == Id);
            if (topic == null) throw new TopicNotFoundException();
            var result = _mapper.Map<TopicForGettingDTO>(topic);
            return result;
        }

        public async Task UpdateTopicAsync(TopicForUpdatingDTO model)
        {
            if (model == null) throw new ArgumentNullException("Invalid argument passed");
            var topicToUpdate = await _topicRepository.GetSingleTopicAsync(x => x.Id == model.Id);
            if (topicToUpdate == null) throw new TopicNotFoundException();
            if (topicToUpdate.UserId != _authService.GetAuthenticatedUserId() && _authService.GetAuthenticatedUserRole() != "Admin")
            {
                throw new UnauthorizedAccessException("Cant update other users topics");
            }            
            var result = _mapper.Map<Topic>(model);
            result.CreationDate = topicToUpdate.CreationDate;
            result.UserId = topicToUpdate.UserId;
            await _topicRepository.UpdateTopicAsync(result);
            await _topicRepository.Save();
        }
    }
}
