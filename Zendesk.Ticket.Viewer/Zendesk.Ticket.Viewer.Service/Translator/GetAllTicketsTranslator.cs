using System;
namespace Zendesk.Ticket.Viewer.Service
{
    public static class GetAllTicketsTranslator
    {
        private static readonly int _noRecords = 0;
        public static GetAllTicketsResponse ToDataContract(this PagedList<Ticket> tickets, PagingInfoRequest pagingInfoRequest)
        {
            if (tickets == null || tickets.Count == 0)
            {
                return new GetAllTicketsResponse()
                {
                    PagingInfo = pagingInfoRequest.ToDataContract(_noRecords)
                };
            }

            var response = new GetAllTicketsResponse()
            {
                PagingInfo = pagingInfoRequest.ToDataContract(tickets.TotalRecords)
            };

            foreach (var ticket in tickets)
            {
                response.Tickets.Add(ticket.ToGetTicketsDataContract());
            }
            return response;
        }
    }
}
