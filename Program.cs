namespace ContactBook;

class Program
{
    static void Main(string[] args)
    {
        bool programRunning = true;
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
                    Console.WriteLine("Add new contact site");

                    Console.WriteLine("\nPress any key to return...");
                    Console.ReadKey(true);
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("Show all contacts site");

                    Console.WriteLine("\nPress any key to return...");
                    Console.ReadKey(true);
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Search for contact site");

                    Console.WriteLine("\nPress any key to return...");
                    Console.ReadKey(true);
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("Delete contact site");

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
