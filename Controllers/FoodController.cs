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

            if (food == null)
            {
                return NotFound();
            }

            return Ok(food);

        }

        // GET Single Food
         //http://localhost:5000/Food/id/{id} will return info on a single Food based on ID 
        [HttpGet("id/{id}", Name = "GetSingleFood")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Food food = _context.Food.Single(m => m.FoodID == id);

                if (food == null)
                {
                    return NotFound();
                }
                
                return Ok(food);
            }

            catch (System.InvalidOperationException ex)
            {
                return NotFound(ex);
            }
        }

        // POST
        // http://localhost:5000/Food/ will post new food to the DB in titlecase 
        [HttpPost]
        public IActionResult Post([FromBody] Food newFood)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (FoodNameExists(newFood.Name)){
                return BadRequest("This food already exists in the database");
            }
            
            newFood.Name = _nameHelper.ToTitlecase(newFood.Name);
            
            _context.Food.Add(newFood);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                
                if (FoodExists(newFood.FoodID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw(ex);
                }
            }

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