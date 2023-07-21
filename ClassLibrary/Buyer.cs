using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Buyer
    {
        public int Id { get; set; }
        public string? Name { get; init; }
        public string? Surname { get; init; }
        public Buyer() { }
        public override string ToString()
        {
            return $"BuyerID: {Id}  Name: {Name} Surname: {Surname}";
        }
    }
}
