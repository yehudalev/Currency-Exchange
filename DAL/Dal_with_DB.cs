using BE;
using DAL.EF;
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

        static public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        //internal use for the getRatesByDate function
        public ICollection<HistoricalRateData> addRatesByDate(DateTime date)
        {
            using (var ctx = new RatesDBContext())
            {
                List<HistoricalRateData> res = new List<HistoricalRateData>();
                res = ctx.histories.SqlQuery("SELECT * FROM dbo.HistoricalRateDatas WHERE dateTime = @p0", date.ToString()).ToList<HistoricalRateData>();
                if(res.Count != 0)
                {
                    return res;
                }
                var instance = new DAL.service.CurrencyLayerApi("http://apilayer.net/api/", "8ef596cb8c336f1f3aeb8edbe1d573e6");
                var historicalData = instance.Invoke<DAL.service.HistoryModel>("historical", new Dictionary<string, string>
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
            var instance = new DAL.service.CurrencyLayerApi("http://apilayer.net/api/", "8ef596cb8c336f1f3aeb8edbe1d573e6");
            var conversion = instance.Invoke<service.ConversionModel>("convert", new Dictionary<string, string>
            {
                 { "from", from },
                 { "to", to },
                 { "amount", amount }
            });
            double res = conversion.Result.Result;
            return res;
        }

        //public async Task<service.ForgeApiElement> WebApiRequestForgeAsync(string from, string to, string amount)
        //{
        //    service.ForgeApiElement res = null;
        //    string json_data = "";
        //    using (var w = new WebClient())
        //    {
        //        json_data = await w.DownloadStringTaskAsync("https://forex.1forge.com/1.0.3/convert?from="+ from +"&to=" + to +"&quantity="+ amount +"&api_key=WoIQdAVTDNQrbKUtv6tpZ9JFRapq27hs");
        //        if (!string.IsNullOrEmpty(json_data) &&     // protect from network problems
        //            json_data[0] == '[' &&                  // protect from Internet Rimon problems
        //            !json_data.Contains("\"error\":true"))  // protect from 1Forge problems
        //        {
        //            //var x = JsonConvert.DeserializeObject<ForgeApi>(json_data);
        //            var x = JsonConvert.DeserializeObject<List<service.ForgeApiElement>>(json_data);

        //            res = new service.ForgeApiElement
        //            {
        //                value = x[0].value,
        //                text = x[0].text,
        //                timestamp = x[0].timestamp
        //            };

        //        }

        //        return res;
        //    }
            
        //  }





        public ICollection<Currency> getListCurrencies()
        {
            var instance = new DAL.service.CurrencyLayerApi("http://apilayer.net/api/", "8ef596cb8c336f1f3aeb8edbe1d573e6");
            var listCurr = instance.Invoke<DAL.service.CurrencyListModel>("list");
            ICollection<Currency> list = listCurr.Result.quotes.Select(p => new Currency(p.Key, p.Value)).ToList();
            return list;
        }

        public ICollection<HistoricalRateData> getLiveCurrencies()
        {
            var instance = new DAL.service.CurrencyLayerApi("http://apilayer.net/api/", "8ef596cb8c336f1f3aeb8edbe1d573e6");
            var liveList = instance.Invoke<DAL.service.LiveModel>("live");
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

