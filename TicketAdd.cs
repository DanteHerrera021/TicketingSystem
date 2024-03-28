public class TicketAdd
{
    public string bugFilePath { get; set; }
    public string enhancementFilePath { get; set; }
    public string taskFilePath { get; set; }
    public List<BugTicket> bugTickets { get; set; }
    public List<EnhancementTicket> enhancementTickets { get; set; }
    public List<TaskTicket> taskTickets { get; set; }

    public TicketAdd(string bugTicketFP, string enhancementTicketFP, string taskTicketFP)
    {
        bugFilePath = bugTicketFP;
        enhancementFilePath = enhancementTicketFP;
        taskFilePath = taskTicketFP;

        bugTickets = new List<BugTicket>();
        enhancementTickets = new List<EnhancementTicket>();
        taskTickets = new List<TaskTicket>();

        StreamReader sr = new StreamReader(bugFilePath);
        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();

            string[] tickArr = line.Split(',');

            BugTicket ticket = new BugTicket
            {
                tickID = tickArr[0],
                summary = tickArr[1],
                status = tickArr[2],
                priority = tickArr[3],
                submitter = tickArr[4],
                assigner = tickArr[5],
                watched = tickArr[6],
                severity = tickArr[7]
            };
            bugTickets.Add(ticket);
        }
        sr.Close();

        sr = new StreamReader(enhancementFilePath);
        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();

            string[] tickArr = line.Split(',');

            EnhancementTicket ticket = new EnhancementTicket
            {
                tickID = tickArr[0],
                summary = tickArr[1],
                status = tickArr[2],
                priority = tickArr[3],
                submitter = tickArr[4],
                assigner = tickArr[5],
                watched = tickArr[6],
                software = tickArr[7],
                cost = tickArr[8],
                reason = tickArr[9],
                estimate = tickArr[10]
            };
            enhancementTickets.Add(ticket);
        }
        sr.Close();

        sr = new StreamReader(taskFilePath);
        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();

            string[] tickArr = line.Split(',');

            TaskTicket ticket = new TaskTicket
            {
                tickID = tickArr[0],
                summary = tickArr[1],
                status = tickArr[2],
                priority = tickArr[3],
                submitter = tickArr[4],
                assigner = tickArr[5],
                watched = tickArr[6],
                projectName = tickArr[7],
                dueDate = tickArr[8]
            };
            taskTickets.Add(ticket);
        }
        sr.Close();

    }

    public void addBug(BugTicket ticket)
    {
        StreamWriter sw = new StreamWriter(bugFilePath, true);
        sw.WriteLine();
        sw.Write($"{ticket.tickID},{ticket.summary},{ticket.status},{ticket.priority},{ticket.submitter},{ticket.assigner},{ticket.watched},{ticket.severity}");
        sw.Close();

        bugTickets.Add(ticket);
    }

    public void addEnhancement(EnhancementTicket ticket)
    {
        StreamWriter sw = new StreamWriter(enhancementFilePath, true);
        sw.WriteLine();
        sw.Write($"{ticket.tickID},{ticket.summary},{ticket.status},{ticket.priority},{ticket.submitter},{ticket.assigner},{ticket.watched},{ticket.software},{ticket.cost},{ticket.reason},{ticket.estimate}");
        sw.Close();

        enhancementTickets.Add(ticket);
    }

    public void addTask(TaskTicket ticket)
    {
        StreamWriter sw = new StreamWriter(taskFilePath, true);
        sw.WriteLine();
        sw.Write($"{ticket.tickID},{ticket.summary},{ticket.status},{ticket.priority},{ticket.submitter},{ticket.assigner},{ticket.watched},{ticket.projectName},{ticket.dueDate}");
        sw.Close();

        taskTickets.Add(ticket);
    }
}