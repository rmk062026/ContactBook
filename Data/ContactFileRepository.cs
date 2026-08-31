using System.Text.Json;
using ContactBook.Models;

namespace ContactBook.Data;

public class ContactFileRepository
{
    private readonly string filePath = "contacts.json";
    private readonly JsonSerializerOptions options = new()
    {
        WriteIndented = true
    };

    public void SaveContacts(IEnumerable<Contact> contacts)
    {
        string json = JsonSerializer.Serialize(contacts, options);
        File.WriteAllText(filePath, json);
    }
}