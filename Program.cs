using System.Reflection;

string file = "tickets.csv";
string choice;

do
{
    Console.WriteLine("1) Read all tickets.");
    Console.WriteLine("2) Add a ticket to file.");
    Console.WriteLine("Enter any other key to exit.");
    // input response
    choice = Console.ReadLine();

    if (choice == "1")
    {
        // read data from file
        if (File.Exists(file))
        {
            StreamReader sr = new StreamReader(file);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                // convert string to array
                string[] tickArr = line.Split(',');
                // display array data
                Console.WriteLine(
                    "ID: {0}, Summary: {1}, Status: {2}, Priority: {3}, Submitter: {4}, Assigned: {5}, Watching {6}",
                    tickArr[0], tickArr[1], tickArr[2], tickArr[3], tickArr[4], tickArr[5], tickArr[6]
                );
            }
            sr.Close();
        }
        else
        {
            Console.WriteLine("File does not exist");
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

            Console.WriteLine("Enter the ticket summary.");
            string sum = Console.ReadLine();

            Console.WriteLine("Enter the ticket status.");
            string status = Console.ReadLine();

            Console.WriteLine("Enter the ticket priority.");
            string priority = Console.ReadLine();

            Console.WriteLine("Enter the person submitting the ticket.");
            string submit = Console.ReadLine();

            Console.WriteLine("Enter the person assigning the ticket.");
            string assign = Console.ReadLine();

            Console.WriteLine("Enter the people being watched (separated by | Ex: John Doe|Jane Doe).");
            string watch = Console.ReadLine();

            Ticket ticket = new Ticket
            {
                summary = sum,
                status = status,
                priority = priority,
                submitter = submit,
                assigner = assign,
                watched = watch
            };

            // sw.Write("{0},{1},{2},{3},{4},{5},{6}", tickID, sum, status, priority, submit, assign, watch);
        }
        sw.Close();
    }
} while (choice == "1" || choice == "2");