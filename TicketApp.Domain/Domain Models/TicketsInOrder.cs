using System;
using System.ComponentModel.DataAnnotations.Schema;
using TicketApp.Models;

namespace TicketApp.Domain.DomainModels
{
	public class TicketsInOrder : BaseEntity
    {
		[ForeignKey("TicketId")]
		public int TicketId { get; set; }

		public Ticket Ticket { get; set; }

        [ForeignKey("OrderId")]
        public int OrderId { get; set; }

        public Order Order { get; set; }

    }
}

