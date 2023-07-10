using System;
using TicketApp.Domain.DomainModels;
using TicketApp.Domain.DTO;
using TicketApp.Repository.Interface;

namespace TicketApp.Service.Interface
{
	public interface ITicketService
	{
		public bool AddToShoppingCart(ShoppingCartDto item, string userID);

		public void CreateNewTicket(Ticket t);

		public void DeleteTicket(int id);

		public List<Ticket> GetAllTickets();

		public Ticket GetDetailsForTicket(int id);

		public ShoppingCartDto GetShoppingCartInfo(int id);

		public void UpdateExistingTicket(Ticket t);

		public List<Ticket> GetTicketsForMovie(int id);
	}
}

