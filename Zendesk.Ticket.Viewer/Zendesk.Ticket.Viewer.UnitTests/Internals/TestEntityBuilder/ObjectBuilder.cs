using System;
namespace Zendesk.Ticket.Viewer.UnitTests
{
    internal class ObjectBuilder
    {
        internal static TicketBuilder TicketBuilder()
        {
            return new TicketBuilder();
        }

        internal static TicketServiceBuilder TicketServiceBuilder()
        {
            return new TicketServiceBuilder();
        }

        internal static PagingInfoBuilder PagingInfoBuilder()
        {
            return new PagingInfoBuilder();
        }
    }
}
