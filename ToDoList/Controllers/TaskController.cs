using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Model;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public ActionResult<todolist> PostEquipment(todolist task)
        {
            todolist todolist = new todolist();
            todolist.Title = task.Title;
            todolist.Completed = task.Completed;
            _context.toDoLists.Add(todolist);
            _context.SaveChanges();
            return Ok();
           // return CreatedAtAction("GetEquipment", new { id = equipment.Id }, equipment);
        }
    }
}
