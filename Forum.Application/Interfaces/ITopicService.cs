using Forum.Application.DTOs;
using Forum.Application.Identity;
using Forum.Core.Entities;
using Microsoft.AspNetCore.JsonPatch;
using System.Linq.Expressions;

namespace Forum.Application.Interfaces
{
    public interface ITopicService
    {
        Task<List<TopicForGettingDTO>> GetAllTopicsAsync();
        Task<TopicForGettingDTO> GetSingleTopicAsync(int Id);
        Task AddTopicAsync(TopicForCreatingDTO model);
        Task UpdateTopicAsync(TopicForUpdatingDTO model);
        Task DeleteTopicAsync(int Id);
        Task UpdateTopicAsync(int Id, JsonPatchDocument<TopicForUpdatingDTO> patchDocument);
    }
}
