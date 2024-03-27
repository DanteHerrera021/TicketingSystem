public class TaskTicket : Ticket
{
    public string projectName { get; set; }
    public string dueDate { get; set; }

    public override string Display()
    {
        return $"ID: {tickID}\nSummary: {summary}\nStatus: {status}, Priority: {priority}\nSubmitter: {submitter}, Assigned: {assigner}\nWatched: {watched}\nProject name: {projectName}\nProject Due Date: {dueDate}\n";
    }
}