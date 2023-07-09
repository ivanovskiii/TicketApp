using System;
using Microsoft.AspNetCore.Identity;

namespace TicketApp.Models
{
	public class TicketAppUser : IdentityUser
	{
		public string Name { get; set; }

        public string Surname { get; set; }

        public virtual ShoppingCart UserShoppingCart { get; set; }

    }
}

