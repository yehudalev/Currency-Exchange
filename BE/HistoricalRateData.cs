using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class HistoricalRateData
    {

        public HistoricalRateData()
        {

        }

        public HistoricalRateData(DateTime dTime, string name, string value)
        {
            this.dateTime = dTime;
            this.src_trg_currency = name;
            this.valueRate = value;
        }

        [Key]
        [Column(Order = 1)]
        public string src_trg_currency { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime dateTime { get; set; }

        public string valueRate { get; set; }
    }
}
