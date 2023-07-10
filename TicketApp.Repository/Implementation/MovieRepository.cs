using Microsoft.EntityFrameworkCore;
using TicketApp.Domain.DomainModels;
using TicketApp.Repository.Interface;

namespace TicketApp.Repository.Implementation;

public class MovieRepository<T> : IMovieRepository<T> where T : BaseEntity
{
    
    private readonly ApplicationDbContext context;
    private DbSet<T> entities;
    string erorMessage = string.Empty;

    public MovieRepository(ApplicationDbContext context)
    {
        this.context = context;
        entities = context.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        return entities.AsEnumerable();
    }

    public T Get(int id)
    {
        return entities.SingleOrDefault(z => z.Id == id);
    }

    public void Insert(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }
        entities.Add(entity);
        context.SaveChanges();
    }

    public void Update(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }
        entities.Update(entity);
        context.SaveChanges();
    }

    public void Delete(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }
        entities.Remove(entity);
        context.SaveChanges();
    }
}