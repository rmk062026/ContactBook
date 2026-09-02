using ContactBook.Data;
using ContactBook.Models;
using Microsoft.EntityFrameworkCore;

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
        return contacts.Where(contact =>
            contact.Name != null &&
            contact.Name.Contains(search, StringComparison.OrdinalIgnoreCase));
    }

    public bool DeleteContact(int id)
    {
        // Contact? contact = contacts.FirstOrDefault(contact => contact.Id == id);

        // if (contact == null)
        // {
        //     return false;
        // }

        // contacts.Remove(contact);

        // fileRepository.SaveContacts(contacts);
        // return true;
    }

    public Contact? GetContactById(int id)
    {
        return contacts.FirstOrDefault(contact => contact.Id == id);
    }
}