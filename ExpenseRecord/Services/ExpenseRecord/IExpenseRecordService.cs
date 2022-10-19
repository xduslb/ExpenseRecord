using ExpenseRecord.Models.ExpenseRecord;
using ExpenseRecord.Models.ResponseItem;

namespace ExpenseRecord.Services.ExpenseRecord
{
    public interface IExpenseRecordService
    {
        Task<Response<ExpenseRecordDto>> CreateExpenseRecord(ExpenseRecordDto request);
        Task<Response<List<ExpenseRecordDto>>> GetAllExpenseRecords();
        Task<Response<string>> DeleteExpenseRecord(string id);
        
    }
}
