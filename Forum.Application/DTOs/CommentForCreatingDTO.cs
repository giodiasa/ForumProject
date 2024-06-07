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
        [ForeignKey(nameof(Topic))]
        public int TopicId { get; set; }
    }
}
