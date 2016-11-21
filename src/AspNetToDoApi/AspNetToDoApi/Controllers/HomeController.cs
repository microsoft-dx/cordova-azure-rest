using System.Web.Http;

namespace AspNetToDoApi.Controllers
{
    public class HomeController : ApiController
    {
        // GET: Home
        [HttpGet]
        public IHttpActionResult Index()
        {
            return Ok<string>("Todo API is up and running...");
        }
    }
}