using System;
using TicketApp.Domain.DomainModels;
using TicketApp.Domain.DTO;
using TicketApp.Repository.Interface;
using TicketApp.Service.Interface;

namespace TicketApp.Service.Implementation
{
    public class TicketService : ITicketService
    {

        public readonly IRepository<Ticket> _ticketRepository;

        public TicketService(IRepository<Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public bool AddToShoppingCart(ShoppingCartDto item, string userID)
        {
            throw new NotImplementedException();
        }

        public void CreateNewTicket(Ticket t)
        {
            this._ticketRepository.Insert(t);
        }

        public void DeleteTicket(int id)
        {
            var ticket = _ticketRepository.Get(id);
            this._ticketRepository.Delete(ticket);
        }

        public List<Ticket> GetAllTickets()
        {
            return _ticketRepository.GetAll().ToList();
        }

        public Ticket GetDetailsForTicket(int id)
        {
            return _ticketRepository.Get(id);
        }

        public ShoppingCartDto GetShoppingCartInfo(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateExistingTicket(Ticket t)
        {
            _ticketRepository.Update(t);
        }

        public List<Ticket> GetTicketsForMovie(int id)
        {
            return _ticketRepository.GetAll().Where(t => t.MovieId == id).ToList();
        }

    }
}

