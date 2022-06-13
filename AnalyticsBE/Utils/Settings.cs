using System;  
using System.Configuration; 

namespace AnalyticsBE.Utils

{
    public class Settings
    {
        public static Settings Default { get; set; } = new Settings();
        public  string ClientId
        {
            get { return  System.Configuration.ConfigurationManager.AppSettings["ida:ClientID"]; }

        }

        public  string Key
        {
            get {var config = new ConfigurationRoot(null);
                return config.GetSection("appSettings").GetSection("ServicePrincipalApp").GetSection("ClientId").Value ;
               }
        }

        public  string AzureAdTenantId
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["ida:TenantId"]; }
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
}
