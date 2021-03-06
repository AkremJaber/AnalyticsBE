using AnalyticsBE.Models;
using AnalyticsBE.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Microsoft.PowerBI.Api.Models;

namespace AnalyticsBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class PowerBIController : ControllerBase
    {
        public  IPowerBIModelService pbis;
        

        public PowerBIController(IPowerBIModelService pbis )
        {
            this.pbis = pbis;
            
        }

        [HttpGet]
        public async Task<List<Dataset>> GetDatasets()
        {

            return await pbis.GetDatasets();
        }






    }
}
