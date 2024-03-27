public class BugTicket : Ticket
{
    public string severity { get; set; }

    public override string Display()
    {
        return $"ID: {tickID}\nSummary: {summary}\nStatus: {status}, Priority: {priority}\nSubmitter: {submitter}, Assigned: {assigner}\nWatched: {watched}\nSeverity of the bug: {severity}\n";
    }
}