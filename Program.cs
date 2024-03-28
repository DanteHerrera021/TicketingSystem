﻿using System.Reflection;
using NLog;

string path = Directory.GetCurrentDirectory() + "\\nlog.config";
string file = Directory.GetCurrentDirectory() + "\\tickets.csv";

var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
logger.Info("Program started");

string choice;

TicketAdd add = new TicketAdd(file);

logger.Info($"{add.bugTickets.Count + add.enhancementTickets.Count + add.taskTickets.Count} ticket(s) on file");

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

        foreach (Ticket i in add.bugTickets)
        {
            Console.WriteLine(i.Display());
            Console.WriteLine();
        }

        foreach (Ticket i in add.enhancementTickets)
        {
            Console.WriteLine(i.Display());
            Console.WriteLine();
        }

        foreach (Ticket i in add.taskTickets)
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

            Console.WriteLine("Type '1' for bugs, type '2' for enhancements, or type '3' for tasks");
            string type = Console.ReadLine();

            if (type == "1")
            {
                BugTicket ticket = new BugTicket
                {
                    tickID = (int.Parse(add.bugTickets[add.bugTickets.Count - 1].tickID) + 1).ToString()
                };

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

                Console.WriteLine("Enter the severity of the bug");
                ticket.severity = Console.ReadLine();

                add.addBug(ticket);
            }
            else if (type == "2")
            {
                EnhancementTicket ticket = new EnhancementTicket
                {
                    tickID = (int.Parse(add.enhancementTickets[add.enhancementTickets.Count - 1].tickID) + 1).ToString()
                };

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

                Console.WriteLine("Enter the software is needed");
                ticket.software = Console.ReadLine();

                Console.WriteLine("Enter the cost of the enhancement");
                ticket.cost = Console.ReadLine();

                Console.WriteLine("Enter the reason for the ticket");
                ticket.reason = Console.ReadLine();

                Console.WriteLine("Enter the estimate of the enhancement");
                ticket.estimate = Console.ReadLine();

                add.addEnhancement(ticket);
            }
            else if (type == "3")
            {
                TaskTicket ticket = new TaskTicket
                {
                    tickID = (int.Parse(add.taskTickets[add.taskTickets.Count - 1].tickID) + 1).ToString()
                };

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

                Console.WriteLine("Enter the project name");
                ticket.projectName = Console.ReadLine();

                Console.WriteLine("Enter the due date of the project");
                ticket.dueDate = Console.ReadLine();

                add.addTask(ticket);
            }

        }
    }
} while (choice == "1" || choice == "2" || choice == "3");
logger.Info("Program ended");