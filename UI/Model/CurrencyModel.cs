using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Model
{
    public class CurrencyModel: INotifyPropertyChanged
    {
        public CurrencyModel(DateTime date, string curOr, string curFo, string val)
        {
            this.date = date;
            this.currencyOrigin = curOr;
            this.currencyForeign = curFo;
            this.value = val;
            //this.change = change;
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


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



        //[Display(Name = "Change", Order = 5)]
        //private long change;
        //public long Change
        //{
        //    get
        //    {
        //        return this.change;
        //    }
        //    set
        //    {
        //        if (change != value)
        //        {
        //            this.change = value;
        //            this.OnPropertyChanged("Change");
        //        }
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;
    }
}


