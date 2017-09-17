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
    //Sets URL route to <websitename>/Food
    [Route("[controller]")]
    //Creates a new Food controller class that inherits methods from AspNetCore Controller class
    public class FoodController : Controller
    {
        //Sets up an empty variable _context that will  be a reference of the TenderTummiesAPI class
        private TenderTummiesAPIContext _context;

         //Instantiates StandardizeNames so I can make names titlecase
        private StandardizeNames _nameHelper = new StandardizeNames();

        //Contructor that instantiates a new Food controller 
        //Sets _context equal to a new instance of our TenderTummiesAPI class
        public FoodController(TenderTummiesAPIContext ctx)
        {
            _context = ctx;
        }

        // GET METHOD
        //http://localhost:5000/Food/ will return a list of all Food for a certain user. 
        [HttpGet]

        public IActionResult Get()
        {

            IQueryable<object> food = _context.Food.Distinct();

            //if the collection is empty will return NotFound and exit the method. 
            if (food == null)
            {
                return NotFound();
            }

            //otherwise return list of the food
            return Ok(food);

        }

        // GET Single Food
         //http://localhost:5000/Food/{id} will return info on a single Food based on ID 
        [HttpGet("id/{id}", Name = "GetSingleFood")]

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
                //will search the _context.Food for an entry that has the id we are looking for
                //if found, will return that Food
                //if not found will return 404. 
                Food food = _context.Food.Single(m => m.FoodID == id);

                if (food == null)
                {
                    return NotFound();
                }
                
                return Ok(food);
            }
            //if the try statement fails for some reason, will return error of what happened. 
            catch (System.InvalidOperationException ex)
            {
                return NotFound(ex);
            }
        }

        // POST
        // //http://localhost:5000/Food/ will post new food to the DB 
        [HttpPost]
        //takes the format of food type as a JSON format and adds to database. 
        public IActionResult Post([FromBody] Food newFood)
        {
            //Checks to make sure model state is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (FoodNameExists(newFood.Name)){
                return BadRequest("This food already exists in the database");
            }
            //Formats submission so that the first letter of every word is capitalized
            newFood.Name = _nameHelper.ToTitlecase(newFood.Name);
            //Will add new food to the context
            //This will not yet be added to DB until .SaveChanges() is run
            _context.Food.Add(newFood);
            

            //Will attempt to save the changes to the DB.
            //If there is an error, will throw exception code. 
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                //this checks to see if a new Food we are trying to add has a FoodID that already exists in the system
                if (FoodExists(newFood.FoodID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw(ex);
                }
            }

            //if everything successfull, will run the "GetSingleFood" method while passing the new ID that was created and return the new Food
            return CreatedAtRoute("GetSingleSymptom", new { id = newFood.FoodID }, newFood);
        }


        //Helper method to check to see if a FoodID is already in the system
        private bool FoodExists(int FoodID)
        {
          return _context.Food.Count(e => e.FoodID == FoodID) > 0;
        }
        //Helper method to see if the food name exists in the database already
        private bool FoodNameExists(string FoodName)
        {
            string formattedFoodName = _nameHelper.ToTitlecase(FoodName);
            Food getFood = _context.Food.SingleOrDefault(e => e.Name == formattedFoodName);
            if (getFood != null && formattedFoodName == getFood.Name){
                return true;
            } else {
                return false;
            }
        }

    }
}