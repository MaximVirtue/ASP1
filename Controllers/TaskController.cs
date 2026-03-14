using Microsoft.AspNetCore.Mvc;
using TaskTracker.Models;
using TaskTracker.Repositories;

namespace TaskTracker.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _repository;

        public TasksController(ITaskRepository repository)
        {
            _repository = repository;
        }

        // GET /api/tasks
        [HttpGet]
        public IActionResult GetAllTasks()
        {
            return Ok(_repository.GetAll());
        }

        // POST /api/tasks/bug
        [HttpPost("bug")]
        public IActionResult CreateBug([FromBody] CreateBugRequest request)
        {
            var task = new BugReportTask(request.Title, request.SeverityLevel);

            task.OnTaskCompleted += task =>
            {
                Console.WriteLine($"Task completed: {task.Title}");
            };

            _repository.Add(task);

            return CreatedAtAction(nameof(GetAllTasks), new { id = task.Id }, task);
        }

        // PUT /api/tasks/{id}/complete
        [HttpPut("{id}/complete")]
        public IActionResult CompleteTask(Guid id)
        {
            var task = _repository.GetById(id);

            if (task == null)
                return NotFound();

            task.CompleteTask();

            _repository.Update(task);

            return Ok(task);
        }
    }

    public record CreateBugRequest(string Title, string SeverityLevel);
}