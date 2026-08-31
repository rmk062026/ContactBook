using System.Text.Json;
using ContactBook.Models;
using ContactBook.Service;

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

    public List<Contact> LoadContacts()
    {
        if (!File.Exists(filePath))
        {
            return new List<Contact>();
        }
        string json = File.ReadAllText(filePath);
        List<Contact>? contacts = JsonSerializer.Deserialize<List<Contact>>(json, options);

        return contacts ?? new List<Contact>();
    }
}