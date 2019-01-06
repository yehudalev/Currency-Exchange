using BE;
using DAL.EF;
using DAL.json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
    class Dal_with_DB : IDAL
    {

        string url = "http://apilayer.net/api/";
        string key = "df5a28be08c7263dc884d0f87b71e914";
        CurrencyLayerApi instance { get; set; }

        public Dal_with_DB()
        {
            this.instance = new CurrencyLayerApi(url, key);
        }

        //retuen enumrable DateTime by given date range 
        static public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        //convert unix stamp to DateTime .net class
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public ICollection<HistoricalRateData> addRatesByDate(DateTime date)
        {
            using (var ctx = new RatesDBContext())
            {
                List<HistoricalRateData> res = new List<HistoricalRateData>();
                res = ctx.histories.SqlQuery("SELECT * FROM dbo.HistoricalRateDatas WHERE dateTime = @p0", date.ToString()).ToList<HistoricalRateData>();
                if (res.Count != 0)
                {
                    return res;
                }
                var historicalData = instance.Invoke<DAL.json.HistoryModel>("historical", new Dictionary<string, string>
                {
                     { "date", date.ToString("yyyy-MM-dd") }
                });

                ICollection<HistoricalRateData> list = historicalData.Result.quotes.Select(p => new HistoricalRateData(date, p.Key, p.Value)).ToList();
                ctx.histories.AddRange(list);
                ctx.SaveChanges();

                return list;
            }
        }

        public double convert(string from, string to, string amount)
        {
            var conversion = instance.Invoke<json.Conversion>("convert", new Dictionary<string, string>
            {
                 { "from", from },
                 { "to", to },
                 { "amount", amount }
            });
            double res = conversion.Result.Result;
            return res;
        }

        public ICollection<Currency> getListCurrencies()
        {
            using (var ctx = new RatesDBContext())
            {
                List<Currency> res = new List<Currency>();
                res = ctx.currencies.SqlQuery("SELECT * FROM dbo.Currencies").ToList<Currency>();
                if (res.Count == 0)
                {
                    var listCurr = instance.Invoke<DAL.json.CurrencyListModel>("list");
                    ICollection<Currency> list = listCurr.Result.quotes.Select(p => new Currency(p.Key, p.Value)).ToList();
                    ctx.currencies.AddRange(list);
                    ctx.SaveChanges();
                    return list;
                }

                return res;
            }
        }

        public ICollection<HistoricalRateData> getLiveCurrencies()
        {
            var liveList = instance.Invoke<DAL.json.Live>("live");
            ICollection<HistoricalRateData> list = liveList.Result.quotes.Select(p => new HistoricalRateData(UnixTimeStampToDateTime(liveList.Result.Timestamp), p.Key, p.Value)).ToList();
            return list;
        }

        public ICollection<HistoricalRateData> getLiveCurrenciesSpecifyOutputCurrencies(Dictionary<string, string> dictionary)
        {
            var liveList = instance.Invoke<DAL.json.Live>("live", dictionary);
            ICollection<HistoricalRateData> list = liveList.Result.quotes.Select(p => new HistoricalRateData(UnixTimeStampToDateTime(liveList.Result.Timestamp), p.Key, p.Value)).ToList();
            return list;
        }

        //get rates by date
        public ICollection<HistoricalRateData> getRatesByDate(DateTime date)
        {
            using (var ctx = new RatesDBContext())
            {
                List<HistoricalRateData> res = new List<HistoricalRateData>();
                res = ctx.histories.SqlQuery("SELECT * FROM dbo.HistoricalRateDatas WHERE dateTime = @p0", date.ToString()).ToList<HistoricalRateData>();
                if (res.Count == 0)
                {
                    //no exist in Db, making service request
                    return addRatesByDate(date);
                }
                return res;

            }
        }

        //get rates by range 
        public ICollection<HistoricalRateData> getRatesByRange(DateTime from, DateTime to)
        {
            ICollection<HistoricalRateData> myCollection = new List<HistoricalRateData>();
            foreach (DateTime item in EachDay(from, to))
            {
                //each day we call addRatesByDate func
                ICollection<HistoricalRateData> tmpList = new List<HistoricalRateData>(addRatesByDate(item));
                foreach (HistoricalRateData item1 in tmpList)
                    myCollection.Add(item1);
            }
            return myCollection;
        }

        public void initHistoryRatesAnnual()
        {

            using (var ctx = new RatesDBContext())
            {
                getRatesByRange(new DateTime(2017, 1, 1), new DateTime(2018, 3, 22));
            }
        }

    }
}

