using BE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDAL
    {
        double convert(string from, string to, string amount);
        ICollection<Currency> getListCurrencies();
        ICollection<HistoricalRateData> getLiveCurrencies();
        ICollection<HistoricalRateData> getRatesByRange(DateTime from, DateTime to);
        ICollection<HistoricalRateData> getRatesByDate(DateTime date);
        //diagnos
        void initHistoryRatesAnnual();

    }
}
