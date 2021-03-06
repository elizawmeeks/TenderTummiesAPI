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
    //Sets URL route to <websitename>/TrialEvent
    [Route("[controller]")]
    //Creates a new TrialEvent controller class that inherits methods from AspNetCore Controller class
    public class TrialEventController : Controller
    {
        
        private TenderTummiesAPIContext _context;
        
        public TrialEventController(TenderTummiesAPIContext ctx)
        {
            _context = ctx;
        }

        // GET METHOD
        //http://localhost:5000/TrialEvent/id will return a list of all TrialEvents for a certain trial. 
        [HttpGet("{trialID}", Name = "GetTrialsTrialEvents")]
        
        public IActionResult GetByTrial([FromRoute] int trialID)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            IQueryable<TrialEvent> trialEvents = _context.TrialEvent
                .Where(c => c.TrialID == trialID);

            if (trialEvents == null)
            {
                return NotFound();
            }

            return Ok(trialEvents);

        }

        // GET Single Trial Event
         //http://localhost:5000/TrialEvent/{id} will return info on a single Trial Event based on ID 
        [HttpGet("id/{id}", Name = "GetSingleTrialEvent")]

        public IActionResult GetById([FromRoute] int id)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                
                TrialEvent trialEvent = _context.TrialEvent
                    .Single(m => m.TrialEventID == id);

                if (trialEvent == null)
                {
                    return NotFound();
                }
                
                return Ok(trialEvent);
            }
            
            catch (System.InvalidOperationException ex)
            {
                return NotFound(ex);
            }
        }

        // POST
        // //http://localhost:5000/TrialEvent/ will post new Trial event to the DB 
        [HttpPost]
        public IActionResult Post([FromBody] TrialEvent newTrialEvent)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TrialEvent.Add(newTrialEvent);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                if (TrialEventExists(newTrialEvent.TrialEventID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw(ex);
                }
            }
            return CreatedAtRoute("GetSingleTrialEvent", new { id = newTrialEvent.TrialEventID }, newTrialEvent);

        }

        //Helper method to check to see if a TrialID is already in the system
        private bool TrialEventExists(int trialEventID)
        {
          return _context.TrialEvent.Count(e => e.TrialEventID == trialEventID) > 0;
        }

        // PUT 
         //http://localhost:5000/TrialEvent/{id} will edit a Trial event entry in the DB.  
        [HttpPut("id/{id}")]
        public IActionResult Put(int id, [FromBody] TrialEvent modifiedTrialEvent)
        {
            modifiedTrialEvent.TrialEventID = id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modifiedTrialEvent.TrialEventID)
            {
                return BadRequest();
            }

            _context.Entry(modifiedTrialEvent).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrialEventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }

        // DELETE url/TrialEvent/5
        // Deletes something based on an id.
        [HttpDelete("id/{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TrialEvent singleTrialEvent = _context.TrialEvent.Single(m => m.TrialEventID == id);
            if (singleTrialEvent == null)
            {
                return NotFound();
            }

            _context.TrialEvent.Remove(singleTrialEvent);
            _context.SaveChanges();

            return Ok(singleTrialEvent);
        }

    }
}