using System.Net;
using ExpenseRecord.Controllers;
using ExpenseRecord.Models.ExpenseRecord;
using ExpenseRecord.Models.ResponseItem;
using ExpenseRecord.Services.ExpenseRecord;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;

namespace ExpenseRecordTest.Controllers
{
    public class ExpenseRecordControllerTest
    {
        [Fact]
        public async Task should_return_201_and_body_if_create_successfully_Async()
        {
            var expenseRecordServiceMock = new  Mock<IExpenseRecordService>();
            expenseRecordServiceMock
                .Setup(item => item.CreateExpenseRecordAsync(It.IsAny<ExpenseRecordDto>()))
                .ReturnsAsync(new Response<ExpenseRecordDto>(HttpStatusCode.Created, new ExpenseRecordDto(){Id = "Test Item"}));
            var controller = new ExpenseRecordController(expenseRecordServiceMock.Object, It.IsAny<ProblemDetailsFactory>());

            var result = await controller.CreateExpenseRecord(new ExpenseRecordDto() { Id = "Test Item" });

            Assert.Equal(201,(result as ObjectResult)!.StatusCode);
            Assert.Equal("Test Item", ((result as ObjectResult)?.Value as ExpenseRecordDto)?.Id);
        }
    }
}
