using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Core.Entities
{
    public class Comment
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; } = string.Empty;
        [Required]
        public DateTime CreationDate { get; set; }
        [ForeignKey(nameof(Topic))]
        public int TopicId { get; set; }
        public Topic? Topic { get; set; }
        [ForeignKey(nameof(IdentityUser))]
        public string? UserId { get; set; }
        public IdentityUser? IdentityUser { get; set; }
        public string UserName { get; set; } = string.Empty;
    }
}
