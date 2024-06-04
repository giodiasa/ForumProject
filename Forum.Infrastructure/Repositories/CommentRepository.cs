using Forum.Core.Entities;
using Forum.Core.Interfaces;
using Forum.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Forum.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddCommentAsync(Comment entity)
        {
            if(entity != null)
            {
                await _context.Comments.AddAsync(entity);
            }
        }

        public void DeleteComment(Comment entity)
        {
            if(entity != null)
            {
                _context.Comments.Remove(entity);
            }
        }

        public async Task<List<Comment>> GetAllCommentsAsync()
        {
            return await _context.Comments
                .Include(comment => comment.IdentityUser)
                .Include(comment => comment.Topic)
                .ToListAsync();
        }

        public async Task<List<Comment>> GetAllCommentsAsync(Expression<Func<Comment, bool>> filter)
        {
            return await _context.Comments
                .Include(comment => comment.IdentityUser)
                .Include(comment => comment.Topic)
                .Where(filter).ToListAsync();
        }

        public async Task<Comment?> GetSingleCommentAsync(Expression<Func<Comment, bool>> filter)
        {
            return await _context.Comments
                .Include(comment => comment.IdentityUser)
                .Include(comment => comment.Topic)
                .FirstOrDefaultAsync(filter);
        }

        public async Task Save() => await _context.SaveChangesAsync();

        public async Task UpdateCommentAsync(Comment entity)
        {
            if (entity != null)
            {
                var commentToUpdate = await _context.Comments.FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (commentToUpdate != null)
                {
                    commentToUpdate.Text = entity.Text;
                    commentToUpdate.CreationDate = entity.CreationDate;
                    commentToUpdate.TopicId = entity.TopicId;
                    commentToUpdate.UserId = entity.UserId;
                    _context.Comments.Update(commentToUpdate);
                }
            }
        }
    }
}
