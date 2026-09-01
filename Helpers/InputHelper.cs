using System.Net.Mail;

namespace ContactBook.Helpers;

public static class InputHelper
{
    public static string ReadRequiredString(string message)
    {
        while (true)
        {
            Console.WriteLine(message);

            string input = Console.ReadLine()?.Trim() ?? "";

            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            Console.WriteLine("This field cannot be empty.");
        }
    }

    public static string ReadPhoneNumber()
    {
        while (true)
        {
            Console.WriteLine("Enter phone number");
            string phoneNumber = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                Console.WriteLine("Phone number cannot be empty.");
                continue;
            }

            bool validPhoneNumber = phoneNumber.All(character =>
            char.IsDigit(character) ||
            character == '+' ||
            character == ' ');

            if (validPhoneNumber)
            {
                return phoneNumber;
            }
            Console.WriteLine("Phone number can only contain numbers, + and spaces.");
        }
    }

    public static string ReadEmail()
    {
        while (true)
        {
            Console.WriteLine("Enter email: ");
            string email = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Email cannot be empty.");
                continue;
            }

            try
            {
                MailAddress mailAddress = new MailAddress(email);
                return email;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid email address.");
            }
        }
    }

    public static DateOnly ReadBirthday()
    {
        while (true)
        {
            Console.Write("Enter birthday (dd.MM.yyyy): ");
            string birthdayInput = Console.ReadLine()?.Trim() ?? "";

            if (DateOnly.TryParse(birthdayInput, out DateOnly birthday))
            {
                return birthday;
            }

            Console.WriteLine("Invalid date. Please try again.");
        }
    }
}