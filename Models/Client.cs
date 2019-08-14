using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SellContracts.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Display(Name = "Клиент")]
        public string Name { get; set; }
        public string Company { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
        public Client()
        {
            Sales = new List<Sale>();
        }
        public int? CityId { get; set; }
        public City City { get; set; }
    }
}