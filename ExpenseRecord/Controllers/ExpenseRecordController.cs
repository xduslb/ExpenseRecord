using ExpenseRecord.Extension;
using ExpenseRecord.Models.ExpenseRecord;
using ExpenseRecord.Services.ExpenseRecord;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ExpenseRecord.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpenseRecordController : Controller
    {
        private readonly IExpenseRecordService _service;
        private readonly ProblemDetailsFactory _problemDetailsFactory;

        public ExpenseRecordController(IExpenseRecordService service, ProblemDetailsFactory problemDetailsFactory)
        {
            _service = service;
            _problemDetailsFactory = problemDetailsFactory;
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpenseRecord([FromBody] ExpenseRecordDto request)
        {
            var result = await _service.CreateExpenseRecordAsync(request);
            return result.ToActionResult(this, _problemDetailsFactory);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllExpenseRecords()
        {
            var result = await _service.GetAllExpenseRecordsAsync();
            return result.ToActionResult(this, _problemDetailsFactory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpenseRecord([FromRoute] string id)
        {
            var result = await _service.DeleteExpenseRecordAsync(id);
            return result.ToActionResult(this, _problemDetailsFactory);
        }
    }
}
