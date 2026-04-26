using Microsoft.AspNetCore.Mvc;
using TaskFlow.API.DTOs;
using TaskFlow.API.Services.Interfaces;

namespace TaskFlow.API.Controllers
{
    public class TasksViewController : Controller
    {
        private readonly ITaskService _service;

        public TasksViewController(ITaskService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var pagedTasks = await _service.GetAllAsync(1, 10);

            return View(pagedTasks.Items);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateTaskItemDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskItemDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _service.CreateAsync(dto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _service.GetByIdAsync(id);

            if (task == null)
                return NotFound();

            var dto = new UpdateTaskItemDto
            {
                Title = task.Title,
                Description = task.Description,
                IsComplete = task.IsComplete 
            };

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateTaskItemDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var updated = await _service.UpdateAsync(id, dto);

            if (!updated)
                return NotFound();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return RedirectToAction("Index");
        }
    }
}
