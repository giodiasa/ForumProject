using Forum.Application.DTOs;
using Forum.Core.Entities;
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
    }
}
