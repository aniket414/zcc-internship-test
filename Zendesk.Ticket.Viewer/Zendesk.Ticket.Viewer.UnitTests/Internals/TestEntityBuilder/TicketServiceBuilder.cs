using System;
using Moq;
using Zendesk.Ticket.Viewer.Domain;
using Zendesk.Ticket.Viewer.Service;

namespace Zendesk.Ticket.Viewer.UnitTests
{
    internal class TicketServiceBuilder
    {
        private Mock<IDataAdapter> _storeFactory;

        public TicketServiceBuilder()
        {
            _storeFactory = new Mock<IDataAdapter>();
        }

        internal TicketServiceBuilder SetDataStore(Mock<IDataAdapter> store)
        {
            _storeFactory = store;
            return this;
        }

        internal TicketService Build()
        {
            return new TicketService(_storeFactory.Object);
        }
    }
}
