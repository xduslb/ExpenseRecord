using System.Net;

namespace ExpenseRecord.Models.ResponseItem
{
    public class Response<T>where T:class
    {
        public HttpStatusCode StatusCode { get; set; }
        public T? Body { get; set; }

        public Response(HttpStatusCode statusCode, T body = null)
        {
            StatusCode=statusCode;
            Body=body;
        }
    }
}
