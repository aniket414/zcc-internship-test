using System;
using FluentAssertions;
using Xunit;
using Zendesk.Ticket.Viewer.Service;

namespace Zendesk.Ticket.Viewer.UnitTests
{
    public class TicketDataContractTranslatorTests
    {
        [Fact]
        public void Given_TicketTranslator_When_ValidTicketResponse_Then_ShouldTranslateToModelSuccessfully()
        {
            //build
            var ticket = ObjectBuilder.TicketBuilder()
                .SetURL("test.com")
                .SetId(1)
                .Build();

            //act 
            var response = ticket.ToGetTicketsDataContract();

            //assert
            response.Should().NotBeNull();
            response.URL.Should().Be(ticket.URL);
            response.Id.Should().Be(ticket.Id);
        }

        [Fact]
        public void Given_TicketTranslator_When_TicketResponseIsNull_Then_ShouldTranslateToModelSuccessfully_And_ReturnNull()
        {
            //build
            Domain.Ticket ticket = null;

            //act 
            var response = ticket.ToGetTicketsDataContract();

            //assert
            response.Should().BeNull();
        }
    }
}
