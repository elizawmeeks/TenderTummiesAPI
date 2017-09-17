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
        //Sets up an empty variable _context that will  be a reference of the TenderTummiesAPI class
        private TenderTummiesAPIContext _context;
        //Contructor that instantiates a new Reaction controller 
        //Sets _context equal to a new instance of our TenderTummiesAPI class
        public ReactionController(TenderTummiesAPIContext ctx)
        {
            _context = ctx;
        }

        // GET METHOD
        //http://localhost:5000/Reaction/ will return a list of all reactions for a certain child. 
        [HttpGet("{child}", Name = "GetChildsReactions")]

        //Get() is a mathod from the AspNetCore Controller class to retreive info from database. 
        public IActionResult GetByChild([FromRoute] int child)
        {

            //if you request anything other than child you will get a return of BadRequest. 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //Sets a new IQuerable Collection of <objects> that will be filled with each instance of _context.Child
            IQueryable<Reaction> reactions = _context.Reaction
                .Include("ReactionTrigger")
                .Where(c => c.ChildID == child);

            //if the collection is empty will retur NotFound and exit the method. 
            if (reactions == null)
            {
                return NotFound();
            }

            //otherwise return list of the reactions
            return Ok(reactions);

        }

        // GET Single Reaction
         //http://localhost:5000/Reaction/{id} will return info on a single Reaction based on ID 
        [HttpGet("id/{id}", Name = "GetSingleReaction")]

        //will run Get based on the id from the url route. 
        public IActionResult GetById([FromRoute] int id)
        {
            //if you request anything other than an Id you will get a return of BadRequest. 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                //will search the _context.Reaction for an entry that has the id we are looking for
                //if found, will return that Reaction
                //if not found will return 404. 
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
            //if the try statement fails for some reason, will return error of what happened. 
            catch (System.InvalidOperationException ex)
            {
                return NotFound(ex);
            }
        }



        //Helper method to check to see if a ReactionID is already in the system
        private bool ReactionExists(int reactionID)
        {
          return _context.Reaction.Count(e => e.ReactionID == reactionID) > 0;
        }

        // PUT 
         //http://localhost:5000/Reaction/{id} will edit a Reaction entry in the DB.  
        [HttpPut("{id}")]
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

        // DELETE url/Reaction/5
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

    }
}