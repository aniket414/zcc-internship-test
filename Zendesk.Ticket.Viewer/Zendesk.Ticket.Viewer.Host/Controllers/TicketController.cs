using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Zendesk.Ticket.Viewer.Service;

namespace Zendesk.Ticket.Viewer.Host
{
    [ApiController]
    [Route("api/v1.0")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        
        private readonly ILogger<TicketController> _logger;

        public TicketController(ITicketService ticketService, ILogger<TicketController> logger)
        {
            _ticketService = ticketService;
            _logger = logger;
        }

        [HttpGet]
        [Route("tickets")]
        public async Task<IActionResult> GetAllAsync()
        {
            var queryString = Request.QueryString.Value;
            var pagingInfoRequest = new PagingInfoRequest(queryString);

            var response = await _ticketService.GetAllTicketsAsync(pagingInfoRequest.PageNumber, pagingInfoRequest.PageSize);
            return Ok(response.ToDataContract(pagingInfoRequest));
        }
    }
}
