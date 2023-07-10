using TicketApp.Domain.DTO;

namespace TicketApp.Service.Interface;

public interface IShoppingCartService
{
    ShoppingCartDto getShoppingCartInfo(string userId);
    bool deleteProductFromSoppingCart(string userId, Guid productId);
    // bool order(string userId);
}