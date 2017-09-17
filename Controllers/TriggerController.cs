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
        //Sets up an empty variable _context that will  be a reference of the TenderTummiesAPI class
        private TenderTummiesAPIContext _context;
        //Contructor that instantiates a new Trigger controller 
        //Sets _context equal to a new instance of our TenderTummiesAPI class
        public TriggerController(TenderTummiesAPIContext ctx)
        {
            _context = ctx;
        }

        // GET METHOD
        //http://localhost:5000/Trigger/{childID} will return a list of all Triggers for a certain child. 
        [HttpGet("{child}", Name = "GetChildsTriggers")]

        //Get() is a mathod from the AspNetCore Controller class to retreive info from database. 
        public IActionResult GetByChild([FromRoute] int child)
        {

            //if you request anything other than child you will get a return of BadRequest. 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //Sets a new IQuerable Collection of <objects> that will be filled with each instance of _context.Trigger
            IQueryable<object> triggers = _context.Trigger.Include("Food").Where(c => c.ChildID == child);

            //if the collection is empty will retur NotFound and exit the method. 
            if (triggers == null)
            {
                return NotFound();
            }

            //otherwise return list of the triggers
            return Ok(triggers);

        }

        // GET Single Trigger
         //http://localhost:5000/Trigger/{id} will return info on a single Trigger based on ID 
        [HttpGet("id/{id}", Name = "GetSingleTrigger")]

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
                //will search the _context.Trigger for an entry that has the id we are looking for
                //if found, will return that Trigger
                //if not found will return 404. 
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
            //if the try statement fails for some reason, will return error of what happened. 
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
            //Checks to make sure model state is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try{
                //Checks to see if a trigger with this foodID and childID already exists in the database
                //If it doesn't, throws and exception and everything gets made in the catch.
                Trigger exists = _context.Trigger
                    .Single(s => s.ChildID == triggerSub.ChildID && s.FoodID == triggerSub.FoodID);
            }catch{
                //Creates a new trigger for this child
                Trigger newTrigger = new Trigger()
                    { 
                        ChildID = triggerSub.ChildID, 
                        FoodID = triggerSub.FoodID, 
                        Severity = triggerSub.Severity 
                    };
                //Will add new Trigger to the context
                //This will not yet be added to DB until .SaveChanges() is run
                _context.Trigger.Add(newTrigger);

                //Here, the triggerID generated by adding the newTrigger to the context is combined
                //with the array of symptoms and chronic/acute booleans to create all the TriggerSymptoms
                //which are then added to the database.
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

                //Will attempt to save the changes to the DB.
                //If there is an error, will throw exception code. 
                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    //this checks to see if a new Trigger we are trying to add has a TriggerID that already exists in the system
                    if (TriggerExists(newTrigger.TriggerID))
                    {
                        return new StatusCodeResult(StatusCodes.Status409Conflict);
                    }
                    else
                    {
                        throw(ex);
                    }
                }

                //if everything successfull, will run the "GetSingleTrigger" method while passing the new ID that was created and return the new Trigger
                return CreatedAtRoute("GetSingleTrigger", new { id = newTrigger.TriggerID }, newTrigger);
            }

            return BadRequest("An entry for this trigger already exists for this child!");
            
        }


        //Helper method to check to see if a TriggerID is already in the system
        private bool TriggerExists(int triggerID)
        {
          return _context.Trigger.Count(e => e.TriggerID == triggerID) > 0;
        }


        // PUT 
         //http://localhost:5000/Trigger/{id} will edit a Trigger entry in the DB.  
        [HttpPut("{id}")]
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
            if (singleTrigger == null)
            {
                return NotFound();
            }

            _context.Trigger.Remove(singleTrigger);
            _context.SaveChanges();

            return Ok(singleTrigger);
        }

    }
}