using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
namespace DentalClinic.Domain.Services {
    public interface IReportService {
        public Task<Dictionary<string, int>> GetCountsAsync();
        public Task<List<Object>> GetVisitsCountRangeAsync(DateTime startDate, DateTime endDate);
    }
}
