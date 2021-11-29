using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Zendesk.Ticket.Viewer.Domain;

namespace Zendesk.Ticket.Viewer.UnitTests
{
    internal class MockDataAdapter : Mock<IDataAdapter>
    {
        internal MockDataAdapter MockGetTicketsAsync(List<Domain.Ticket> output)
        {
            Setup(x => x.GetTicketsAsync())
                .ReturnsAsync(output)
                .Verifiable();

            return this;
        }

        public MockDataAdapter MockGetTicketsAsync(Exception exception)
        {
            Setup(x => x.GetTicketsAsync())
                .ThrowsAsync(exception)
                .Verifiable();

            return this;
        }

        public MockDataAdapter VerifyGetTicketsAsync(Func<Times> times)
        {
            Verify(x => x.GetTicketsAsync(), times);
            return this;
        }
    }
}
