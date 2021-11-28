using System;
namespace Zendesk.Ticket.Viewer.Service
{
    public static class GetTicketsResponseTranslator
    {
        public static GetTicketResponse ToGetTicketsDataContract(this Ticket ticket)
        {
            if (ticket == null)
                return null;

            return new GetTicketResponse()
            {
                Name = ticket.Name,
                Status = ticket.ApplicationId
            };
        }
    }
}
