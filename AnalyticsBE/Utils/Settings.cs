using System;  
using System.Configuration; 

namespace AnalyticsBE.Utils

{
    public class Settings
    {

        public IConfigurationBuilder builder = new ConfigurationBuilder();
        
        public  string ClientId
        {
            get
            {
                
                builder.AddJsonFile("appSettings.json");
                var configurationRoot = builder.Build();
                return configurationRoot.GetSection("ServicePrincipalApp").GetSection("clientid").Value;
            }
        }

        public  string Key
        {
            get
            {
                
                builder.AddJsonFile("appSettings.json");
                var configurationRoot = builder.Build();
                return configurationRoot.GetSection("ServicePrincipalApp").GetSection("ClientSecret").Value;
            }
        }

        public  string AzureAdTenantId
        {
            get
            {
                builder.AddJsonFile("appSettings.json");
                var configurationRoot = builder.Build();
                return configurationRoot.GetSection("ServicePrincipalApp").GetSection("TenantId").Value;
            }
        }

        public  string PowerBIResourceId
        {
            get { return "https://analysis.windows.net/powerbi/api"; }
        }

        public  string AzureAdGraphResourceId
        {
            get { return "https://graph.windows.net"; }
        }

        public  string AzureADAuthority
        {
            get { return string.Format("https://login.windows.net/{0}/", AzureAdTenantId); }
        }

        public  string ClaimTypeObjectIdentifier
        {
            get { return "http://schemas.microsoft.com/identity/claims/objectidentifier"; }
        }
    }
    //public string Key
    //{
    //    get
    //    {
    //        var config = new ConfigurationRoot(null);
    //        return config.GetSection("appSettings").GetSection("ServicePrincipalApp").GetSection("ClientId").Value;
    //    }

    //public string ClientId
    //{
    //    get { return System.Configuration.ConfigurationManager.AppSettings["ida:ClientID"]; }

    //}
}

