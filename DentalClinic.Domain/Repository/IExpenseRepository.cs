using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
namespace DentalClinic.Domain.Repository {
    public interface IExpenseRepository : IGenericRepository<Expense>{
        public Task<PagedResult<Expense>> GetFilteredPagedAsync(string itemname, DateTime startDate, DateTime endDate, int pageIndex, int pageSize);

    }
}
