﻿using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IBL
    {
        ICollection<HistoricalRateData> getLiveCurrenciesSpecifyOutputCurrencies(Dictionary<string, string> dictionary);
        double convert(string from, string to, string amount);
        ICollection<Currency> getListCurrencies();
        ICollection<HistoricalRateData> getLiveCurrencies();
        ICollection<HistoricalRateData> getRatesByRange(DateTime from, DateTime to);
        ICollection<HistoricalRateData> getRatesByDate(DateTime date);
        //diagnos
        void initHistoryRatesAnnual();


    }
}
