using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class City
    {
        private ICollection<User> users;

        public City()
        {
            this.users = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}
