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
    //Sets URL route to <websitename>/Child
    [Route("[controller]")]
    //Creates a new child controller class that inherits methods from AspNetCore Controller class
    public class SymptomController : Controller
    {
        //Sets up an empty variable _context that will  be a reference of the TenderTummiesAPI class
        private TenderTummiesAPIContext _context;
        //Contructor that instantiates a new Child controller 
        //Sets _context equal to a new instance of our TenderTummiesAPI class
        public SymptomController(TenderTummiesAPIContext ctx)
        {
            _context = ctx;
        }

        // GET METHOD
        //http://localhost:5000/Child/ will return a list of all children for a certain user. 
        [HttpGet]

        //Get() is a mathod from the AspNetCore Controller class to retreive info from database. 
        public IActionResult Get()
        {

            IQueryable<object> symptoms = _context.Symptom.Distinct();

            //if the collection is empty will retur NotFound and exit the method. 
            if (symptoms == null)
            {
                return NotFound();
            }

            //otherwise return list of the symptoms
            return Ok(symptoms);

        }

        // GET Single Symptom
         //http://localhost:5000/Child/{id} will return info on a single child based on ID 
        [HttpGet("id/{id}", Name = "GetSingleSymptom")]

        //will run Get based on the id from the url route. 
        public IActionResult Get([FromRoute] int id)
        {
            //if you request anything other than an Id you will get a return of BadRequest. 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                //will search the _context.Child for an entry that has the id we are looking for
                //if found, will return that child
                //if not found will return 404. 
                Symptom symptom = _context.Symptom.Single(m => m.SymptomID == id);

                if (symptom == null)
                {
                    return NotFound();
                }
                
                return Ok(symptom);
            }
            //if the try statement fails for some reason, will return error of what happened. 
            catch (System.InvalidOperationException ex)
            {
                return NotFound(ex);
            }
        }

        // POST
        // //http://localhost:5000/Symptom/ will post new symptom to the DB 
        [HttpPost]
        //takes the format of symptom type as a JSON format and adds to database. 
        public IActionResult Post([FromBody] Symptom newSymptom)
        {
            //Checks to make sure model state is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Will add new symptom to the context
            //This will not yet be added to DB until .SaveChanges() is run
            _context.Symptom.Add(newSymptom);
            

            //Will attempt to save the changes to the DB.
            //If there is an error, will throw exception code. 
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                //this checks to see if a new Symptom we are trying to add has a SymptomID that already exists in the system
                if (SymptomExists(newSymptom.SymptomID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw(ex);
                }
            }

            //if everything successfull, will run the "GetSingleChild" method while passing the new ID that was created and return the new Child
            return CreatedAtRoute("GetSingleSymptom", new { id = newSymptom.SymptomID }, newSymptom);
        }


        //Helper method to check to see if a SymptomID is already in the system
        private bool SymptomExists(int SymptomID)
        {
          return _context.Symptom.Count(e => e.SymptomID == SymptomID) > 0;
        }


    }
}