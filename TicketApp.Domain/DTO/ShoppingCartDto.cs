using System;
using TicketApp.Domain.DomainModels;

namespace TicketApp.Domain.DTO
{
    public class ShoppingCartDto
	{
		public List<TicketInShoppingCart> TicketsInShoppingCart { get; set; }
		public float TotalPrice { get; set; }
	}
}

