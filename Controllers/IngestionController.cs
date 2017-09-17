using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderTummiesAPI.Data;
using TenderTummiesAPI.Models;
using TenderTummiesAPI.Helpers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace TenderTummiesAPI.Controllers
{
    //Sets URL route to <websitename>/Ingestion
    [Route("[controller]")]
    //Creates a new Ingestion controller class that inherits methods from AspNetCore Controller class
    public class IngestionController : Controller
    {
        //Sets up an empty variable _context that will  be a reference of the TenderTummiesAPI class
        private TenderTummiesAPIContext _context;
        
         //Instantiates StandardizeNames so I can make names titlecase
        private StandardizeNames _nameHelper = new StandardizeNames();
        //Contructor that instantiates a new Ingestion controller 
        //Sets _context equal to a new instance of our TenderTummiesAPI class
        public IngestionController(TenderTummiesAPIContext ctx)
        {
            _context = ctx;
        }

        // GET METHOD
        //http://localhost:5000/Ingestion/ will return a list of all Ingestion for a certain user. 
        [HttpGet]

        //Get() is a mathod from the AspNetCore Controller class to retreive info from database. 
        public IActionResult Get()
        {

            IQueryable<object> ingestions = _context.Ingestion.Distinct();

            //if the collection is empty will retur NotFound and exit the method. 
            if (ingestions == null)
            {
                return NotFound();
            }

            //otherwise return list of the ingestions
            return Ok(ingestions);

        }

        // GET Single Ingestion
         //http://localhost:5000/Ingestion/{id} will return info on a single Ingestion based on ID 
        [HttpGet("id/{id}", Name = "GetSingleIngestion")]

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
                //will search the _context.Ingestion for an entry that has the id we are looking for
                //if found, will return that Ingestion
                //if not found will return 404. 
                Ingestion ingestion = _context.Ingestion.Single(m => m.IngestionID == id);

                if (ingestion == null)
                {
                    return NotFound();
                }
                
                return Ok(ingestion);
            }
            //if the try statement fails for some reason, will return error of what happened. 
            catch (System.InvalidOperationException ex)
            {
                return NotFound(ex);
            }
        }

        // POST
        // //http://localhost:5000/Ingestion/ will post new ingestions to the DB 
        [HttpPost]
        //takes the format of ingestions type as a JSON format and adds to database. 
        public IActionResult Post([FromBody] Ingestion newIngestion)
        {
            //Checks to make sure model state is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (IngestionNameExists(newIngestion.Name)){
                return BadRequest("This ingestion type already exists in the database");
            }
            //Formats submission so that the first letter of every word is capitalized
            newIngestion.Name = _nameHelper.ToTitlecase(newIngestion.Name);

            //Will add new Ingestion to the context
            //This will not yet be added to DB until .SaveChanges() is run
            _context.Ingestion.Add(newIngestion);
            

            //Will attempt to save the changes to the DB.
            //If there is an error, will throw exception code. 
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                //this checks to see if a new Ingestion we are trying to add has a IngestionID that already exists in the system
                if (IngestionExists(newIngestion.IngestionID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw(ex);
                }
            }

            //if everything successfull, will run the "GetSingleIngestion" method while passing the new ID that was created and return the new Ingestion
            return CreatedAtRoute("GetSingleSymptom", new { id = newIngestion.IngestionID }, newIngestion);
        }


        //Helper method to check to see if a IngestionID is already in the system
        private bool IngestionExists(int IngestionID)
        {
          return _context.Ingestion.Count(e => e.IngestionID == IngestionID) > 0;
        }

        private bool IngestionNameExists(string IngestionName)
        {
            string formattedIngestionName = _nameHelper.ToTitlecase(IngestionName);
            Ingestion getIngestion = _context.Ingestion.SingleOrDefault(e => e.Name == formattedIngestionName);
            if (getIngestion != null && formattedIngestionName == getIngestion.Name){
                return true;
            } else {
                return false;
            }
        }

    }
}