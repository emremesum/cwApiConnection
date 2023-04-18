using cwApi1.Models;
using Eclit.Integrator.Core.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cwApi1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpGet("company")]
        public IEnumerable<Companies> GetCompany()
        {
            cwConnect cwConnect = new cwConnect();
            IEnumerable<Companies> companies = cwConnect.GetCompanies();


            return companies;
        }

    }
}
