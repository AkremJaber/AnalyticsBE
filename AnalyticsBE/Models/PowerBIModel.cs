using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Claims;


namespace AnalyticsBE.Models
{
    public class PowerBIModel
    {
        public string id;
        public string name;
        public string datasetId;
        public string embedUrl;
    }

    public class EmbeddedDataset
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public List<PowerBITable> tables { get; set; }
    }
    public class PowerBITable
    {
        public string name { get; set; }
        public List<PowerBIColumn> columns { get; set; }
    }
    public class PowerBIColumn
    {
        public string name { get; set; }
        public string dataType { get; set; }
    }
    public class PowerBITableRef
    {
        public Guid datasetId { get; set; }
        public string tableName { get; set; }
    }

    public class PowerBITableRows : PowerBITableRef
    {
        public List<Dictionary<string, object>> rows;
    }
    
}

