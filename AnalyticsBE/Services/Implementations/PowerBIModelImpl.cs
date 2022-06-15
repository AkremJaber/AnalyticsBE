using AnalyticsBE.Models;
using AnalyticsBE.Services.Interfaces;
using AnalyticsBE.Utils;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.PowerBI.Api;
using Microsoft.PowerBI.Api.Models;
using Microsoft.Rest;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Security.Claims;

namespace AnalyticsBE.Services.Implementations
{
    public class PowerBIModelImpl : IPowerBIModelService
    {
        public Uri baseAddress = new("https://api.powerbi.com/v1.0/myorg/");
        public const string powerbiApiDefaultScope = "https://analysis.windows.net/powerbi/api/.default";
        public string urlPowerBiServiceApiRoot { get; }
        public IConfiguration configuration;
        public ITokenAcquisition tokenAcquisition { get; }

        public PowerBIModelImpl(IConfiguration configuration, ITokenAcquisition tokenAcquisition)
        {
            this.configuration = configuration;
            this.tokenAcquisition = tokenAcquisition;
        }

        public async Task<List<Dataset>> GetDatasets()
        {
            List<Dataset> datasets = new List<Dataset>();
            var token = getAccessToken();

            using (var client = new HttpClient { BaseAddress = baseAddress })
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Add("Accept", "application/json; odata=verbose");

                using (var response = await client.GetAsync(String.Format("{0}/datasets", baseAddress)))
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    
                    JObject oResponse = JObject.Parse(responseString);
                     datasets = oResponse.SelectToken("datasets").ToObject<List<Dataset>>();
                }
            }
            return datasets;
        }


        public string getAccessToken()
        {
            return this.tokenAcquisition.GetAccessTokenForAppAsync(powerbiApiDefaultScope).Result;
            //var setting = new Settings();
            //// Create auth context (note: token is not cached)
            //AuthenticationContext authContext = new AuthenticationContext(setting.AzureADAuthority);

            //// Create client credential
            //var clientCredential = new ClientCredential(setting.ClientId, setting.Key);

            //////Get user object id
            //ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal();
            //var userObjectId = claimsPrincipal.FindFirst(setting.ClaimTypeObjectIdentifier).Value;

            //// Get access token for Power BI
            //// Call Power BI APIs from Web API on behalf of a user
            //Task<AuthenticationResult> test = authContext.AcquireTokenAsync(setting.PowerBIResourceId, clientCredential, new UserAssertion(userObjectId, UserIdentifierType.UniqueId.ToString()));
            //return test.Result.AccessToken;
        }

        public PowerBIClient GetPowerBiClient()
        {
            var tokenCredentials = new TokenCredentials(getAccessToken(), "Bearer");
            return new PowerBIClient(new Uri(urlPowerBiServiceApiRoot), tokenCredentials);
        }

    }

   
}
