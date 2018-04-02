using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Model
{
    public class LiveModel //: INotifyPropertyChanged
    {
        public LiveModel(DateTime date, string curOr, string curFo, string val)
        {
            this.Date = date;
            this.CurrencyOrigin = curOr;
            this.CurrencyForegin = curFo;
            this.Value = val;
        }

        [Display(Name = "Date", Order = 1)]
        public DateTime Date { get; set; }
        [Display(Name = "Origin", Order = 2)]
        public string CurrencyOrigin { get; set; }
        [Display(Name = "Foregin", Order = 3)]
        public string CurrencyForegin { get; set; }
        [Display(Name = "Rate", Order = 4)]
        public string Value { get; set; }

      
    }
}
