using System;
using System.Collections.Generic;

namespace Zendesk.Ticket.Viewer.Service
{
    public class GetAllTicketsResponse
    {
        public List<GetTicketResponse> Tickets { get; } = new List<GetTicketResponse>();

        public PagingInfo PagingInfo { get; set; }
    }
}
