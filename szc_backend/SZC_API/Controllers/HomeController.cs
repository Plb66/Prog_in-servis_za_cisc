using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;

namespace bookmarks4projects.Controllers
{
    [EnableCors(origins: "http://localhost:44335", headers: "*", methods: "*")]
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index()
        {
            // var mUser = new BookmarkDataController().GetWindowsUser();
            return View();
        }

        public IActionResult Error()
        {
            //ViewData["RequestId"] = Activity.Current.Id ?? System.Web.HttpContext.TraceIdentifier;
            return View();
        }
    }
}
