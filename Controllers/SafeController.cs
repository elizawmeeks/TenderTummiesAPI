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

        //Get() is a mathod from the AspNetCore Controller class to retreive info from database. 
        public IActionResult GetByChild([FromRoute] int child)
        {

            //if you request anything other than child you will get a return of BadRequest. 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //Sets a new IQuerable Collection of <objects> that will be filled with each instance of _context.Safe
            IQueryable<object> safes = _context.Safe.Include("Food").Where(c => c.ChildID == child);

            //if the collection is empty will retur NotFound and exit the method. 
            if (safes == null)
            {
                return NotFound();
            }

            //otherwise return list of the safes
            return Ok(safes);

        }

        // GET Single Safe
         //http://localhost:5000/Safe/{id} will return info on a single Safe based on ID 
        [HttpGet("id/{id}", Name = "GetSingleSafe")]

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
                //will search the _context.Safe for an entry that has the id we are looking for
                //if found, will return that Safe
                //if not found will return 404. 
                Safe safe = _context.Safe.Include("Food").Single(m => m.SafeID == id);

                if (safe == null)
                {
                    return NotFound();
                }
                
                return Ok(safe);
            }
            //if the try statement fails for some reason, will return error of what happened. 
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
            //Checks to make sure model state is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try{
                Safe exists = _context.Safe.Single(s => s.ChildID == newSafe.ChildID && s.FoodID == newSafe.FoodID);
            }catch{
                //Will add new Safe to the context only if there's not already an entry in the database with that child and
                //that safe.
                //This will not yet be added to DB until .SaveChanges() is run
                _context.Safe.Add(newSafe);
                //Will attempt to save the changes to the DB.
                //If there is an error, will throw exception code. 
                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    //this checks to see if a new Safe we are trying to add has a SafeID that already exists in the system
                    if (SafeExists(newSafe.SafeID))
                    {
                        return new StatusCodeResult(StatusCodes.Status409Conflict);
                    }
                    else
                    {
                        throw(ex);
                    }
                }

                //if everything successfull, will run the "GetSingleSafe" method while passing the new ID that was created and return the new Safe
                return CreatedAtRoute("GetSingleSafe", new { id = newSafe.SafeID }, newSafe);
            }

            return BadRequest("An entry for this safe already exists for this child!");
            
        }


        //Helper method to check to see if a SafeID is already in the system
        private bool SafeExists(int safeID)
        {
          return _context.Safe.Count(e => e.SafeID == safeID) > 0;
        }

        // DELETE url/Safe/5
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