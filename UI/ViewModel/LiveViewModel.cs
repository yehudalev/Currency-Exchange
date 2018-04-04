using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BE;
using BL;
using UI.Commands;
using UI.Model;

namespace UI.ViewModel
{
    public class LiveViewModel
    {
        
        public LiveViewModel()
        {
            liveCollection = this.getLiveCurrencies();
            namesCountry = (from i in getListCurrencies()
                            select i.NameCountry).ToList();

        }

        public ObservableCollection<LiveModel> liveCollection { get; set; }

        public ICollection<string> namesCountry { get; set; }

        public string selectedItem { get; set; }

        public ObservableCollection<LiveModel> getLiveCurrencies()
        {
            IBL myBL = Factory.getBL();

            ObservableCollection<LiveModel>  liveCollection = new ObservableCollection<LiveModel>();
    
            ICollection<HistoricalRateData> historicalRates = myBL.getLiveCurrencies();
            ICollection<Currency> list = myBL.getListCurrencies();
            foreach (HistoricalRateData item in historicalRates)
            {

                string from = (from l in list
                               where l.currencyName == item.src_trg_currency.Substring(0, 3)
                               select l).First().countryName;

                string to = (from l in list
                             where l.currencyName == item.src_trg_currency.Substring(3, 3)
                             select l).First().countryName;

                liveCollection.Add(new LiveModel(item.dateTime, from, to, item.valueRate));
            }

            return liveCollection;
        }

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

        public ICommand ButtonClickUpdateLiveCommand { get { return new ButtonClickUpdateLiveCommand(); } }
        
    }
}
