using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
using DentalClinic.Domain.Repository;
using DentalClinic.Domain.Services;
using System.Net;

namespace DentalClinic.Infrastructure.Services {
    public class ExpenseService : IExpenseService {
        public ExpenseService(IUnitOfWork unitOfWork) {
            UnitOfWork = unitOfWork;
        }
        private IUnitOfWork UnitOfWork { get; set; }

        public async Task<int> AddAsync(Expense expense) {
            await UnitOfWork.ExpenseRepository.AddAsync(expense);
            await UnitOfWork.CompleteAsync();
            return await Task.FromResult((int) HttpStatusCode.Created);
        }

        public async Task<PagedResult<Expense>> GetFilteredPagedAsync(string itemname, DateTime startDate, DateTime endDate, int pageIndex, int pageSize) =>
            await UnitOfWork.ExpenseRepository.GetFilteredPagedAsync(itemname, startDate, endDate, pageIndex, pageSize);

        public async Task<int> RemoveAsync(Guid Id) {
            await UnitOfWork.ExpenseRepository.RemoveAsync(Id);
            return await UnitOfWork.CompleteAsync();
        }

        public async Task<int> UpdateAsync(Expense expense, Guid id) {
            Expense e = await UnitOfWork.ExpenseRepository.FindAsync(id);
            e.ItemName = expense.ItemName;
            e.Count = expense.Count;
            e.PricePerItem = expense.PricePerItem;
            e.Date = expense.Date;
            e.Description = expense.Description;
            return await UnitOfWork.CompleteAsync();
        }
    }
}
