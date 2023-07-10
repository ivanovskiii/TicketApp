using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketApp.Domain;
using TicketApp.Domain.DomainModels;
using TicketApp.Models;

namespace TicketApp.Repository;

public class ApplicationDbContext : IdentityDbContext<TicketAppUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Movie> Movie { get; set; } = default!;

    public DbSet<Ticket> Ticket { get; set; } = default!;

    public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }

    public virtual DbSet<TicketInShoppingCart> TicketInShoppingCart { get; set; }

    public virtual DbSet<TicketAppUser> TicketAppUser { get; set; }

    public virtual DbSet<Order> Order { get; set; }

    public virtual DbSet<TicketsInOrder> TicketsInOrder { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<TicketInShoppingCart>().HasKey(c => new { c.CartId, c.TicketId });
        builder.Entity<TicketsInOrder>().HasKey(c => new { c.OrderId, c.TicketId });
    }
}