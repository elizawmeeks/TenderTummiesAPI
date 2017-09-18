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
    //Sets URL route to <websitename>/Reaction
    [Route("[controller]")]
    //Creates a new Reaction controller class that inherits methods from AspNetCore Controller class
    public class ReactionController : Controller
    {
        
        private TenderTummiesAPIContext _context;
        
        public ReactionController(TenderTummiesAPIContext ctx)
        {
            _context = ctx;
        }

        // GET METHOD
        //http://localhost:5000/Reaction/childID will return a list of all reactions for a certain child. 
        [HttpGet("{child}", Name = "GetChildsReactions")]
        
        public IActionResult GetByChild([FromRoute] int child)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            IQueryable<Reaction> reactions = _context.Reaction
                .Include("ReactionTriggers")
                .Where(c => c.ChildID == child);

            if (reactions == null)
            {
                return NotFound();
            }

            return Ok(reactions);

        }

        // GET Single Reaction
         //http://localhost:5000/Reaction/{id} will return info on a single Reaction based on ID 
        [HttpGet("id/{id}", Name = "GetSingleReaction")]

        public IActionResult GetById([FromRoute] int id)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                
                Reaction reaction = _context.Reaction
                    .Include("ReactionTriggers")
                    .Include("ReactionEvents")
                    .Single(m => m.ReactionID == id);

                if (reaction == null)
                {
                    return NotFound();
                }
                
                return Ok(reaction);
            }
            
            catch (System.InvalidOperationException ex)
            {
                return NotFound(ex);
            }
        }


        // POST
        // //http://localhost:5000/Reaction/ will post new Reaction to the DB 
        [HttpPost]
        //takes the format of Reaction type as a JSON format and adds to database. 
        //Accepts a Reaction and an array of symptoms that come in as type ReactionSubmission.
        //ReactionSubmission have a symptom ID, acute, and chronic booleans, but no ReactionID.
        public IActionResult Post([FromBody] ReactionSubmission reactionSub)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Reaction newRxn = new Reaction()
                {
                    ChildID = reactionSub.ChildID,
                    IngestionID = reactionSub.IngestionID,
                    FoodType = reactionSub.FoodType,
                    StartDate = reactionSub.StartDate,
                    Description = reactionSub.Description
                };
            
            _context.Reaction.Add(newRxn);

            foreach (int id in reactionSub.TriggerIDs){
                ReactionTrigger newRT = new ReactionTrigger()
                {
                    ReactionID = newRxn.ReactionID,
                    TriggerID = id
                };
                _context.ReactionTrigger.Add(newRT);
            }
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                if (ReactionExists(newRxn.ReactionID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw(ex);
                }
            }
            return CreatedAtRoute("GetSingleReaction", new { id = newRxn.ReactionID }, newRxn);

        }

        // POST
        // //http://localhost:5000/Reaction/Trigger/ReactionID will post new Reaction to the DB 
        [HttpPost("Trigger/{reactionID}")]
        //takes the format of Reaction type as a JSON format and adds to database. 
        //Accepts a Reaction and an array of symptoms that come in as type ReactionSubmission.
        //ReactionSubmission have a symptom ID, acute, and chronic booleans, but no ReactionID.
        public IActionResult PostTrigger(int reactionID, [FromBody] int triggerID)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ReactionTrigger newRT = new ReactionTrigger()
                {
                    ReactionID = reactionID,
                    TriggerID = triggerID
                };
            
            _context.ReactionTrigger.Add(newRT);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw(ex);
            }
            return CreatedAtRoute("GetSingleReaction", new { id = newRT.ReactionID }, newRT);
            
        }

        //Helper method to check to see if a ReactionID is already in the system
        private bool ReactionExists(int reactionID)
        {
          return _context.Reaction.Count(e => e.ReactionID == reactionID) > 0;
        }

        // PUT 
         //http://localhost:5000/Reaction/{id} will edit a Reaction entry in the DB.  
        [HttpPut("id/{id}")]
        public IActionResult Put(int id, [FromBody] Reaction modifiedReaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modifiedReaction.ReactionID)
            {
                return BadRequest();
            }

            _context.Entry(modifiedReaction).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReactionExists(id))
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

        // DELETE url/Reaction/id/5
        // Deletes something based on an id.
        [HttpDelete("id/{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Reaction singleReaction = _context.Reaction.Single(m => m.ReactionID == id);
            if (singleReaction == null)
            {
                return NotFound();
            }

            _context.Reaction.Remove(singleReaction);
            _context.SaveChanges();

            return Ok(singleReaction);
        }

        // DELETE url/Reaction/id/ReactionTriggerID
        // Deletes something based on an id.
        [HttpDelete("Trigger/{id}")]
        public IActionResult DeleteTrigger(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ReactionTrigger singleReactionTrigger = _context.ReactionTrigger.Single(m => m.ReactionTriggerID == id);
            if (singleReactionTrigger == null)
            {
                return NotFound();
            }

            _context.ReactionTrigger.Remove(singleReactionTrigger);
            _context.SaveChanges();

            return Ok(singleReactionTrigger);
        }

    }
}