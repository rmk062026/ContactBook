using ContactBook.Data;
using ContactBook.Models;
namespace ContactBook.Service;

public class ContactService
{
    private readonly ContactRepository contactRepository;

    public ContactService(ContactRepository contactRepository)
    {
        this.contactRepository = contactRepository;
    }

    public void AddContact(Contact contact)
    {
        contactRepository.AddContact(contact);
    }

    public IEnumerable<Contact> GetAllContacts()
    {
        return contactRepository.GetAllContacts();
    }

    public IEnumerable<Contact> SearchContacts(string search)
    {
        return contactRepository.SearchContacts(search);
    }

    public Contact? GetContactById(int id)
    {
        return contactRepository.GetContactById(id);
    }

    public bool DeleteContact(int id)
    {
        return contactRepository.DeleteContact(id);
    }
}