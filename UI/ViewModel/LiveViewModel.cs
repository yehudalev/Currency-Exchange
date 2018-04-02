using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;
using UI.Model;

namespace UI.ViewModel
{
    public class LiveViewModel
    {
        
        public ObservableCollection<LiveModel> liveCollection { get; set; }

        public LiveViewModel()
        {
            IBL myBL = Factory.getBL();

            liveCollection = new ObservableCollection<LiveModel>();
    
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
            
        }




    }
}
