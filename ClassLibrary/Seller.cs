using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Seller
    {
        public int Id { get; set; }
        public string? Name { get; init; }
        public string? Surname { get; init; }
        public Seller() { }
        public override string ToString()
        {
            return $"SellerID: {Id}  Name: {Name} Surname: {Surname}";
        }
    }
}
