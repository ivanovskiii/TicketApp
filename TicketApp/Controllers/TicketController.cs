using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicketApp.Domain.DomainModels;
using TicketApp.Domain.DTO;
using TicketApp.Service.Interface;

namespace TicketApp.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // GET: Ticket
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _ticketService.Ticket.Include(t => t.Movie);
            return View(_ticketService.GetAllTickets());
        }

        public async Task<IActionResult> AddToCart(int ticketId)
        {
            var ticket = _ticketService.GetDetailsForTicket(ticketId);

            var model = new AddToShoppingCartDto();
            model.SelectedTicket = ticket;
            model.TicketId = ticket.Id;
            model.Quantity = 0;

            return View(model);


            //var cart = _context.ShoppingCart.Include(c => c.TicketInShoppingCart).FirstOrDefault(z => z.CartId == cartId);
            //var movie = _context.Movie.FirstOrDefault(m => m.Id == movieId);

            //ticket.Movie = movie;

            //if (ticket == null || cart == null)
            //{
            //    // Handle the case when ticket or cart is not found
            //    return NotFound();
            //}

            //var ticketInShoppingCart = new TicketInShoppingCart
            //{
            //    CartId = cart.CartId,
            //    TicketId = ticket.TicketId
            //};

            //cart.TicketInShoppingCart.Add(ticketInShoppingCart);

            //_context.TicketInShoppingCart.Add(ticketInShoppingCart);
            //await _context.SaveChangesAsync();

            //return View(ticket);
        }

        //[HttpPost]
        //public async Task<IActionResult> AddToShoppingCart(AddToShoppingCartDto model)
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var user = _context.Users.Where(z => z.Id == userId)
        //        .Include("UserShoppingCart.TicketInShoppingCart")
        //        .Include("UserShoppingCart.TicketInShoppingCart.Ticket")
        //        .Include("UserShoppingCart.TicketInShoppingCart.Ticket.Movie")
        //        .FirstOrDefault();

        //    var userShoppingCart = user.UserShoppingCart;
        //    if (userShoppingCart != null)
        //    {
        //        var ticket = _context.Ticket.Find(model.TicketId);
        //        if (ticket != null)
        //        {
        //            TicketInShoppingCart ticketToAdd = new TicketInShoppingCart
        //            {
        //                Ticket = ticket,
        //                TicketId = ticket.TicketId,
        //                ShoppingCart = userShoppingCart,
        //                Quantity = model.Quantity
        //            };

        //            _context.Add(ticketToAdd);
        //            await _context.SaveChangesAsync();
        //        }
        //    }

        //    return RedirectToAction("Index", "Movie", new { area = "" });
        //}



        // GET: Ticket/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = _ticketService.GetDetailsForTicket(id??0);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Ticket/Create
        public IActionResult Create()
        {
            //ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title");
            return View();
        }

        // POST: Ticket/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ticket ticket)
        {
            //Movie movie = await _context.Movie.FindAsync(ticket.MovieId);

            //if (movie == null)
            //{
            //    // Movie not found, handle the error
            //    Console.WriteLine("Movie not found for the provided MovieId.");
            //    return RedirectToAction(nameof(Index));
            //}

            //// Associate the movie object with the ticket
            //ticket.Movie = movie;

            //Console.WriteLine($"Ticket Details: Id={ticket.TicketId}, Date={ticket.Date}, Hall={ticket.Hall}, MovieId={ticket.MovieId}, Movie={ticket.Movie.Title}");

            //_context.Add(ticket);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));

            _ticketService.CreateNewTicket(ticket);
            return RedirectToAction("Index");
        }

        // GET: Ticket/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = _ticketService.GetDetailsForTicket(id ?? 0);
            if (ticket == null)
            {
                return NotFound();
            }
            //ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", ticket.MovieId);
            return View(ticket);
        }

        // POST: Ticket/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            _ticketService.UpdateExistingTicket(ticket);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Ticket/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = _ticketService.GetDetailsForTicket(id??0);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //if (_context.Ticket == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.Ticket'  is null.");
            //}
            //var ticket = await _context.Ticket.FindAsync(id);
            //if (ticket != null)
            //{
            //    _context.Ticket.Remove(ticket);
            //}

            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));

            _ticketService.DeleteTicket(id);
            return RedirectToAction("Index");
        }

        private bool TicketExists(int id)
        {
            return _ticketService.GetDetailsForTicket(id) != null;
        }
    }
}
