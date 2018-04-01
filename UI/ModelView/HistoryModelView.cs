using BE;
using BL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.Commands;
using UI.Model;

namespace UI.ModelView
{
    public class HistoryModelView : ObservableCollection<LiveModel>
    {


        public HistoryModelView() 
        {
            addToLiveModelCollection(new DateTime(2017, 1, 1), DateTime.Today);
        }

        public void addToLiveModelCollection(DateTime from, DateTime to)
        {
            IBL myBL = Factory.getBL();
            ICollection<HistoricalRateData> historicalRates = myBL.getRatesByRange(from, to);
            ICollection<Currency> list = myBL.getListCurrencies();
            foreach (HistoricalRateData item in historicalRates)
            {

                string from1 = (from l in list
                               where l.currencyName == item.src_trg_currency.Substring(0, 3)
                               select l).First().countryName;

                string to1 = (from l in list
                             where l.currencyName == item.src_trg_currency.Substring(3, 3)
                             select l).First().countryName;

                Add(new LiveModel(item.dateTime, from1, to1, item.valueRate));
                
            }
            
        }

        public void removeAllTLiveModelCollection()
        {
            int i = this.Count() - 1;
            while(i != -1)
            {
                RemoveItem(i);
                i--;
            }
            int j = this.Count();
        }

        public DateTime dateFrom { get; set; }

        public DateTime dateTo { get; set; }

        public ICommand ButtonClickCommand
        {
          get
          {
                return new ButtonClickCommand();
          }
        }
        
    }
}
