using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Sale
    {
        public int Id { get; init; }
        public int SellerId  { get; init; }
        public int BuyerId   { get; init; }
        public decimal SaleAmmount { get; init; }
        public DateOnly SaleDate   { get; init; }
        public Sale() {}
        public override string ToString()
        {
            return $"{Id,-4}    {SellerId,-4}    {BuyerId,-4}    {Math.Round(SaleAmmount,2),-8}    {SaleDate.ToShortDateString(),-10}";
        }
    }
}
