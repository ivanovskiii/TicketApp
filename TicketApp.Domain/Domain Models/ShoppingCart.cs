using System;
using System.ComponentModel.DataAnnotations;

namespace TicketApp.Domain.DomainModels
{
	public class ShoppingCart : BaseEntity
    {

		public string ApplicationUserId { get; set; }

        public ICollection<TicketInShoppingCart> TicketInShoppingCart { get; set; }
    }
}

