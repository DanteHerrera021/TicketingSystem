using System.Reflection;

string file = Directory.GetCurrentDirectory() + "\\tickets.csv";
string choice;

TicketAdd add = new TicketAdd(file);

do
{
    Console.WriteLine("1) Read all tickets.");
    Console.WriteLine("2) Add a ticket to file.");
    Console.WriteLine("Enter any other key to exit.");
    // input response
    choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.WriteLine();
        Console.WriteLine("--- ALL AVAILABLE TICKETS ---");
        Console.WriteLine();
        foreach (Ticket i in add.tickets)
        {
            Console.WriteLine(i.Display());
            Console.WriteLine();
        }
    }
    else if (choice == "2")
    {
        StreamWriter sw = File.AppendText(file);

        for (int i = 0; i < 7; i++)
        {
            Console.WriteLine("Add a new ticket (Y/N)?");
            string resp = Console.ReadLine().ToUpper();
            if (resp != "Y") { break; }
            sw.WriteLine();

            Ticket ticket = new Ticket();

            Console.WriteLine("Enter the ticket summary.");
            ticket.summary = Console.ReadLine();

            Console.WriteLine("Enter the ticket status.");
            ticket.status = Console.ReadLine();

            Console.WriteLine("Enter the ticket priority.");
            ticket.priority = Console.ReadLine();

            Console.WriteLine("Enter the person submitting the ticket.");
            ticket.submitter = Console.ReadLine();

            Console.WriteLine("Enter the person assigning the ticket.");
            ticket.assigner = Console.ReadLine();

            Console.WriteLine("Enter the people being watched (separated by | Ex: John Doe|Jane Doe).");
            ticket.watched = Console.ReadLine();

            // sw.Write();
        }
        sw.Close();
    }
    else if (choice == "3")
    {
        // TESTING OPTION
    }
} while (choice == "1" || choice == "2" || choice == "3");