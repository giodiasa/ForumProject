using Forum.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Forum.Application.DTOs
{
    public class CommentForCreatingDTO
    {
        [Required]
        public string Text { get; set; } = string.Empty;
        [Required]
        public DateTime CreationDate { get; set; }
        [ForeignKey(nameof(Topic))]
        public int TopicId { get; set; }
        [ForeignKey(nameof(IdentityUser))]
        public string UserId { get; set; } = string.Empty;
    }
}
