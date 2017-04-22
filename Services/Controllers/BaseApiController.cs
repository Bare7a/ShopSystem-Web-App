using Data;
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

        public ShopContext Data { get; set; }
    }
}