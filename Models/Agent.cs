using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SellContracts.Models
{
    public class Agent
    {
        public int Id { get; set; }

        [Display(Name = "Продавец")]
        public string Name { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
        public Agent()
        {
            Sales = new List<Sale>();
        }
    }
}