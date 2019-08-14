using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellContracts.Models
{
    public class Sale
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Код агента")]
        [ForeignKey("Agent")]
        public int? AgentId { get; set; }
        public Agent Agent { get; set; }
        [Display(Name = "Код контрагента")]
        [ForeignKey("Client")]
        public int? ClientId { get; set; }
        public Client Client { get; set; }

    }
}