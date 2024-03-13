public class Ticket
{
    public string tickID { get; set; }
    public string summary { get; set; }
    public string status { get; set; }
    public string priority { get; set; }
    public string submitter { get; set; }
    public string assigner { get; set; }
    public string watched { get; set; }

    public string Display()
    {
        return $"ID: {tickID}\nSummary: {summary}\nStatus: {status}, Priority: {priority}\nSubmitter: {submitter}, Assigned: {assigner}\nWatched: {watched}";
    }

}
