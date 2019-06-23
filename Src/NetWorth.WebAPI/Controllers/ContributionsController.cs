using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetWorth.Application.Contributions.Commands.CreateContribution;
using NetWorth.Application.Contributions.Commands.DeleteContribution;
using NetWorth.Application.Contributions.Commands.UpdateContribution;
using NetWorth.Application.Contributions.Queries.GetAllContributions;
using NetWorth.Application.Contributions.Queries.GetContribution;

namespace NetWorth.WebAPI.Controllers
{
    public class ContributionsController : BaseController
    {
        // GET: api/contributions
        [HttpGet]
        public async Task<ActionResult<ContributionsListViewModel>> GetAll()
        {
            Console.WriteLine("Getting all factors");
            return Ok(await Mediator.Send(new GetAllContributionsQuery()));
        }

        // GET: api/contributions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContributionViewModel>> Get(long id)
        {
            return Ok(await Mediator.Send(new GetContributionQuery { Id = id}));
        }

        // POST: api/contributions
        [HttpPost]
        public async Task<ActionResult<long>> Create([FromBody] CreateContributionCommand command)
        {
            var productId = await Mediator.Send(command);

            return Ok(productId);
        }

        // PUT: api/contributions/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ContributionDto>> Update(
            [FromRoute] long id,
            [FromBody] UpdateContributionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE: api/contributions/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(long id)
        {
            await Mediator.Send(new DeleteContributionCommand { Id = id });

            return NoContent();
        }
    }
}