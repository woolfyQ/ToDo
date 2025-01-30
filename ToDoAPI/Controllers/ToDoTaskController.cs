using Application.Service;
using Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoTaskController : ControllerBase
    {
        private readonly ToDoService _toDoService;

        public ToDoTaskController(ToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(ToDoList toDoList)
        {
            var createList = await _toDoService.Create(toDoList);
            return Ok(createList);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var toDoList = await _toDoService.GetById(id);
            return Ok(toDoList);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(ToDoList toDoList)
        {
           var updateList = await _toDoService.Update(toDoList);
            return Ok(updateList);
        }
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(Guid Id )
        {
            var deleteList = await _toDoService.Delete(Id);
            return Ok(deleteList);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var allList = await _toDoService.GetAll();
            return Ok(allList);
        }

    }
}
