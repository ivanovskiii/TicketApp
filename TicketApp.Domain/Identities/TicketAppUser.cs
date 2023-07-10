using System;
using Microsoft.AspNetCore.Identity;
using TicketApp.Domain.DomainModels;

namespace TicketApp.Domain
{
	public class TicketAppUser : IdentityUser
	{
		public string Name { get; set; }

        public string Surname { get; set; }

        public virtual ShoppingCart UserShoppingCart { get; set; }

    }
}

