using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using todo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace todo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private static List<Task> tasks = new List<Task>();

        // GET /api/tasks
        [HttpGet]
        public IActionResult GetAllTasks()
        {
            return Ok(tasks);
        }

        // PUT /api/completeTask/{id}
        [HttpPut("completeTask/{id}")]
        public IActionResult CompleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            task.IsCompleted = true;
            return Ok();
        }
    }

    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}


