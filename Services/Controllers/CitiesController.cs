using Data.Models;
using Services.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Services.Controllers
{
    public class CitiesController : BaseApiController
    {
        [HttpGet]
        public IEnumerable<CityViewModel> GetCities()
        {
            var cities = this.Data.Cities
                .Select(c => new CityViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).OrderBy(c => c.Id);

            return cities;
        }

        public IHttpActionResult GetCityById(int id)
        {
            var city = this.Data.Cities.Select(c => new CityViewModel
            {
                Id = c.Id,
                Name = c.Name
            }).FirstOrDefault(x => x.Id == id);

            if (city == null)
            {
                return this.BadRequest("City #" + id + " not found!");
            }

            return this.Ok(city);
        }
    }
}