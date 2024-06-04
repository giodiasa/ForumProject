using Forum.Core.Entities;
using Forum.Core.Interfaces;
using Forum.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Forum.Infrastructure.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly ApplicationDbContext _context;

        public TopicRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddTopicAsync(Topic entity)
        {
            if (entity != null)
            {
                await _context.Topics.AddAsync(entity);
            }
        }

        public void DeleteTopic(Topic entity)
        {
            if (entity != null)
            {
                _context.Topics.Remove(entity);
            }
        }

        public async Task<List<Topic>> GetAllTopicsAsync()
        {
            return await _context.Topics
                .Include(topic => topic.Comments)
                .Include(topic => topic.IdentityUser)
                .ToListAsync();
        }

        public async Task<List<Topic>> GetAllTopicsAsync(Expression<Func<Topic, bool>> filter)
        {
            return await _context.Topics.Where(filter)
                .Include(topic => topic.Comments)
                .Include(topic => topic.IdentityUser)
                .ToListAsync();
        }

        public async Task<Topic?> GetSingleTopicAsync(Expression<Func<Topic, bool>> filter)
        {
            return await _context.Topics
                .Include(topic => topic.Comments)
                .Include(topic => topic.IdentityUser)
                .FirstOrDefaultAsync(filter);
        }

        public async Task Save() => await _context.SaveChangesAsync();

        public async Task UpdateTopicAsync(Topic entity)
        {
            if (entity != null)
            {
                var topicToUpdate = await _context.Topics.FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (topicToUpdate != null)
                {
                    topicToUpdate.Title = entity.Title;
                    topicToUpdate.CreationDate = entity.CreationDate;
                    topicToUpdate.State = entity.State;
                    topicToUpdate.Status = entity.Status;
                    topicToUpdate.UserId = entity.UserId;
                    _context.Topics.Update(topicToUpdate);
                }
            }
        }
    }
}
