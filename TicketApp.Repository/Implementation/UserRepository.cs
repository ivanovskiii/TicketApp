using Microsoft.EntityFrameworkCore;
using TicketApp.Domain;
using TicketApp.Repository;
using TicketApp.Repository.Interface;

namespace TicketApp.Repository.Implementation;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext context;
    private DbSet<TicketAppUser> entities;
    string errorMessage = string.Empty;

    public UserRepository(ApplicationDbContext context)
    {
        this.context = context;
        entities = context.Set<TicketAppUser>();
    }
    public IEnumerable<TicketAppUser> GetAll()
    {
        return entities.AsEnumerable();
    }

    public TicketAppUser Get(string id)
    {
        return entities
            .Include(z => z.UserShoppingCart)
            .Include("UserShoppingCart.TicketInShoppingCart")
            .Include("UserShoppingCart.TicketInShoppingCart.Ticket")
            .SingleOrDefault(s => s.Id == id);
    }
    public void Insert(TicketAppUser entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }
        entities.Add(entity);
        context.SaveChanges();
    }

    public void Update(TicketAppUser entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }
        entities.Update(entity);
        context.SaveChanges();
    }

    public void Delete(TicketAppUser entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }
        entities.Remove(entity);
        context.SaveChanges();
    }
}