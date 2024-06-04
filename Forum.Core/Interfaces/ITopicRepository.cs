using Forum.Core.Entities;
using System.Linq.Expressions;

namespace Forum.Core.Interfaces
{
    public interface ITopicRepository : ISavable
    {
        Task<List<Topic>> GetAllTopicsAsync();
        Task<List<Topic>> GetAllTopicsAsync(Expression<Func<Topic, bool>> filter);
        Task<Topic?> GetSingleTopicAsync(Expression<Func<Topic, bool>> filter);
        Task AddTopicAsync(Topic entity);
        Task UpdateTopicAsync(Topic entity);
        void DeleteTopic(Topic entity);
    }
}
