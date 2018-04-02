using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BE;
using BL;
using UI.Model;
using UI.Commands;
using System.ComponentModel;

namespace UI.ViewModel
{
    public class CurrencyExchangeModelView : ObservableCollection<Country>
    {

        public CurrencyExchangeModelView()
        {
            IBL myBL = Factory.getBL();
            ICollection<Currency> currencies = myBL.getListCurrencies();
            foreach(Currency item in currencies)
            {
                Add(new Country(item.countryName, item.currencyName));
            }
        }

        public string countrySource { get; set; }
        public string countryTarget { get; set; }
        public string sum { get; set; }


    }
        
          

}
