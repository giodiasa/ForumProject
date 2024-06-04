using Forum.Application.DTOs;
using Forum.Core.Entities;
using System.Linq.Expressions;

namespace Forum.Application.Interfaces
{
    public interface ICommentService
    {
        Task<List<CommentForGettingDTO>> GetAllCommentsOfTopicAsync(int topicId);
        Task<CommentForGettingDTO> GetSingleCommentAsync(int Id);
        Task AddCommentAsync(CommentForCreatingDTO model);
        Task UpdateCommentAsync(CommentForUpdatingDTO model);
        Task DeleteCommentAsync(int Id);
    }
}
