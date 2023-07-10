using System;
using TicketApp.Domain.DomainModels;

namespace TicketApp.Domain.DTO
{
    public class AddToShoppingCartDto
	{
		public Ticket SelectedTicket { get; set; }
		public int TicketId { get; set; }
        public int Quantity { get; set; }
    }
}

