using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;

namespace Zendesk.Ticket.Viewer.UnitTests
{
    public class TicketServiceTests
    {
        [Fact]
        public async Task Given_GetAllTicketsRequest_When_Tickets_Exist_Then_ShouldReturnTickets_AccordingToPaging()
        {
            //build
            var firstTicket = ObjectBuilder.TicketBuilder()
                .SetId(414)
                .SetURL("url.com")
                .Build();
            var secondTicket = ObjectBuilder.TicketBuilder().Build();
            var thirdTicket = ObjectBuilder.TicketBuilder().Build();
            var fourthTicket = ObjectBuilder.TicketBuilder().Build();
            var fifthTicket = ObjectBuilder.TicketBuilder().Build();
            var sixthTicket = ObjectBuilder.TicketBuilder().Build();

            List<Domain.Ticket> tickets = new List<Domain.Ticket>();
            tickets.Add(firstTicket);
            tickets.Add(secondTicket);
            tickets.Add(thirdTicket);
            tickets.Add(fourthTicket);
            tickets.Add(fifthTicket);
            tickets.Add(sixthTicket);

            var zendeskDataStore = MockBuilder.MockDataAdapter()
                .MockGetTicketsAsync(tickets);

            var service = ObjectBuilder.TicketServiceBuilder()
                .SetDataStore(zendeskDataStore)
                .Build();

            //act
            var response = await service.GetAllTicketsAsync(1, 3);

            //assert
            response.Should().NotBeNull();
            response.Count.Should().Be(3);
            response.TotalRecords.Should().Be(6);

            //verify
            zendeskDataStore.VerifyGetTicketsAsync(Times.Once);
        }

        [Fact]
        public async Task Given_GetAllTicketsRequest_When_Tickets_DoesNotExist_Then_ShouldReturnNull()
        {
            //build
            var zendeskDataStore = MockBuilder.MockDataAdapter()
                .MockGetTicketsAsync(new List<Domain.Ticket>() { });

            var service = ObjectBuilder.TicketServiceBuilder()
                .SetDataStore(zendeskDataStore)
                .Build();

            //act
            var response = await service.GetAllTicketsAsync(1, 3);

            //assert
            response.Should().BeNull();

            //verify
            zendeskDataStore.VerifyGetTicketsAsync(Times.Once);
        }

        [Fact]
        public void Given_GetAllTicketsRequest_When_DataLayer_ThrowsExceptions_Then_ShouldThrowError()
        {
            //build
            var zendeskDataStore = MockBuilder.MockDataAdapter()
                .MockGetTicketsAsync(new Exception());

            var service = ObjectBuilder.TicketServiceBuilder()
                .SetDataStore(zendeskDataStore)
                .Build();

            //act
            Func<Task> response = async () => await service.GetAllTicketsAsync(1, 3);

            //assert
            response.Should().ThrowAsync<Exception>();

            //verify
            zendeskDataStore.VerifyGetTicketsAsync(Times.Once);
        }
    }
}
