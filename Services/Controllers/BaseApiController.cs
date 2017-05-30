using Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Services.Controllers
{
    public class BaseApiController : ApiController
    {
        public BaseApiController() : this(new ShopContext())
        {
        }

        public BaseApiController(ShopContext data)
        {
            this.Data = data;
        }

        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

        public ShopContext Data { get; set; }
    }
}