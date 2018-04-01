using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BL_imp : IBL
    {
        //day instance
        IDAL myDal = DAL.Factory.getDAL();

        public double convert(string from, string to, string amount)
        {
            return myDal.convert(from, to, amount);
        }

        public ICollection<Currency> getListCurrencies()
        {
            return myDal.getListCurrencies();
        }

        public ICollection<HistoricalRateData> getLiveCurrencies()
        {
            return myDal.getLiveCurrencies();
        }

        public ICollection<HistoricalRateData> getRatesByDate(DateTime date)
        {
            return myDal.getRatesByDate(date);
        }

        public ICollection<HistoricalRateData> getRatesByRange(DateTime from, DateTime to)
        {
            return myDal.getRatesByRange(from, to);
        }

        public void initHistoryRatesAnnual()
        {
            myDal.initHistoryRatesAnnual();
        }

    }
}
