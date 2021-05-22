using Microsoft.AspNetCore.Mvc;
using taskManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace taskManager.Controllers 
{

    public class APIController : Controller
    {
        static List<Task> data;

        DataContext dbContext;

        public APIController(DataContext db)
        {
            dbContext = db;
        }


        [HttpPost]
        public IActionResult SaveTask([FromBody] Task theTask)
        {
            System.Console.WriteLine("Save tasks called!");
            System.Console.WriteLine(theTask.Title);
           
            dbContext.Tasks.Add(theTask);
            dbContext.SaveChanges();

            //return the object
            return Json(theTask);
        }

        [HttpGet]
        public IActionResult GetTasks()
        {
            var list = dbContext.Tasks.ToList();
            return Json(list);
        }

        [HttpDelete]
        public IActionResult DelTask(int id)
        {
            //find the task
            Task t = dbContext.Tasks.Find(id);
            if(t == null)
            {
                return NotFound();
            }

            dbContext.Tasks.Remove(t);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}