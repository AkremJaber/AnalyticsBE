using AnalyticsBE.Models;
using AnalyticsBE.Services.Interfaces;
using AnalyticsBE.Utils;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.PowerBI.Api;
using Microsoft.PowerBI.Api.Models;
using Microsoft.Rest;
using Newtonsoft.Json.Linq;
using System.Security.Claims;

namespace AnalyticsBE.Services.Implementations
{
    public class PowerBIModelImpl : IPowerBIModelService
    {
         Uri baseAddress = new Uri("https://api.powerbi.com/beta/myorg/");
        public IConfiguration configuration;

        public PowerBIModelImpl (IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<List<EmbeddedDataset>> GetDatasets()
        {
            List<EmbeddedDataset> datasets = new List<EmbeddedDataset>();
            var token = await getAccessToken();

            using (var client = new HttpClient { BaseAddress = baseAddress })
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Add("Accept", "application/json; odata=verbose");

                using (var response = await client.GetAsync(String.Format("{0}/datasets", baseAddress)))
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    JObject oResponse = JObject.Parse(responseString);
                    datasets = oResponse.SelectToken("datasets").ToObject<List<EmbeddedDataset>>();
                }
            }

            return datasets;
        }

        public async Task<string> getAccessToken()
        {
            var setting = new Settings();
            // Create auth context (note: token is not cached)
            AuthenticationContext authContext = new AuthenticationContext(setting.AzureADAuthority);

            // Create client credential
            var clientCredential = new ClientCredential(setting.ClientId, setting.Key);

            // Get user object id
            var userObjectId = ClaimsPrincipal.Current.FindFirst(setting.ClaimTypeObjectIdentifier).Value;

            // Get access token for Power BI
            // Call Power BI APIs from Web API on behalf of a user
            Task<AuthenticationResult> test = authContext.AcquireTokenAsync(setting.PowerBIResourceId, clientCredential, new UserAssertion(userObjectId, UserIdentifierType.UniqueId.ToString()));
            return test.Result.AccessToken;
        }
    }
}
