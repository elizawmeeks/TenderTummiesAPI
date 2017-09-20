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
        public IngestionController(TenderTummiesAPIContext ctx)
        {
            _context = ctx;
        }

        // GET METHOD
        //http://localhost:5000/Ingestion/ will return a list of all Ingestion for a certain user. 
        [HttpGet]
        public IActionResult Get()
        {

            IQueryable<object> ingestions = _context.Ingestion.Distinct();

            if (ingestions == null)
            {
                return NotFound();
            }

            return Ok(ingestions);

        }

        // GET Single Ingestion
         //http://localhost:5000/Ingestion/{id} will return info on a single Ingestion based on ID 
        [HttpGet("id/{id}", Name = "GetSingleIngestion")]

        public IActionResult Get([FromRoute] int id)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                
                Ingestion ingestion = _context.Ingestion.Single(m => m.IngestionID == id);

                if (ingestion == null)
                {
                    return NotFound();
                }
                
                return Ok(ingestion);
            }
            
            catch (System.InvalidOperationException ex)
            {
                return NotFound(ex);
            }
        }

        // POST
        // //http://localhost:5000/Ingestion/ will post new ingestions to the DB 
        [HttpPost]
        
        public IActionResult Post([FromBody] Ingestion newIngestion)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (IngestionNameExists(newIngestion.Name)){
                return BadRequest("This ingestion type already exists in the database");
            }
            
            newIngestion.Name = _nameHelper.ToTitlecase(newIngestion.Name);
            
            _context.Ingestion.Add(newIngestion);
            
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                if (IngestionExists(newIngestion.IngestionID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw(ex);
                }
            }
            
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