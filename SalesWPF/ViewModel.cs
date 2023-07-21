using ClassLibrary;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWPF
{
    [AddINotifyPropertyChangedInterface]
    internal class ViewModel
    {
        private SalesDB dbase { get; init; }
        private readonly string[] tNames = { "Sales", "Buyers", "Sellers" };

        public int SelectedIndex { get; set; }
        public ViewModel(SalesDB db)
        {
            dbase = db;
            SelectedIndex = 0;
        }
        [DependsOn("SelectedIndex")]
        public IEnumerable<object> Source 
        {
            get
            {
                if (SelectedIndex == 0) return dbase.GetAllSales;
                else if(SelectedIndex == 1)  return dbase.GetAllBuyers;
                else return dbase.GetAllSellers;
            }
        }
        public IEnumerable<string> TablesNames => tNames;
    }
}
