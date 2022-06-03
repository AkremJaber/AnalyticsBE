namespace AnalyticsBE.Models
{
    public class PowerBIDataset
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public List<PowerBITable> tables { get; set; }
    }
}
