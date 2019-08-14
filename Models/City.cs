using System.Collections.Generic;

namespace SellContracts.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Client> Clients { get; set; }
        public City()
        {
            Clients = new List<Client>();
        }
    }
}