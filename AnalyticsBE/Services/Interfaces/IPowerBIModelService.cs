using AnalyticsBE.Models;
using Microsoft.PowerBI.Api;
using Microsoft.PowerBI.Api.Models;

namespace AnalyticsBE.Services.Interfaces
{
    public interface IPowerBIModelService 
    {

        public Task<List<Dataset>> GetDatasets();

        public string getAccessToken();

        public PowerBIClient GetPowerBiClient();

        //public string GetAccessToken();

        //public PowerBIClient GetPowerBiClient();

        //public async Task<EmbeddedReportViewModel> GetReport(Guid WorkspaceId, Guid ReportId);



    }
}
