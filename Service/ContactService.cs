using ContactBook.Data;
using ContactBook.Models;

namespace ContactBook.Service;

public class ContactService
{
    // private List<Contact> contacts = new();
    private List<Contact> contacts;
    private int nextId = 1;
    private readonly ContactFileRepository fileRepository;

    public ContactService()
    {
        fileRepository = new ContactFileRepository();

        contacts = fileRepository.LoadContacts();

        if (contacts.Count > 0)
        {
            nextId = contacts.Max(contact => contact.Id) + 1;
        }
    }

    public void AddContact(Contact contact)
    {
        contact.Id = nextId;
        nextId++;

        contacts.Add(contact);

        fileRepository.SaveContacts(contacts);
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

    public bool DeleteContact(int id)
    {
        Contact? contact = contacts.FirstOrDefault(contact => contact.Id == id);

        if (contact == null)
        {
            return false;
        }

        contacts.Remove(contact);

        fileRepository.SaveContacts(contacts);
        return true;
    }

    public Contact? GetContactById(int id)
    {
        return contacts.FirstOrDefault(contact => contact.Id == id);
    }
}