using System;
using System.ComponentModel.DataAnnotations;

namespace TicketApp.Models
{
	public class Order
	{
        [Key]
		public int OrderId { get; set; }

        public string UserId { get; set; }

        public TicketAppUser OrderedBy { get; set; }

        public List<TicketsInOrder> TicketsInOrder { get; set; }

    }
}

