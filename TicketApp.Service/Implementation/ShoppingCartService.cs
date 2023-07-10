using TicketApp.Domain.DomainModels;
using TicketApp.Domain.DTO;
using TicketApp.Models;
using TicketApp.Repository.Interface;
using TicketApp.Service.Interface;

namespace TicketApp.Service.Implementation;

public class ShoppingCartService : IShoppingCartService
{
    
    private readonly IRepository<ShoppingCart> _shoppingCartRepository;
    private readonly IRepository<Order> _orderRepository;
    private readonly IRepository<TicketsInOrder> _ticketInOrderRepository;
    private readonly IUserRepository _userRepository;

    
    public ShoppingCartService(IRepository<ShoppingCart> shoppingCartRepository, IUserRepository userRepository, IRepository<Order> orderRepository, IRepository<TicketsInOrder> ticketInOrderRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _ticketInOrderRepository = ticketInOrderRepository;
        }


        public bool deleteProductFromSoppingCart(string userId, Guid productId)
        {
            if(!string.IsNullOrEmpty(userId) && productId != null)
            {
                var loggedInUser = this._userRepository.Get(userId);

                var userShoppingCart = loggedInUser.UserShoppingCart;

                var itemToDelete = userShoppingCart.TicketInShoppingCart.Where(z => z.TicketId.Equals(productId)).FirstOrDefault();

                userShoppingCart.TicketInShoppingCart.Remove(itemToDelete);

                this._shoppingCartRepository.Update(userShoppingCart);

                return true;
            }
            return false;
        }

        public ShoppingCartDto getShoppingCartInfo(string userId)
        {
            if(!string.IsNullOrEmpty(userId))
            {
                var loggedInUser = this._userRepository.Get(userId);

                var userCard = loggedInUser.UserShoppingCart;

                var allTickets = userCard.TicketInShoppingCart.ToList();

                var allProductPrices = allTickets.Select(z => new
                {
                    ProductPrice = z.Ticket.Price,
                    Quantity = z.Quantity
                }).ToList();

                float totalPrice = 0;

                foreach (var item in allProductPrices)
                {
                    totalPrice += item.Quantity * item.ProductPrice;
                }

                var reuslt = new ShoppingCartDto
                {
                    TicketsInShoppingCart = allTickets,
                    TotalPrice = totalPrice
                };

                return reuslt;
            }
            return new ShoppingCartDto();
        }

        // public bool order(string userId)
        // {
        //     if (!string.IsNullOrEmpty(userId))
        //     {
        //         var loggedInUser = this._userRepository.Get(userId);
        //         var userCard = loggedInUser.UserCart;
        //
        //
        //         Order order = new Order
        //         {
        //             Id = Guid.NewGuid(),
        //             User = loggedInUser,
        //             UserId = userId
        //         };
        //
        //         this._orderRepository.Insert(order);
        //
        //         List<ProductInOrder> productInOrders = new List<ProductInOrder>();
        //
        //         var result = userCard.ProductInShoppingCarts.Select(z => new ProductInOrder
        //         {
        //             Id = Guid.NewGuid(),
        //             ProductId = z.CurrnetProduct.Id,
        //             Product = z.CurrnetProduct,
        //             OrderId = order.Id,
        //             Order = order, 
        //             Quantity = z.Quantity
        //         }).ToList();
        //
        //         StringBuilder sb = new StringBuilder();
        //
        //         var totalPrice = 0.0;
        //
        //         sb.AppendLine("Your order is completed. The order conatins: ");
        //
        //         for (int i = 1; i <= result.Count(); i++)
        //         {
        //             var currentItem = result[i - 1];
        //             totalPrice += currentItem.Quantity * currentItem.Product.ProductPrice;
        //             sb.AppendLine(i.ToString() + ". " + currentItem.Product.ProductName + " with quantity of: " + currentItem.Quantity + " and price of: $" + currentItem.Product.ProductPrice);
        //         }
        //
        //         sb.AppendLine("Total price for your order: " + totalPrice.ToString());
        //
        //         mail.Content = sb.ToString();
        //
        //
        //         productInOrders.AddRange(result);
        //
        //         foreach (var item in productInOrders)
        //         {
        //             this._productInOrderRepository.Insert(item);
        //         }
        //
        //         loggedInUser.UserCart.ProductInShoppingCarts.Clear();
        //
        //         this._userRepository.Update(loggedInUser);
        //         this._mailRepository.Insert(mail);
        //
        //         return true;
        //     }
        //
        //     return false;
        // }
    }