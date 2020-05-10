using System;
using System.ComponentModel.DataAnnotations;

namespace CybersportApp.Core.CybersportEntities
{
    public class Messages
    {
        [Required]
        public Guid SenderId { get; set; }

        [Required]
        public Guid RecipientId { get; set; }

        [Key]
        public Guid MessageId { get; set; }

        [Required]
        public string MessageText { get; set; }

        [Required]
        public DateTime MessageTime { get; set; }
    }
}
