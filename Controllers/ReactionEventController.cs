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
    //Sets URL route to <websitename>/ReactionEvent
    [Route("[controller]")]
    
    public class ReactionEventController : Controller
    {
        
        private TenderTummiesAPIContext _context;
        
        public ReactionEventController(TenderTummiesAPIContext ctx)
        {
            _context = ctx;
        }

        // GET METHOD
        //http://localhost:5000/ReactionEvent/{reactionID} will return a list of all ReactionEvents for a certain reaction. 
        [HttpGet("{rxnID}", Name = "GetAssociatedReactionsReactionEvents")]
        public IActionResult GetByAssociatedReaction([FromRoute] int rxnID)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            IQueryable<object> rxnEs = _context.ReactionEvent
                .Where(c => c.ReactionID == rxnID);
            
            if (rxnEs == null)
            {
                return NotFound();
            }
            
            return Ok(rxnEs);

        }

        // GET Single ReactionEvent
         //http://localhost:5000/ReactionEvent/{id} will return info on a single ReactionEvent based on ID 
        [HttpGet("id/{id}", Name = "GetSingleReactionEvent")]
        
        public IActionResult GetById([FromRoute] int id)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                
                ReactionEvent rxnE = _context.ReactionEvent
                    .Include("ReactionEventSymptoms")
                    .Single(m => m.ReactionEventID == id);

                if (rxnE == null)
                {
                    return NotFound();
                }
                
                return Ok(rxnE);
            }
            
            catch (System.InvalidOperationException ex)
            {
                return NotFound(ex);
            }
        }

        // POST
        // //http://localhost:5000/ReactionEvent/ will post new reaction event and associate symptoms to the DB 
        [HttpPost]
        public IActionResult Post([FromBody] ReactionEventSubmission reSub)
        {
            ReactionEvent newRE = new ReactionEvent();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (reSub.TrialID != null){
                newRE = new ReactionEvent() 
                    { 
                        ReactionID = reSub.ReactionID, 
                        TrialID = reSub.TrialID, 
                        Acute = reSub.Acute,
                        Chronic = reSub.Chronic,
                        Description = reSub.Description,
                        DateTime = reSub.DateTime
                    };
            } else {
                newRE = new ReactionEvent() 
                    { 
                        ReactionID = reSub.ReactionID,
                        Acute = reSub.Acute,
                        Chronic = reSub.Chronic,
                        Description = reSub.Description,
                        DateTime = reSub.DateTime
                    };
            }
            _context.ReactionEvent.Add(newRE);

            foreach (int id in reSub.SymptomIDs){
                ReactionEventSymptom newReSymptom = new ReactionEventSymptom()
                    {
                        SymptomID = id,
                        ReactionEventID = newRE.ReactionEventID
                    };
                _context.ReactionEventSymptom.Add(newReSymptom);
            }

            try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    if (ReactionEventExists(newRE.ReactionEventID))
                    {
                        return new StatusCodeResult(StatusCodes.Status409Conflict);
                    }
                    else
                    {
                        throw(ex);
                    }
                }
            
            return CreatedAtRoute("GetSingleReactionEvent", new { id = newRE.ReactionEventID }, newRE);

        }

        // POST
        // //http://localhost:5000/ReactionEvent/Symptom/ will post new ReactionEventSymptom to the DB 
        [HttpPost("Symptom")]
        public IActionResult PostSymptoms([FromBody] ReactionEventSymptom newRES)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _context.ReactionEventSymptom.Add(newRES);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw(ex);
            }
            return CreatedAtRoute("GetSingleReaction", new { id = newRES.ReactionEventSymptomID }, newRES);
            
        }


        //Helper method to check to see if a TriggerID is already in the system
        private bool ReactionEventExists(int rxnEID)
        {
          return _context.ReactionEvent.Count(e => e.ReactionEventID == rxnEID) > 0;
        }


        // PUT 
         //http://localhost:5000/ReactionEvent/{id} will edit a ReactionEvent entry in the DB.  
        [HttpPut("id/{id}")]
        public IActionResult Put(int id, [FromBody] ReactionEvent modifiedReactionEvent)
        {
            modifiedReactionEvent.ReactionEventID = id;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modifiedReactionEvent.ReactionEventID)
            {
                return BadRequest();
            }

            _context.Entry(modifiedReactionEvent).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReactionEventExists(id))
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


        // DELETE url/ReactionEvent/5
        // Deletes Reaction Event and all associated Symptoms. based on an id.
        [HttpDelete("id/{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ReactionEvent singleReactionEvent = _context.ReactionEvent.Single(m => m.ReactionEventID == id);
            IQueryable<ReactionEventSymptom> RESymptoms = _context.ReactionEventSymptom.Where(r => r.ReactionEventID == id);
            
            if (singleReactionEvent == null)
            {
                return NotFound();
            }

            _context.ReactionEvent.Remove(singleReactionEvent);
            foreach (var item in RESymptoms){
                _context.ReactionEventSymptom.Remove(item);
            }
            _context.SaveChanges();

            return Ok(singleReactionEvent);
        }

         // DELETE url/ReactionEvent/Symptom/ReactionEventSymptomID
        // Deletes something based on an id.
        [HttpDelete("Symptom/{id}")]
        public IActionResult DeleteSymptom(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ReactionEventSymptom singleRES = _context.ReactionEventSymptom.Single(m => m.ReactionEventSymptomID == id);
            if (singleRES == null)
            {
                return NotFound();
            }

            _context.ReactionEventSymptom.Remove(singleRES);
            _context.SaveChanges();

            return Ok(singleRES);
        }

    }
}