namespace AnalyticsBE.Models
{
    public class Dashboard
    {
        public int Id { get; set; }
        public string DashName { get; set; }
        public string EmbedUrl { get; set; }
        public string AccessToken { get; set; }
        public Boolean IsReadOnly { get; set; }
    }
}
