using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ParksLookUp.Models;
using System.Collections.Generic;
using System.Linq;
using System;


namespace ParksLookUp.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ParksController : ControllerBase
  {
    private ParksLookUpContext _db;
    public ParksController(ParksLookUpContext db)
    {
      _db = db;
    }
    // GET api/parks
    [HttpGet]
    public ActionResult<IEnumerable<Park>> Get(string title, int rating, string location, string kind)
    {
      var query = _db.Parks.AsQueryable();
      if (title != null)
      {
        query = query.Where(entry => entry.Title.Contains(title));
      }
      if (rating != 0)
      {
        query = query.Where(entry => entry.Rating == rating);
      }
      if (location != null)
      {
        query = query.Where(entry => entry.Location.Contains(location));//contains will capture all instances with the name query = query.Where(entry => entry.Name.Contains(name));
      }
      if (kind != null)
      {
        query = query.Where(entry => entry.Kind == kind);
      }
      return query.ToList();
    }

    // GET api/parks/5
    [HttpGet("{id}")]
    public ActionResult<Park> Get(int id)
    {
      return _db.Parks.FirstOrDefault(entry => entry.ParkId == id);
    }
    //GET api/parks/best?rating=x
    [HttpGet("best")]
    public ActionResult<IEnumerable<Park>> BestAbove(int rating)
    {
      var query = _db.Parks.AsQueryable();
      query = query.Where(entry => entry.Rating >= rating);
      return query.ToList();
    }
    //GET api/parks/random
    [HttpGet("random")]
    public ActionResult<Park> Get()
    {
      int count = _db.Parks.Count();
      int index = new Random().Next(count);

      return _db.Parks.Skip(index).FirstOrDefault();
    }

    // POST api/parks
    [HttpPost]
    public void Post([FromBody] Park park)
    {
      _db.Parks.Add(park);
      _db.SaveChanges();
    }

    // PUT api/parks/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Park park)
    {
      park.ParkId = id;
      _db.Entry(park).State = EntityState.Modified;
      _db.SaveChanges();
    }

    // DELETE api/parks/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var parkToDelete = _db.Parks.FirstOrDefault(entry => entry.ParkId == id);
      _db.Parks.Remove(parkToDelete);
      _db.SaveChanges();
    }
  }
}
