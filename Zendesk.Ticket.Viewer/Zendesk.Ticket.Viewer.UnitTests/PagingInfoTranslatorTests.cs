using System;
using FluentAssertions;
using Xunit;
using Zendesk.Ticket.Viewer.Service;

namespace Zendesk.Ticket.Viewer.UnitTests
{
    public class PagingInfoTranslatorTests
    {
        [Fact]
        public void Given_PagingInfoTranslator_When_InputIsNull_Then_ShouldReturnNullResponse()
        {
            //build
            PagingInfoRequest pagingInfoRequest = null;
            var totalRecords = 5;

            //act 
            var response = pagingInfoRequest.ToDataContract(totalRecords);

            //assert
            response.Should().BeNull();
        }

        [Fact]
        public void Given_PagingInfoResponseTranslator_When_ValidPagingInfo_Then_ShouldTranslateToModelSuccessfully()
        {
            //build
            var pagingInfoRequest = ObjectBuilder.PagingInfoBuilder().Build();
            var totalRecords = 5;

            //act 
            var response = pagingInfoRequest.ToDataContract(totalRecords);

            //assert
            response.Should().NotBeNull();
            response.PageNumber.Should().Be(pagingInfoRequest.PageNumber);
            response.PageSize.Should().Be(pagingInfoRequest.PageSize);
            response.TotalRecords.Should().Be(totalRecords);
        }
    }
}
