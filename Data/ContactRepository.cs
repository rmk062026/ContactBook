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

    public IEnumerable<Contact> SearchContacts(string search)
    {
        return dbContext.Contacts
            .Where(contact =>
            contact.Name != null &&
            contact.Name.Contains(search))
        .ToList();
    }

    public Contact? GetContactById(int id)
    {
        return dbContext.Contacts
            .FirstOrDefault(contact => contact.Id == id);
    }

    public bool DeleteContact(int id)
    {
        Contact? contact = dbContext.Contacts
            .FirstOrDefault(contact => contact.Id == id);

        if (contact == null)
        {
            return false;
        }
        dbContext.Contacts.Remove(contact);
        dbContext.SaveChanges();

        return true;
    }
}