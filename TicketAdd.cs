public class TicketAdd
{
    public string filePath { get; set; }
    public List<Ticket> tickets { get; set; }
    public TicketAdd(string ticketFilePath)
    {
        filePath = ticketFilePath;

        tickets = new List<Ticket>();

        StreamReader sr = new StreamReader(filePath);
        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();

            string[] tickArr = line.Split(',');

            // Console.WriteLine(tickArr[4]);

            Ticket ticket = new Ticket
            {
                tickID = tickArr[0],
                summary = tickArr[1],
                status = tickArr[2],
                priority = tickArr[3],
                submitter = tickArr[4],
                assigner = tickArr[5],
                watched = tickArr[6]
            };

            tickets.Add(ticket);
        }
        sr.Close();

    }

    public void addBug(BugTicket ticket)
    {
        StreamWriter sw = new StreamWriter(filePath, true);
        sw.WriteLine();
        sw.Write($"{ticket.tickID},{ticket.summary},{ticket.status},{ticket.priority},{ticket.submitter},{ticket.assigner},{ticket.watched},{ticket.severity}");
        sw.Close();

        tickets.Add(ticket);
    }

    public void addEnhancement(EnhancementTicket ticket)
    {
        StreamWriter sw = new StreamWriter(filePath, true);
        sw.WriteLine();
        sw.Write($"{ticket.tickID},{ticket.summary},{ticket.status},{ticket.priority},{ticket.submitter},{ticket.assigner},{ticket.watched},{ticket.software},{ticket.cost},{ticket.reason},{ticket.estimate}");
        sw.Close();

        tickets.Add(ticket);
    }

    public void addTask(TaskTicket ticket)
    {
        StreamWriter sw = new StreamWriter(filePath, true);
        sw.WriteLine();
        sw.Write($"{ticket.tickID},{ticket.summary},{ticket.status},{ticket.priority},{ticket.submitter},{ticket.assigner},{ticket.watched},{ticket.projectName},{ticket.dueDate}");
        sw.Close();

        tickets.Add(ticket);
    }
}