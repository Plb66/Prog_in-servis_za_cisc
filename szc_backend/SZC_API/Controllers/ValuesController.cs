using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Http;
using SZC_API.Models;
using System.Web.Http.Cors;
using System.Security.Principal;
using System.Web.Routing;

namespace SZC_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
    [RoutePrefix("")]
    public class ValuesController : ApiController
    {
        
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/getAllClients")]
        public List<Models.Klijenti> getAllClients()
        {
            return new Services.Database().getAllClients();
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/log_in")]
        public List<Models.Klijenti> log_in([Microsoft.AspNetCore.Mvc.FromBody] Klijenti k)
        {
            return new Services.Database().log_in(k);
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/getAllCleanups")]
        public List<Models.Ciscenja> getAllCleanups()
        {
            return new Services.Database().getAllCleanups();
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/getAllRequests")]
        public List<Models.Zahtjevi> getAllRequests()
        {
            return new Services.Database().getAllRequests();
        }
        
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/sendRequest")]
        public Zahtjevi sendRequest([Microsoft.AspNetCore.Mvc.FromBody] Zahtjevi z)
        {
            return new Services.Database().sendRequest(z);
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/addClient")]
        public Klijenti addClient([Microsoft.AspNetCore.Mvc.FromBody] Klijenti k)
        {
            return new Services.Database().addClient(k);
        }
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/deleteClient")]
        public Klijenti deleteClient([Microsoft.AspNetCore.Mvc.FromBody] Klijenti k)
        {
            return new Services.Database().deleteClient(k);
        }
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/changeRequest")]
        public Zahtjevi changeRequest([Microsoft.AspNetCore.Mvc.FromBody] Zahtjevi z)
        {
            return new Services.Database().changeRequest(z);
        }
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/editClient")]
        public Klijenti editClient([Microsoft.AspNetCore.Mvc.FromBody] Klijenti k)
        {
            return new Services.Database().editClient(k);
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/getClient")]
        public List<Models.Klijenti> getClient([Microsoft.AspNetCore.Mvc.FromBody] Klijenti k)
        {
            return new Services.Database().getClient(k);
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/getRequestStatus")]
        public List<Models.Zahtjevi> getRequestStatus([Microsoft.AspNetCore.Mvc.FromBody] Zahtjevi z)
        {
            return new Services.Database().getRequestStatus(z);
        }
    }
}
