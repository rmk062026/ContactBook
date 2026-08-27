using ContactBook.Models;

namespace ContactBook.Service;

public class ContactService
{
    private List<Contact> contacts = new();

    private int nextId = 1;

    public void AddContact(Contact contact)
    {
        contact.Id = nextId;
        nextId++;

        contacts.Add(contact);
    }

    public IEnumerable<Contact> GetAllContacts()
    {
        return contacts;
    }

    public IEnumerable<Contact> SearchContacts(string search)
    {
        return contacts.Where(contact =>
            contact.Name != null &&
            contact.Name.Contains(search, StringComparison.OrdinalIgnoreCase));
    }
}