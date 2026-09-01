using ContactBook.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactBook.Data;

public class ContactDbContext : DbContext
{
    public DbSet<Contact> contacts { get; set; }
}