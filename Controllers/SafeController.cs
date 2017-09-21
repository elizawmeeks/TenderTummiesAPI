using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderTummiesAPI.Data;
using TenderTummiesAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TenderTummiesAPI.Controllers
{
    //Sets URL route to <websitename>/Safe
    [Route("[controller]")]
    //Creates a new Safe controller class that inherits methods from AspNetCore Controller class
    public class SafeController : Controller
    {
        //Sets up an empty variable _context that will  be a reference of the TenderTummiesAPI class
        private TenderTummiesAPIContext _context;
        //Contructor that instantiates a new Safe controller 
        //Sets _context equal to a new instance of our TenderTummiesAPI class
        public SafeController(TenderTummiesAPIContext ctx)
        {
            _context = ctx;
        }

        // GET METHOD
        //http://localhost:5000/Safe/{childID} will return a list of all safes for a certain child. 
        [HttpGet("{child}", Name = "GetChildsSafes")]
        
        public IActionResult GetByChild([FromRoute] int child)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            IQueryable<object> safes = _context.Safe.Include("Food").Where(c => c.ChildID == child);
            
            if (safes == null)
            {
                return NotFound();
            }
            
            return Ok(safes);

        }

        // GET Single Safe
         //http://localhost:5000/Safe/id/{id} will return info on a single Safe based on ID 
        [HttpGet("id/{id}", Name = "GetSingleSafe")]
        
        public IActionResult GetById([FromRoute] int id)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                
                Safe safe = _context.Safe.Include("Food").Single(m => m.SafeID == id);

                if (safe == null)
                {
                    return NotFound();
                }
                
                return Ok(safe);
            }
            
            catch (System.InvalidOperationException ex)
            {
                return NotFound(ex);
            }
        }

        // POST
        // //http://localhost:5000/Safe/ will post new Safe to the DB 
        [HttpPost]
        //takes the format of Safe type as a JSON format and adds to database. 
        public IActionResult Post([FromBody] Safe newSafe)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try{
                Safe exists = _context.Safe.Single(s => s.ChildID == newSafe.ChildID && s.FoodID == newSafe.FoodID);
            }catch{
                
                _context.Safe.Add(newSafe);
                
                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    if (SafeExists(newSafe.SafeID))
                    {
                        return new StatusCodeResult(StatusCodes.Status409Conflict);
                    }
                    else
                    {
                        throw(ex);
                    }
                }
                
                return CreatedAtRoute("GetSingleSafe", new { id = newSafe.SafeID }, newSafe);
            }

            return BadRequest("An entry for this safe already exists for this child!");
            
        }


        //Helper method to check to see if a SafeID is already in the system
        private bool SafeExists(int safeID)
        {
          return _context.Safe.Any(e => e.SafeID == safeID);
        }

        // DELETE url/Safe/id/5
        // Deletes something based on an id.
        [HttpDelete("id/{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Safe singleSafe = _context.Safe.Single(m => m.SafeID == id);
            if (singleSafe == null)
            {
                return NotFound();
            }

            _context.Safe.Remove(singleSafe);
            _context.SaveChanges();

            return Ok(singleSafe);
        }

    }
}