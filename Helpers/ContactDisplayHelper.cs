using ContactBook.Models;

namespace ContactBook.Helpers;

public static class ContactDisplayHelper
{
    public static void ShowContact(Contact contact)
    {
        Console.WriteLine($"ID: {contact.Id}");
        Console.WriteLine($"Name: {contact.Name}");
        Console.WriteLine($"Phone number: {contact.PhoneNumber}");
        Console.WriteLine($"Address: {contact.Address}");
        Console.WriteLine($"Email: {contact.Email}");
        Console.WriteLine($"Birthday: {contact.Birthday?.ToString("dd.MM.yyyy") ?? "Not set"}");
    }
}