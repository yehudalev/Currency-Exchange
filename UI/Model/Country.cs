using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Model
{
    public class Country
    {
        public Country(string countryName, string code)
        {
            this.NameCountry = countryName;
            this.CodeCountry = code;
        }

        public string NameCountry { get; set; }
        public string CodeCountry { get; set; }

        
    }
}
