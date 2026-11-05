using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ContactBook.Data;

public class ContactDbContextFactory : IDesignTimeDbContextFactory<ContactDbContext>
{
    public ContactDbContext CreateDbContext(string[] args)
    {
        string connectionString =
            "Server=localhost;Database=ContactBook;Trusted_Connection=True;TrustServerCertificate=True;";

        DbContextOptions<ContactDbContext> options =
            new DbContextOptionsBuilder<ContactDbContext>()
                .UseSqlServer(connectionString)
                .Options;

        return new ContactDbContext(options);
    }
}