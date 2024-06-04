using Forum.Core.Common.Enums;
using Forum.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Forum.Application.DTOs
{
    public class TopicForCreatingDTO
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public State State { get; set; } = State.Pending;
        [Required]
        public Status Status { get; set; } = Status.Active;
        [ForeignKey(nameof(IdentityUser))]
        public string UserId { get; set; } = string.Empty;
    }
}
