using RestSharp.Authenticators;
using RestSharp;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using cwApi1.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Eclit.Integrator.Core.Models
{
    public class cwConnect
    {
        public RestClient RestClient { get; }
        public string CWClientId { get; }

        public cwConnect()
        {
            CWClientId = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx";                                 // connectwise üzerinden taleb ediceğiniz id
            string cwUserName = "xxxxxxxxxxxxxxxx";                                             // eclit ileticek
            string cwPassword = "xxxxxxxxxxxxxxxx";                                             // eclit ileticek
            string cwApiBaseUrl = "https://api-eu.myconnectwise.net/v4_6_release/apis/3.0";     // connectwise-apiUrl

            cwUserName = String.Concat("eclit+", cwUserName);

            RestClient = new RestClient(cwApiBaseUrl);
            RestClient.Authenticator = new HttpBasicAuthenticator(cwUserName, cwPassword);

        }

      

        public IEnumerable<Companies>? GetCompanies()
        {
            var request = new RestRequest("/company/companies");
            request.AddHeader("clientId", CWClientId);
            //request.AddQueryParameter("conditions", "closedFlag=false and inactiveFlag=false");

            RestResponse restResponse = RestClient.Execute(request);
            var serializeOptions = new JsonSerializerOptions { WriteIndented = true };

            IEnumerable<Companies>? billingStatuses = JsonSerializer.Deserialize<IEnumerable<Companies>>(restResponse.Content, serializeOptions);
            return billingStatuses;
        }

   
    }
}
