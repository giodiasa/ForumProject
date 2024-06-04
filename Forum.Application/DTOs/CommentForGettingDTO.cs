using Forum.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Forum.Application.DTOs
{
    public class CommentForGettingDTO
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public int TopicId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}
