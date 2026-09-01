using ContactBook.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactBook.Data;

public class ContactDbContext : DbContext
{
    public ContactDbContext(DbContextOptions<ContactDbContext> options)
: base(options)
    {

    }
    public DbSet<Contact> Contacts { get; set; }
}
