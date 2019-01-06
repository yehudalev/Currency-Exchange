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
    public class ExchangeViewModel : INotifyPropertyChanged
    {
        public ExchangeViewModel()
        {
            namesCountry = (from i in getListCurrencies()
                           select i.NameCountry).ToList();
        }
        public ExchangeModel exchange { get; set; }

        public ICollection<string> namesCountry { get; set; }

        public string selectedOriginItem { get; set; }

        public string selectedForeignItem { get; set; }

        public string amount { get; set; }

        public string Result
        {
            get
            {
                return this.result;
            }

            set
            {
                if (result != value)
                {
                    result = value;
                    this.OnPropertyChanged("Result");
                }
            }
                    
        }

        private string result;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICollection<Country> getListCurrencies()
        {
            ICollection<Country> countries = new Collection<Country>();
            IBL myBL = Factory.getBL();
            ICollection<Currency> currencies = myBL.getListCurrencies();
            foreach (Currency item in currencies)
            {
                countries.Add(new Country(item.countryName, item.currencyName));
            }

            return countries;
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ICommand CurrencyConvertCommand { get { return new CurrencyConvertCommand(); } }

        //very specific func
        public double computeExchange(string strSource, double factor)  //not support select origin currency
        {
            ICollection<HistoricalRateData> resReq = new Collection<HistoricalRateData>();
            IBL myBL = Factory.getBL();
            resReq = myBL.getLiveCurrenciesSpecifyOutputCurrencies(new Dictionary<string, string> { { "currencies", strSource } });
            return Convert.ToDouble(resReq.First().valueRate) * factor;
        }

    }

}
