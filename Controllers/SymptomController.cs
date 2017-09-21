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
    //Sets URL route to <websitename>/Symptom
    [Route("[controller]")]
    //Creates a new Symptom controller class that inherits methods from AspNetCore Controller class
    public class SymptomController : Controller
    {
        //Sets up an empty variable _context that will  be a reference of the TenderTummiesAPI class
        private TenderTummiesAPIContext _context;
        //Contructor that instantiates a new Symptom controller 
        //Sets _context equal to a new instance of our TenderTummiesAPI class
        public SymptomController(TenderTummiesAPIContext ctx)
        {
            _context = ctx;
        }

        // GET METHOD
        //http://localhost:5000/Symptom/ will return a list of all Symptoms
        [HttpGet]
        
        public IActionResult Get()
        {

            IQueryable<object> symptoms = _context.Symptom.Distinct();
            
            if (symptoms == null)
            {
                return NotFound();
            }
            
            return Ok(symptoms);

        }

        // GET Single Symptom
         //http://localhost:5000/Symptom/{id} will return info on a single Symptom based on ID 
        [HttpGet("id/{id}", Name = "GetSingleSymptom")]
        
        public IActionResult Get([FromRoute] int id)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                
                Symptom symptom = _context.Symptom.Single(m => m.SymptomID == id);

                if (symptom == null)
                {
                    return NotFound();
                }
                
                return Ok(symptom);
            }
            
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
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (SymptomNameExists(newSymptom.Name)){
                return BadRequest("This symptom already exists in the database");
            }
            
            _context.Symptom.Add(newSymptom);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                
                if (SymptomExists(newSymptom.SymptomID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw(ex);
                }
            }
            
            return CreatedAtRoute("GetSingleSymptom", new { id = newSymptom.SymptomID }, newSymptom);
        }


        //Helper method to check to see if a SymptomID is already in the system
        private bool SymptomExists(int SymptomID)
        {
          return _context.Symptom.Count(e => e.SymptomID == SymptomID) > 0;
        }

        private bool SymptomNameExists(string SymptomName)
        {
            string[] stringArray = SymptomName.Split(null);
            List<string> stringGroup = new List<string>();
            foreach (String thing in stringArray){
                stringGroup.Add(FirstLetterToUpper(thing));
            }
            string formattedSymptomName = string.Join(" ", stringGroup);
            Symptom getSymptom = _context.Symptom.SingleOrDefault(e => e.Name == formattedSymptomName);
            if (getSymptom != null && formattedSymptomName == getSymptom.Name){
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