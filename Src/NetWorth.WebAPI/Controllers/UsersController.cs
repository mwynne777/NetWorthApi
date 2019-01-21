using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using NetWorth.Application.Users.Queries.GetUsersList;
using NetWorth.Application.Users.Queries.GetUserDetail;
using NetWorth.Application.Users.Commands.UpdateUser;
using NetWorth.Application.Users.Commands.CreateUser;
using NetWorth.Application.Users.Commands.DeleteUser;
using System.Net;
using System;

namespace NetWorth.WebAPI.Controllers
{
    public class UsersController : BaseController
    {
        // GET api/users
        [HttpGet]
        public async Task<ActionResult<UsersListViewModel>> GetAll()
        {
            System.Diagnostics.Debug.WriteLine("Get all users");
            return Ok(await Mediator.Send(new GetUsersListQuery()));
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetailModel>> Get(long id)
        {
            return Ok(await Mediator.Send(new GetUserDetailQuery { Id = id }));
        }

        // POST api/users
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Create([FromBody]CreateUserCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Update(long id, [FromBody]UpdateUserCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(long id)
        {
            await Mediator.Send(new DeleteUserCommand { Id = id });

            return NoContent();
        }
    }
}