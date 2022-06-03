using AnalyticsBE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnalyticsBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerBIController : ControllerBase
    {
        [HttpGet]
        public async Task<List<PowerBIDataset>> GetDatasets()
        {
            return await PowerBIModel.GetDatasets();
        }

        [HttpGet]
        public async Task<PowerBIDataset> GetDataset(Guid id)
        {
            return await PowerBIModel.GetDataset(id);
        }

        [HttpPost]
        public async Task<Guid> CreateDataset(PowerBIDataset dataset)
        {
            return await PowerBIModel.CreateDataset(dataset);
        }

        [HttpPost]
        public async Task<bool> ClearTable(PowerBITableRef tableRef)
        {
            return await PowerBIModel.ClearTable(tableRef.datasetId, tableRef.tableName);
        }

        [HttpPost]
        public async Task<bool> AddTableRows(PowerBITableRows rows)
        {
            return await PowerBIModel.AddTableRows(rows.datasetId, rows.tableName, rows.rows);
        }
    }
}
