using System;
using System.Collections.Generic;

namespace Zendesk.Ticket.Viewer.Data
{
    public class Tickets
    {
        public string __id { get; set; }
        public string __type { get; set; }
        public string __userId { get; set; }
    }

    public class TicketResponse
    {
        public List<Tickets> tickets { get; set; }
    }
}
