using AnalyticsBE.Models;
using Microsoft.PowerBI.Api;

namespace AnalyticsBE.Services.Interfaces
{
    public interface IPowerBIModelService 
    {

        public Task<List<EmbeddedDataset>> GetDatasets();
        public Task<string> getAccessToken();

    }
}
