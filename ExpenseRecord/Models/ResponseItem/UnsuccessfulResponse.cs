using System.Net;

namespace ExpenseRecord.Models.ResponseItem
{
    public class UnsuccessfulResponse<T>:Response<T> where T:class
    {
        public string? ErrorInfo { get; set; }

        public UnsuccessfulResponse(HttpStatusCode statuCode, string errorInfo):base(statuCode)
        {
            ErrorInfo = errorInfo;
        }
    }
}
