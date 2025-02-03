using Application.Service;
using Core.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColumnController : ControllerBase
    {
        private readonly ColumnService _columnService;

        public ColumnController(ColumnService columnService)
        {
            _columnService = columnService;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(Column column)
        {
            await _columnService.Create(column);
            return Ok(column);
        }
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            await _columnService.Delete(Id);
            return Ok();
        }
        [HttpPut("Update")]
       
        public async Task<IActionResult> Update(Column column)
        {
           var UpdateColumn = await _columnService.Update(column);
            return Ok(UpdateColumn);
        }
        [HttpGet("GetById")]
       
        public async Task<IActionResult>GetById(Guid Id)
        {
            await _columnService.GetById(Id);
            return Ok();
        }


        [HttpGet("GelAll")]
       
        public async Task<IActionResult>GetAll()
        {
            var columns = await _columnService.GetAll();
            return Ok(columns); 

        }




    }
}
