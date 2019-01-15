using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetWorth.Application.Factors.Commands.CreateFactor;
using NetWorth.Application.Factors.Commands.DeleteFactor;
using NetWorth.Application.Factors.Commands.UpdateFactor;
using NetWorth.Application.Factors.Queries.GetAllFactors;
using NetWorth.Application.Factors.Queries.GetFactor;

namespace NetWorth.WebAPI.Controllers
{
    public class FactorsController : BaseController
    {
        // GET: api/factors
        [HttpGet]
        public async Task<ActionResult<FactorsListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllFactorsQuery()));
        }

        // GET: api/factors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FactorViewModel>> Get(long id)
        {
            return Ok(await Mediator.Send(new GetFactorQuery { Id = id}));
        }

        // POST: api/factors
        [HttpPost]
        public async Task<ActionResult<long>> Create([FromBody] CreateFactorCommand command)
        {
            var productId = await Mediator.Send(command);

            return Ok(productId);
        }

        // PUT: api/factors/5
        [HttpPut("{id}")]
        public async Task<ActionResult<FactorDto>> Update(
            [FromRoute] long id,
            [FromBody] UpdateFactorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE: api/factors/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(long id)
        {
            await Mediator.Send(new DeleteFactorCommand { Id = id });

            return NoContent();
        }
    }
}