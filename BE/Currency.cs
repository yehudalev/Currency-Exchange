using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Currency
    {
        public Currency()
        {

        }

        public Currency(string currencyName, string countryName)
        {
            this.countryName = countryName;
            this.currencyName = currencyName;
        }

        [Key]
        public string currencyName { get; set; }
        public string countryName { get; set; }

    }
}
