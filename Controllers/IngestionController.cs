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
using System.Globalization;

namespace TenderTummiesAPI.Controllers
{
    //Sets URL route to <websitename>/Ingestions
    [Route("[controller]")]
    //Creates a new Ingestions controller class that inherits methods from AspNetCore Controller class
    public class IngestionsController : Controller
    {
        //Sets up an empty variable _context that will  be a reference of the TenderTummiesAPI class
        private TenderTummiesAPIContext _context;
        //Contructor that instantiates a new Ingestions controller 
        //Sets _context equal to a new instance of our TenderTummiesAPI class
        public IngestionsController(TenderTummiesAPIContext ctx)
        {
            _context = ctx;
        }

        // GET METHOD
        //http://localhost:5000/Food/ will return a list of all Food for a certain user. 
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

            //Will add new food to the context
            //This will not yet be added to DB until .SaveChanges() is run
            _context.Food.Add(newIngestion);
            

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
            string[] stringArray = IngestionName.Split(null);
            List<string> stringGroup = new List<string>();
            foreach (String thing in stringArray){
                stringGroup.Add(FirstLetterToUpper(thing));
            }
            string formattedIngestionName = string.Join(" ", stringGroup);
            Ingestion getIngestion = _context.Ingestion.SingleOrDefault(e => e.Name == formattedIngestionName);
            if (getIngestion != null && formattedIngestionName == getIngestion.Name){
                return true;
            } else {
                return false;
            }
        }

        private string FirstLetterToUpper(string str)
        {
            if (str == null){
                return null;
            }
            if (str.Length > 1){
                return char.ToUpper(str[0]) + str.Substring(1);
            }
            return str.ToUpper();
        }

    }
}