using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Currency
    {
        public Currency(string currencyName, string countryName)
        {
            this.countryName = countryName;
            this.currencyName = currencyName;
        }

        public string countryName { get; set; }
        public string currencyName { get; set; }
    }
}
