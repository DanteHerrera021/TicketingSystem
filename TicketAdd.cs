public class TicketAdd
{
    public string filePath { get; set; }
    public TicketAdd(string ticketFilePath)
    {
        filePath = ticketFilePath;
    }
}