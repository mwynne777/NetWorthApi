using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetWorth.WebAPI.Models;

namespace NetWorth.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly NetWorthContext _context;

        public UsersController(NetWorthContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return _context.Users.ToList();
        }

        [HttpGet("{id}", Name="GetUser")]
        public ActionResult<User> GetById(long id)
        {
            var user = _context.Users.Find(id);
            if(user == null)
            {
                return NotFound();
            }
            
            return user;
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, User user)
        {
            var result = _context.Users.Find(id);
            if (result == null)
            {
                return NotFound();
            }

            result.Id = user.Id;
            result.FirstName = user.FirstName;
            result.LastName = user.LastName;
            result.UserName = user.UserName;
            result.Password = user.Password;

            _context.Users.Update(result);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var result = _context.Users.Find(id);
            if (result == null)
            {
                return NotFound();
            }

            _context.Users.Remove(result);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
