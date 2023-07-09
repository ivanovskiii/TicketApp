using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketApp.Domain.DomainModels
{
    public class Ticket : BaseEntity
    {

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Hall { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        [ForeignKey("Movie")]
        public int MovieId { get; set; }

        [Required]
        public required Movie Movie { get; set; }

        public ICollection<TicketInShoppingCart> TicketInShoppingCart{ get; set; }
    }
}
