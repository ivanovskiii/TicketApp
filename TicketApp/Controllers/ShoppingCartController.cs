using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketApp.Domain.DomainModels;
using TicketApp.Domain.DTO;
using TicketApp.Models;
using TicketApp.Repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketApp.Controllers
{
    public class ShoppingCartController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ShoppingCartController(ApplicationDbContext context){
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(z => z.Id == userId)
                .Include("UserShoppingCart.TicketInShoppingCart")
                .Include("UserShoppingCart.TicketInShoppingCart.Ticket")
                .Include("UserShoppingCart.TicketInShoppingCart.Ticket.Movie")
                .FirstOrDefault();

            var userShoppingCart = user.UserShoppingCart;

            var ticketList = userShoppingCart.TicketInShoppingCart.Select(z => new
            {
                Quantity = z.Quantity,
                TicketPrice = z.Ticket.Price
            });

            float totalPrice = 0;
            foreach(var ticket in ticketList)
            {
                totalPrice += ticket.TicketPrice * ticket.Quantity;
            }

            ShoppingCartDto model = new ShoppingCartDto
            {
                TotalPrice = totalPrice,
                TicketsInShoppingCart = userShoppingCart.TicketInShoppingCart.ToList()
            };

            return View(model);
        }

        public IActionResult DeleteFromShoppingCart(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(z => z.Id == userId)
                .Include("UserShoppingCart.TicketInShoppingCart")
                .Include("UserShoppingCart.TicketInShoppingCart.Ticket")
                .Include("UserShoppingCart.TicketInShoppingCart.Ticket.Movie")
                .FirstOrDefault();

            var userShoppingCart = user.UserShoppingCart;
            var forRemoval = userShoppingCart.TicketInShoppingCart.Where(z => z.TicketId == id).FirstOrDefault();
            userShoppingCart.TicketInShoppingCart.Remove(forRemoval);
            _context.Update(userShoppingCart);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult PayTickets()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(z => z.Id == userId)
                .Include("UserShoppingCart.TicketInShoppingCart")
                .Include("UserShoppingCart.TicketInShoppingCart.Ticket")
                .Include("UserShoppingCart.TicketInShoppingCart.Ticket.Movie")
                .FirstOrDefault();

            var userShoppingCart = user.UserShoppingCart;

            Order newOrder = new Order
            {
                UserId = user.Id,
                OrderedBy = user
            };

            List<TicketsInOrder> ticketsInOrders = userShoppingCart.TicketInShoppingCart.Select(z => new TicketsInOrder
            {
                Ticket = z.Ticket,
                TicketId = z.TicketId,
                Order = newOrder,
                OrderId = newOrder.OrderId

            }).ToList();

            foreach(var item in ticketsInOrders)
            {
                _context.Add(item);
            }

            user.UserShoppingCart.TicketInShoppingCart.Clear();
            _context.Update(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

