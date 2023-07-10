using TicketApp.Domain;

namespace TicketApp.Repository.Interface;

public interface IUserRepository
{
    IEnumerable<TicketAppUser> GetAll();
    TicketAppUser Get(string id);
    void Insert(TicketAppUser entity);
    void Update(TicketAppUser entity);
    void Delete(TicketAppUser entity);
}