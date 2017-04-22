using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Country
    {
        private ICollection<City> cities;

        public Country()
        {
            this.cities = new HashSet<City>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        public ICollection<City> Cities
        {
            get { return this.cities; }
            set { this.cities = value; }
        }
    }
}