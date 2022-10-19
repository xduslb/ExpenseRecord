using ExpenseRecord.Models.ExpenseRecord;
using ExpenseRecord.Models.ResponseItem;
using MongoDB.Driver;
using System.Net;

namespace ExpenseRecord.Services.ExpenseRecord
{
    public class ExpenseRecordService:IExpenseRecordService
    {
        private IMongoCollection<ExpenseRecordDto> _collection;

        public ExpenseRecordService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _collection = client.GetDatabase("bootcamp").GetCollection<ExpenseRecordDto>("expenseRecords");
        }

        public async Task<Response<ExpenseRecordDto>> CreateExpenseRecordAsync(ExpenseRecordDto request)
        {
            var item = new ExpenseRecordDto()
            {
                Id = Guid.NewGuid().ToString(),
                Description = request.Description,
                Type = request.Type,
                Amount = request.Amount,
                Date = request.Date??DateTime.Now,
            };
            try
            {
                await _collection.InsertOneAsync(item);
                return new Response<ExpenseRecordDto>(HttpStatusCode.Created, item);
            }
            catch (Exception e)
            {
                return new UnsuccessfulResponse<ExpenseRecordDto>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<List<ExpenseRecordDto>>> GetAllExpenseRecordsAsync()
        {
            try
            {
                var items = await _collection.Find(_ => true).ToListAsync();
                if (items!=null && items.Count>1)
                {
                    items = items.OrderByDescending(item => item.Date).ToList();
                }
                return new Response<List< ExpenseRecordDto>>(HttpStatusCode.OK, items);
            }
            catch (Exception e)
            {
                return new UnsuccessfulResponse<List<ExpenseRecordDto>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> DeleteExpenseRecordAsync(string id)
        {
            try
            {
                await _collection.DeleteOneAsync(doc => doc.Id == id);
                return new Response<string>(HttpStatusCode.NoContent, $"TodoList {id} has been deleted.");
            }
            catch (Exception e)
            {
                return new UnsuccessfulResponse<string>(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
