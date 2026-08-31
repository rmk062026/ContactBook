using System.Text.Json;
using ContactBook.Models;

namespace ContactBook.Data;

public class ContactFileRepository
{
    private readonly string filePath = "contacts.json";

    public void SaveContacts(IEnumerable<Contact> contacts)
    {
        string json = JsonSerializer.Serialize(contacts);
        File.WriteAllText(filePath, json);
    }
}