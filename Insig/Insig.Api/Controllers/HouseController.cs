using EnsureThat;
using Insig.Common.Auth;
using Insig.Common.CQRS;
using Insig.PublishedLanguage.Commands;
using Insig.PublishedLanguage.Dtos;
using Insig.PublishedLanguage.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insig.Api.Controllers
{
    [Route("House")]
    [ApiController]
    public class HouseController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public HouseController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            EnsureArg.IsNotNull(queryDispatcher, nameof(queryDispatcher));
            EnsureArg.IsNotNull(commandDispatcher, nameof(commandDispatcher));

            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [Authorize(Policies.Consumer)]
        [HttpGet("houses")]
        public async Task<IActionResult> GetHouses([FromQuery] HouseParameter parameter)
        {
            List<HouseDTO> result = await _queryDispatcher.Dispatch(parameter);
            return Ok(result);
        }

        [Authorize(Policies.Consumer)]
        [HttpPost("houses")]
        public async Task<IActionResult> AddHouses([FromBody] AddHouseCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }
        [Authorize(Policies.Consumer)]
        [HttpPatch("houses")]
        public async Task<IActionResult> DeleteHouses([FromBody] DeleteHouseCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }
    }
}
