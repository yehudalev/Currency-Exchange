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
    public class LiveModel :INotifyPropertyChanged
    {
        public LiveModel(DateTime date, string curOr, string curFo, string val)
        {
            this.Date = date;
            this.CurrencyOrigin = curOr;
            this.CurrencyForegin = curFo;
            this.Value = val;
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        [Display(Name = "Last Update", Order = 1)]
        private DateTime date;
        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                if (this.date != value)
                {
                    this.date = value;
                    this.OnPropertyChanged("Date");
                }
            }
        }
        [Display(Name = "Origin Currency", Order = 2)]
        private string currencyOrigin;
        public string CurrencyOrigin
        {
            get
            {
                return this.currencyOrigin;
            }
            set
            {
                if (this.currencyOrigin != value)
                {
                    this.currencyOrigin = value;
                    this.OnPropertyChanged("CurrencyOrigin");
                }
            }

        }
        [Display(Name = "Foreign Currency ", Order = 3)]
        private string currencyForeign;
        public string CurrencyForeign
        {
            get
            {
                return this.currencyForeign;
            }
            set
            {
                if (this.currencyForeign != value)
                {
                    this.currencyForeign = value;
                    this.OnPropertyChanged("Foreign");
                }
            }
        }

       

        [Display(Name = "Rate", Order = 4)]
        private string value;
        public string Value
        {
            get
            {
                return this.value;
            }

            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    this.OnPropertyChanged("Value");
                }
            }
        }



        [Display(Name = "Change", Order = 5)]
        private long change;
        public long Change
        {
            get
            {
                return this.change;
            }
            set
            {
                if (change != value)
                {
                    this.change = value;
                    this.OnPropertyChanged("Change");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
