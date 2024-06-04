using Forum.Core.Common.Enums;
using Forum.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Forum.Application.DTOs
{
    public class TopicForGettingDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public State State { get; set; } = State.Pending;
        public Status Status { get; set; } = Status.Active;
        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public int NumberOfComments { get; set; }
    }
}
