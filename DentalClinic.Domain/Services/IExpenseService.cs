using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
namespace DentalClinic.Domain.Services {
    public interface IExpenseService {
        public Task<PagedResult<Expense>> GetFilteredPagedAsync(string itemname, DateTime startDate, DateTime endDate, int pageIndex, int pageSize);
        public Task<int> AddAsync(Expense expense);
        public Task<int> RemoveAsync(Guid Id);
        public Task<int> UpdateAsync(Expense expense, Guid id);
    }
}
