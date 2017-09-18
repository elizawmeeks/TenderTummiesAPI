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
    public class ChildController : Controller
    {
        //Sets up an empty variable _context that will  be a reference of the TenderTummiesAPI class
        private TenderTummiesAPIContext _context;

        //Contructor that instantiates a new Child controller 
        //Sets _context equal to a new instance of our TenderTummiesAPI class
        public ChildController(TenderTummiesAPIContext ctx)
        {
            _context = ctx;
        }

        // GET METHOD
        //http://localhost:5000/Child/ will return a list of all children for a certain user. 
        [HttpGet("{user}", Name = "GetUsersChildren")]

        public IActionResult GetByUser([FromRoute] string user)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            IQueryable<object> children = _context.Child.Where(c => c.UserID == user);

            if (children == null)
            {
                return NotFound();
            }

            return Ok(children);

        }

        // GET Single Child
         //http://localhost:5000/Child/{id} will return info on a single child based on ID 
        [HttpGet("id/{id}", Name = "GetSingleChild")]

        public IActionResult GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                
                Child child = _context.Child
                    .Include("Triggers")
                    .Include("Safes")
                    .Single(m => m.ChildID == id);

                if (child == null)
                {
                    return NotFound();
                }
                
                return Ok(child);
            }
            
            catch (System.InvalidOperationException ex)
            {
                return NotFound(ex);
            }
        }

        // POST
        // //http://localhost:5000/Child/ will post new child to the DB
        [HttpPost]
        
        public IActionResult Post([FromBody] Child newChild)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _context.Child.Add(newChild);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                
                if (ChildExists(newChild.ChildID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw(ex);
                }
            }
            
            return CreatedAtRoute("GetSingleChild", new { id = newChild.ChildID }, newChild);
        }


        //Helper method to check to see if a ChildID is already in the system
        private bool ChildExists(int childID)
        {
          return _context.Child.Count(e => e.ChildID == childID) > 0;
        }

        // PUT 
         //http://localhost:5000/Child/{id} will edit a child entry in the DB.  
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Child modifiedChild)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modifiedChild.ChildID)
            {
                return BadRequest();
            }

            _context.Entry(modifiedChild).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChildExists(id))
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

        // DELETE url/Child/5
        // Deletes something based on an id.
        [HttpDelete("id/{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Child singleChild = _context.Child.Single(m => m.ChildID == id);
            if (singleChild == null)
            {
                return NotFound();
            }

            _context.Child.Remove(singleChild);
            _context.SaveChanges();

            return Ok(singleChild);
        }

    }
}