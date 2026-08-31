using ContactBook.Models;
using ContactBook.Service;

namespace ContactBook;

class Program
{
    static void Main(string[] args)
    {
        bool programRunning = true;
        ContactService contactService = new ContactService();
        while (programRunning)
        {
            Console.Clear();
            Console.WriteLine("=============== ContactBook =============== ");
            System.Console.WriteLine();
            System.Console.WriteLine("1. Add new contact");
            System.Console.WriteLine("2. Show all contacts");
            System.Console.WriteLine("3. Search for contact");
            System.Console.WriteLine("4. Delete contact");
            System.Console.WriteLine("5. Exit");
            System.Console.WriteLine("Please enter a choice (1-5):\n\n");
            string choiceInput = Console.ReadLine() ?? "";

            switch (choiceInput)
            {
                case "1":
                    Console.Clear();

                    Console.WriteLine("Enter name:");
                    string name = Console.ReadLine() ?? "";

                    Console.WriteLine("Enter phone number");
                    string phoneNumber = Console.ReadLine() ?? "";

                    Console.WriteLine("Enter Address");
                    string address = Console.ReadLine() ?? "";

                    Console.WriteLine("Enter email:");
                    string email = Console.ReadLine() ?? "";

                    DateOnly? birthday = null;
                    while (birthday == null)
                    {
                        Console.WriteLine("Enter birthday (dd.MM.yyyy): ");
                        string birthdayInput = Console.ReadLine() ?? "";
                        if (DateOnly.TryParse(birthdayInput, out DateOnly parsedBirthday))
                        {
                            birthday = parsedBirthday;
                        }
                        else
                        {
                            Console.WriteLine("Invalid date. Please try again...");
                        }
                    }
                    Console.Clear();

                    Contact contact = new Contact
                    {
                        Name = name,
                        PhoneNumber = phoneNumber,
                        Address = address,
                        Email = email,
                        Birthday = birthday
                    };
                    contactService.AddContact(contact);

                    Console.WriteLine();
                    Console.WriteLine("Contact added successfully!");
                    Console.WriteLine($"ID: {contact.Id}");
                    Console.WriteLine($"Name: {contact.Name}");
                    Console.WriteLine($"Phone number: {contact.PhoneNumber}");
                    Console.WriteLine($"Address: {contact.Address}");
                    Console.WriteLine($"Email: {contact.Email}");
                    Console.WriteLine($"Birthday: {contact.Birthday?.ToString("dd.MM.yyyy") ?? "Not set"}");

                    Console.WriteLine("\nPress any key to return...");
                    Console.ReadKey(true);
                    break;

                case "2":
                    Console.Clear();

                    IEnumerable<Contact> allContacts = contactService.GetAllContacts();

                    foreach (Contact currentContact in allContacts)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"ID: {currentContact.Id}");
                        Console.WriteLine($"Name: {currentContact.Name}");
                        Console.WriteLine($"Phone number: {currentContact.PhoneNumber}");
                        Console.WriteLine($"Address: {currentContact.Address}");
                        Console.WriteLine($"Email: {currentContact.Email}");
                        Console.WriteLine($"Birthday: {currentContact.Birthday?.ToString("dd.MM.yyyy") ?? "Not set"}");
                        Console.WriteLine("-----------------------------");
                    }

                    Console.WriteLine("\nPress any key to return...");
                    Console.ReadKey(true);
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("Enter name to search: ");
                    string search = Console.ReadLine() ?? "";

                    IEnumerable<Contact> searchResults = contactService.SearchContacts(search);

                    foreach (Contact contactSearch in searchResults)
                    {
                        Console.WriteLine($"ID: {contactSearch.Id}");
                        Console.WriteLine($"Name: {contactSearch.Name}");
                        Console.WriteLine($"Phone: {contactSearch.PhoneNumber}");
                        Console.WriteLine($"Email: {contactSearch.Email}");
                        Console.WriteLine($"Address: {contactSearch.Address}");
                        Console.WriteLine($"Birthday: {contactSearch.Birthday?.ToString("dd.MM.yyyy") ?? "Not set"}");
                        Console.WriteLine("-----------------------------");
                    }

                    Console.WriteLine("\nPress any key to return...");
                    Console.ReadKey(true);
                    break;

                case "4":
                    Console.Clear();

                    Console.WriteLine("=============== Delete Contact ===============");
                    Console.WriteLine();

                    Console.WriteLine("Enter contact ID:");
                    string idInput = Console.ReadLine() ?? "";

                    if (!int.TryParse(idInput, out int id))
                    {
                        Console.WriteLine("Invalid ID.");
                    }

                    Contact? contactToDelete = contactService.GetContactById(id);

                    if (contactToDelete == null)
                    {
                        Console.WriteLine("Contact not found.");
                        Console.ReadKey(true);
                        break;
                    }

                    Console.WriteLine("Contact found:");
                    Console.WriteLine($"ID: {contactToDelete.Id}");
                    Console.WriteLine($"Name: {contactToDelete.Name}");
                    Console.WriteLine($"Phone: {contactToDelete.PhoneNumber}");
                    Console.WriteLine($"email: {contactToDelete.Email}");
                    Console.WriteLine();

                    Console.Write("Delete this contact? (y/n): ");
                    string confirmation = Console.ReadLine()?.Trim().ToLower() ?? "";

                    if (confirmation == "y")
                    {
                        contactService.DeleteContact(id);
                        Console.WriteLine("Contact deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Delete cancelled.");
                    }

                    Console.WriteLine("\nPress any key to return...");
                    Console.ReadKey(true);
                    break;

                case "5":
                    Console.Clear();
                    programRunning = false;
                    break;

                default:
                    Console.WriteLine("Must input valid choice");
                    Console.ReadKey(true);
                    break;
            }
        }
    }
}