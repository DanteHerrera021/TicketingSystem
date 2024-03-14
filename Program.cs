using System.Reflection;
using NLog;

string path = Directory.GetCurrentDirectory() + "\\nlog.config";
string file = Directory.GetCurrentDirectory() + "\\tickets.csv";

var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
logger.Info("Program started");

string choice;

TicketAdd add = new TicketAdd(file);

logger.Info($"{add.tickets.Count} ticket(s) on file");

do
{
    Console.WriteLine("1) Read all tickets.");
    Console.WriteLine("2) Add a ticket to file.");
    Console.WriteLine("Enter any other key to exit.");

    choice = Console.ReadLine();

    logger.Info("User choice: {Choice}", choice);

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
        while (true)
        {
            Console.WriteLine("Add a new ticket (Y/N)?");
            string resp = Console.ReadLine().ToUpper();
            if (resp != "Y") { break; }

            Ticket ticket = new Ticket();

            ticket.tickID = (int.Parse(add.tickets[add.tickets.Count - 1].tickID) + 1).ToString();

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

            add.addTicket(ticket);
        }
    }
} while (choice == "1" || choice == "2" || choice == "3");
logger.Info("Program ended");