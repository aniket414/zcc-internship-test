using System;
namespace Zendesk.Ticket.Viewer.Service
{
    public class GetTicketResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Id { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime UpdatedAtUtc { get; set; }
    }
}
