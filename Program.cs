namespace ContactBook;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        bool programRunning = true;
        while (programRunning)
        {
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
                    Console.WriteLine("Add new contact site");
                    break;

                case "2":
                    Console.WriteLine("Show all contacts site");
                    break;
                case "3":
                    Console.WriteLine("Search for contact site");
                    break;
                case "4":
                    Console.WriteLine("Delete contact site");
                    break;
                case "5":
                    programRunning = false;
                    break;

                default:
                    Console.WriteLine("Must input valid choice");
                    break;
            }
        }
    }
}
