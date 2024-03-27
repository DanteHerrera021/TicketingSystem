public class EnhancementTicket : Ticket
{
    public string software { get; set; }
    // no mathematical operators are done, so cost can be a string
    public string cost { get; set; }
    public string reason { get; set; }
    public string estimate { get; set; }

    public override string Display()
    {
        return $"ID: {tickID}\nSummary: {summary}\nStatus: {status}, Priority: {priority}\nSubmitter: {submitter}, Assigned: {assigner}\nWatched: {watched}\nSoftware Needed: {software}\nCost: {cost}\nReason: {reason}\nEstimate: {estimate}\n";
    }
}