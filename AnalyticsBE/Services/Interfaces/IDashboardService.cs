using AnalyticsBE.Models;

namespace AnalyticsBE.Services.Interfaces
{
    public interface IDashboardService
    {
        void CreateDashboard(Dashboard dashboard);
        void ListDashboards(Dashboard dashboard);
    }
}
