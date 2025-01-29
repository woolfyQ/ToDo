using Application.Service;
using Core.Entity;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(Column column)
        {
            await _columnService.Create(column);
            return Ok(column);
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            await _columnService.Delete(Id);
            return Ok();
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(Column column)
        {
           var UpdateColumn = await _columnService.Update(column);
            return Ok(UpdateColumn);
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult>GetById(Guid Id)
        {
            await _columnService.GetById(Id);
            return Ok();
        }




    }
}
