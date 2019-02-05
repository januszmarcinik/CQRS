using System;
using System.Collections.Generic;
using CQRS.Core;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Api.Controllers
{
    [Route("api/football")]
    [ApiController]
    public class FootballController : ControllerBase
    {
        private readonly IFootballService service;

        public FootballController(IFootballService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Returns teams with current results
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Team>), 200)]
        public IActionResult Get()
            => Ok(service.GetTeams());

        /// <summary>
        /// Inserts match result to given teams
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /football
        ///     {
        ///         "homeTeamName": "Bayern",
        ///         "homeTeamGoals": 3,
        ///         "awayTeamName": "Borussia",
        ///         "awayTeamGoals": 1
        ///     }
        /// 
        /// </remarks>
        /// <param name="matchResult"></param>
        /// <returns></returns>
        /// <response code="202">Match result correctly inserted</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Given team was not found</response>
        [HttpPost]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Post([FromBody] MatchResult matchResult)
        {
            try
            {
                service.InsertResult(matchResult);
                return Accepted();
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
