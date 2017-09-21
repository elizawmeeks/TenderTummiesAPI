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
    //Sets URL route to <websitename>/Trigger
    [Route("[controller]")]
    //Creates a new Trigger controller class that inherits methods from AspNetCore Controller class
    public class TriggerController : Controller
    {
        private TenderTummiesAPIContext _context;
        
        public TriggerController(TenderTummiesAPIContext ctx)
        {
            _context = ctx;
        }

        // GET METHOD
        //http://localhost:5000/Trigger/{childID} will return a list of all Triggers for a certain child. 
        [HttpGet("{child}", Name = "GetChildsTriggers")]
        
        public IActionResult GetByChild([FromRoute] int child)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            IQueryable<object> triggers = _context.Trigger.Include("Food").Where(c => c.ChildID == child);
            
            if (triggers == null)
            {
                return NotFound();
            }
            
            return Ok(triggers);

        }

        // GET Single Trigger
         //http://localhost:5000/Trigger/{id} will return info on a single Trigger based on ID 
        [HttpGet("id/{id}", Name = "GetSingleTrigger")]
        public IActionResult GetById([FromRoute] int id)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                
                Trigger trigger = _context.Trigger
                    .Include("Food")
                    .Include("TriggerSymptoms")
                    .Include("ReactionTrigger")
                    .Include("Trials")
                    .Single(m => m.TriggerID == id);

                if (trigger == null)
                {
                    return NotFound();
                }
                
                return Ok(trigger);
            }
            
            catch (System.InvalidOperationException ex)
            {
                return NotFound(ex);
            }
        }

        // POST
        // //http://localhost:5000/Trigger/ will post new trigger to the DB 
        [HttpPost]
        //takes the format of trigger type as a JSON format and adds to database. 
        //Accepts a trigger and an array of symptoms that come in as type TriggerSubmission.
        //TriggerSubmission have a symptom ID, acute, and chronic booleans, but no triggerID.
        public IActionResult Post([FromBody] TriggerSubmission triggerSub)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try{
                
                Trigger exists = _context.Trigger
                    .Single(s => s.ChildID == triggerSub.ChildID && s.FoodID == triggerSub.FoodID);
            }catch{
                
                Trigger newTrigger = new Trigger()
                    { 
                        ChildID = triggerSub.ChildID, 
                        FoodID = triggerSub.FoodID, 
                        Severity = triggerSub.Severity 
                    };
                    
                _context.Trigger.Add(newTrigger);
                
                foreach (TriggerSymptomSubmission ts in triggerSub.TriggerSymptomSubmissions){
                    Symptom thisSymptom = _context.Symptom.SingleOrDefault(s => s.SymptomID == ts.SymptomID);
                    TriggerSymptom newTS = new TriggerSymptom()
                        { 
                            TriggerID = newTrigger.TriggerID, 
                            SymptomID = thisSymptom.SymptomID, 
                            Chronic = ts.Chronic, 
                            Acute = ts.Acute
                        };
                    _context.TriggerSymptom.Add(newTS);
                }
                
                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    if (TriggerExists(newTrigger.TriggerID))
                    {
                        return new StatusCodeResult(StatusCodes.Status409Conflict);
                    }
                    else
                    {
                        throw(ex);
                    }
                }
                return CreatedAtRoute("GetSingleTrigger", new { id = newTrigger.TriggerID }, newTrigger);
            }

            return BadRequest("An entry for this trigger already exists for this child!");
            
        }

        // POST
        // //http://localhost:5000/Trigger/Symptom will post new Reaction to the DB 
        [HttpPost("Symptom")]
        
        public IActionResult PostSymptoms([FromBody] TriggerSymptom newTS)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _context.TriggerSymptom.Add(newTS);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw(ex);
            }
            return CreatedAtRoute("GetSingleReaction", new { id = newTS.TriggerID }, newTS);
            
        }


        //Helper method to check to see if a TriggerID is already in the system
        private bool TriggerExists(int triggerID)
        {
          return _context.Trigger.Count(e => e.TriggerID == triggerID) > 0;
        }


        // PUT 
         //http://localhost:5000/Trigger/id/{id} will edit a Trigger entry in the DB.  
        [HttpPut("id/{id}")]
        public IActionResult Put(int id, [FromBody] Trigger modifiedTrigger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modifiedTrigger.TriggerID)
            {
                return BadRequest();
            }

            _context.Entry(modifiedTrigger).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TriggerExists(id))
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


        // DELETE url/Trigger/5
        // Deletes something based on an id.
        [HttpDelete("id/{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Trigger singleTrigger = _context.Trigger.Single(m => m.TriggerID == id);
            IQueryable<TriggerSymptom> allTS = _context.TriggerSymptom.Where(s => s.TriggerID == id);

            if (singleTrigger == null)
            {
                return NotFound();
            }

            _context.Trigger.Remove(singleTrigger);

             foreach (var item in allTS){
                _context.TriggerSymptom.Remove(item);
            }

            _context.SaveChanges();

            return Ok(singleTrigger);
        }

        // DELETE url/Trigger/Symptom/TriggerSymptomID
        // Deletes something based on an id.
        [HttpDelete("Symptom/{id}")]
        public IActionResult DeleteSymptom(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TriggerSymptom singleTriggerSymptom = _context.TriggerSymptom.Single(m => m.TriggerSymptomID == id);
            if (singleTriggerSymptom == null)
            {
                return NotFound();
            }

            _context.TriggerSymptom.Remove(singleTriggerSymptom);
            _context.SaveChanges();

            return Ok(singleTriggerSymptom);
        }

    }
}