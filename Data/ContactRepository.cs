using ContactBook.Models;

namespace ContactBook.Data;

public class ContactRepository
{
    private readonly ContactDbContext dbContext;

    public ContactRepository(ContactDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void AddContact(Contact contact)
    {
        dbContext.Contacts.Add(contact);
        dbContext.SaveChanges();
    }

    public IEnumerable<Contact> GetAllContacts()
    {
        return dbContext.Contacts.ToList();
    }
}