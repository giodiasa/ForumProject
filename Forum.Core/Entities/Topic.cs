using Forum.Core.Common.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Core.Entities
{
    public class Topic
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public State State { get; set; } = State.Pending;
        [Required]
        public Status Status { get; set; } = Status.Active;
        public List<Comment>? Comments { get; set; }
        [ForeignKey(nameof(IdentityUser))]
        public string UserId { get; set; } = string.Empty;
        public IdentityUser? IdentityUser { get; set; }
    }
}
