using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetWorth.Domain.Entities;
using NetWorth.Persistence;

namespace NetWorth.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NWFactorsController : ControllerBase
    {
        private readonly NetWorthContext _context;

        public NWFactorsController(NetWorthContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<NWFactor>> GetAll()
        {
            return _context.Factors.ToList();
        }

        [HttpGet("{id}", Name="GetNWFactor")]
        public ActionResult<NWFactor> GetById(long id)
        {
            var factor = _context.Factors.Find(id);
            if(factor == null)
            {
                return NotFound();
            }
            
            return factor;
        }

        [HttpPost]
        public IActionResult Create(NWFactor factor)
        {
            _context.Factors.Add(factor);
            _context.SaveChanges();

            return CreatedAtRoute("GetNWFactor", new { id = factor.Id }, factor);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, NWFactor factor)
        {
            var result = _context.Factors.Find(id);
            if (result == null)
            {
                return NotFound();
            }

            result.Id = factor.Id;
            result.Name = factor.Name;
            result.CurrentValue = factor.CurrentValue;
            result.HasInterest = factor.HasInterest;
            result.InterestRate = factor.InterestRate;
            result.Type = factor.Type;
            result.UserID = factor.UserID;

            _context.Factors.Update(result);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var result = _context.Factors.Find(id);
            if (result == null)
            {
                return NotFound();
            }

            _context.Factors.Remove(result);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
