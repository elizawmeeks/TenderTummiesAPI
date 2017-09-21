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
    //Sets URL route to <websitename>/Trial
    [Route("[controller]")]
    //Creates a new Trial controller class that inherits methods from AspNetCore Controller class
    public class TrialController : Controller
    {
        
        private TenderTummiesAPIContext _context;
        
        public TrialController(TenderTummiesAPIContext ctx)
        {
            _context = ctx;
        }

        // GET METHOD
        //http://localhost:5000/Trial/id will return a list of all Trials for a certain child. 
        [HttpGet("{child}", Name = "GetChildsTrials")]
        
        public IActionResult GetByChild([FromRoute] int child)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            IQueryable<Trial> trials = _context.Trial
                .Include("Food")
                .Where(c => c.ChildID == child);

            if (trials == null)
            {
                return NotFound();
            }

            return Ok(trials);

        }

        // GET Single Trial
         //http://localhost:5000/Trial/{id} will return info on a single Trial based on ID 
        [HttpGet("id/{id}", Name = "GetSingleTrial")]

        public IActionResult GetById([FromRoute] int id)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                
                Trial trial = _context.Trial
                    .Include("Food")
                    .Include("ReactionEvents")
                    .Include("TrialEvents")
                    .Single(m => m.TrialID == id);

                if (trial == null)
                {
                    return NotFound();
                }
                
                return Ok(trial);
            }
            
            catch (System.InvalidOperationException ex)
            {
                return NotFound(ex);
            }
        }

        // POST
        // //http://localhost:5000/Trial/ will post new Trial to the DB 
        [HttpPost]
        public IActionResult Post([FromBody] Trial newTrial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newTrial.TriggerID.HasValue){
                Trigger getTrigger = _context.Trigger.SingleOrDefault(t => t.TriggerID == newTrial.TriggerID);
                if (getTrigger.FoodID != newTrial.FoodID){
                    return BadRequest("The food ID on the trial does not match the food ID on the trigger");
                }
                if (getTrigger.ChildID !=  newTrial.ChildID){
                    return BadRequest("The ChildID on the trigger does not match the ChildID on the trial");
                }
            }

            _context.Trial.Add(newTrial);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                if (TrialExists(newTrial.TrialID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw(ex);
                }
            }
            return CreatedAtRoute("GetSingleTrial", new { id = newTrial.TrialID }, newTrial);

        }

        //Helper method to check to see if a TrialID is already in the system
        private bool TrialExists(int trialID)
        {
          return _context.Trial.Count(e => e.TrialID == trialID) > 0;
        }

        // PUT 
         //http://localhost:5000/Trial/{id} will edit a Trial entry in the DB.  
        [HttpPut("id/{id}")]
        public IActionResult Put(int id, [FromBody] Trial modifiedTrial)
        {
            modifiedTrial.TrialID = id;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modifiedTrial.TrialID)
            {
                return BadRequest();
            }

            if (modifiedTrial.TriggerID.HasValue){
                Trigger getTrigger = _context.Trigger.SingleOrDefault(t => t.TriggerID == modifiedTrial.TriggerID);
                if (getTrigger.FoodID != modifiedTrial.FoodID){
                    return BadRequest("The food ID on the trial does not match the food ID on the trigger");
                }
                if (getTrigger.ChildID !=  modifiedTrial.ChildID){
                    return BadRequest("The ChildID on the trigger does not match the ChildID on the trial");
                }
            }

            _context.Entry(modifiedTrial).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrialExists(id))
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

        // DELETE url/Trial/5
        // Deletes something based on an id.
        [HttpDelete("id/{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Trial singleTrial = _context.Trial.Single(m => m.TrialID == id);
            if (singleTrial == null)
            {
                return NotFound();
            }

            _context.Trial.Remove(singleTrial);
            _context.SaveChanges();

            return Ok(singleTrial);
        }

    }
}