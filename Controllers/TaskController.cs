using Microsoft.AspNetCore.Mvc;
using Tasks.Models;
using Tasks.Services;

namespace Tasks.Controllers;

[ApiController]
[Route("[controller]")]

public class TaskController:ControllerBase
{
    [HttpGet]
    public ActionResult<List<MyTask>> Get()
    {
        return TaskService.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<MyTask> GetByID(int id)
    {
        var Task=TaskService.GetByID(id);
        if(Task==null)
             return NotFound();
        return Task;
    }

    [HttpPost]
    
        public ActionResult Post(MyTask newTask)
        {
            var newId=TaskService.Add(newTask);

            return CreatedAtAction("Post", 
              new {id = newId}, TaskService.GetByID(newId));
        }
    

    [HttpPut("{id}")]
      public ActionResult Put(int id,MyTask newTask)
    {
        var result = TaskService.Update(id, newTask);
        if (!result)
        {
            return BadRequest();
        }
        return NoContent();
    }
}