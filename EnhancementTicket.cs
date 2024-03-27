public class EnhancementTicket : Ticket
{
    public string software { get; set; }
    // no mathematical operators are done, so cost can be a string
    public string cost { get; set; }
    public string reason { get; set; }
    public string estimate { get; set; }
}