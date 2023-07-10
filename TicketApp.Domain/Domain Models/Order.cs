using System;
using System.ComponentModel.DataAnnotations;
using TicketApp.Domain;
using TicketApp.Domain.DomainModels;

namespace TicketApp.Domain.DomainModels
{
	public class Order : BaseEntity
	{
        [Key]
		public int OrderId { get; set; }

        public string UserId { get; set; }

        public TicketAppUser OrderedBy { get; set; }

        public List<TicketsInOrder> TicketsInOrder { get; set; }

    }
}

