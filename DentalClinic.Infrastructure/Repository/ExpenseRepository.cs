using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
using DentalClinic.Domain.Repository;

namespace DentalClinic.Infrastructure.Repository {
    public class ExpenseRepository : GenericRepository<Expense>, IExpenseRepository {
        public ExpenseRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) {
        }

        public async Task<PagedResult<Expense>> GetFilteredPagedAsync(string itemname, DateTime startDate, DateTime endDate, int pageIndex, int pageSize) =>
            await context.Expenses.Where(e => (e.ItemName.Contains(itemname) || itemname.Equals("null")) &&
                                              (e.Date >= startDate || e.Date == null) && 
                                              (e.Date <= endDate) || e.Date == null)
                .GetPaged<Expense>(pageIndex, pageSize);
    }
}
