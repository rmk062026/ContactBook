using ContactBook.Models;
using ContactBook.Service;
using ContactBook.Helpers;
using Microsoft.EntityFrameworkCore;
using ContactBook.Data;

namespace ContactBook;

class Program
{
    static void Main(string[] args)
    {
        bool programRunning = true;
        string connectionString =
            "Server=localhost;Database=ContactBook;Trusted_Connection=True;TrustServerCertificate=True;";

        DbContextOptions<ContactDbContext> options =
            new DbContextOptionsBuilder<ContactDbContext>()
            .UseSqlServer(connectionString)
            .Options;

        using ContactDbContext dbContext = new ContactDbContext(options);
        ContactRepository contactRepository = new ContactRepository(dbContext);
        ContactService contactService = new ContactService(contactRepository);

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

                    string name = InputHelper.ReadRequiredString("Enter name: ");
                    string phoneNumber = InputHelper.ReadPhoneNumber();
                    string address = InputHelper.ReadRequiredString("Enter address: ");
                    string email = InputHelper.ReadEmail();
                    DateOnly birthday = InputHelper.ReadBirthday();

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
                    Console.WriteLine($"Contact saved with ID: {contact.Id}");

                    Console.WriteLine();

                    ContactDisplayHelper.ShowContact(contact);

                    InputHelper.WaitForKey();
                    break;

                case "2":
                    Console.Clear();
                    IEnumerable<Contact> allContacts = contactService.GetAllContacts();

                    foreach (Contact currentContact in allContacts)
                    {
                        Console.WriteLine();

                        ContactDisplayHelper.ShowContact(currentContact);

                        Console.WriteLine("-----------------------------");
                    }

                    InputHelper.WaitForKey();
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("Enter name to search: ");
                    string search = Console.ReadLine() ?? "";

                    IEnumerable<Contact> searchResults = contactService.SearchContacts(search);

                    foreach (Contact contactSearch in searchResults)
                    {
                        ContactDisplayHelper.ShowContact(contactSearch);
                        Console.WriteLine("-----------------------------");
                    }

                    InputHelper.WaitForKey();
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
                        Console.ReadKey(true);
                        break;
                    }

                    Contact? contactToDelete = contactService.GetContactById(id);

                    if (contactToDelete == null)
                    {
                        Console.WriteLine("Contact not found.");
                        Console.ReadKey(true);
                        break;
                    }

                    Console.WriteLine("Contact found:");
                    Console.WriteLine();
                    ContactDisplayHelper.ShowContact(contactToDelete);
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

                    InputHelper.WaitForKey();
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