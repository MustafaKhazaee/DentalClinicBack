using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
using DentalClinic.Domain.Services;
using DentalClinic.Domain.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace DentalClinic.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : BaseController {
        public ExpenseController(IDomainServices _domainServices) : base(_domainServices) { }

        [HttpGet]
        [Authorize(Roles = Permissions.Expense.Get)]
        public async Task<PagedResult<Expense>> GetFilteredPagedAsync(string itemname, DateTime startDate, DateTime endDate, int pageIndex, int pageSize) =>
            await domainServices.ExpenseService.GetFilteredPagedAsync(itemname, startDate, endDate, pageIndex, pageSize);

        [HttpPost]
        [Authorize(Roles = Permissions.Expense.Post)]
        public async Task<int> Add(Expense expense) => await domainServices.ExpenseService.AddAsync(expense);

        [HttpPut]
        [Authorize(Roles = Permissions.Expense.Put)]
        public async Task<int> Put(Expense expense, Guid id) => await domainServices.ExpenseService.UpdateAsync(expense, id);

        [HttpDelete]
        [Authorize(Roles = Permissions.Expense.Delete)]
        public async Task<int> Delete(Guid id) => await domainServices.ExpenseService.RemoveAsync(id);
    }
}
