using ExpenseRecord.Models.ExpenseRecord;
using ExpenseRecord.Models.ResponseItem;

namespace ExpenseRecord.Services.ExpenseRecord
{
    public interface IExpenseRecordService
    {
        Task<Response<ExpenseRecordDto>> CreateExpenseRecordAsync(ExpenseRecordDto request);
        Task<Response<List<ExpenseRecordDto>>> GetAllExpenseRecordsAsync();
        Task<Response<string>> DeleteExpenseRecordAsync(string id);
        
    }
}
