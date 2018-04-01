using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

        public DateTime Date { get; set; }
        public string CurrencyOrigin { get; set; }
        public string CurrencyForegin { get; set; }
        public string Value { get; set; }

      
    }
}
