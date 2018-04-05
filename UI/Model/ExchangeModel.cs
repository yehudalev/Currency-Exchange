using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Model
{
    public class ExchangeModel : INotifyPropertyChanged
    {
        public ExchangeModel(DateTime date, string curOr, string curFo, string res)
        {
            this.date = date;
            this.currencyOrigin = curOr;
            this.currencyForeign = curFo;
            this.result = res;
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




        private string result;
        public string Result
        {
            get
            {
                return this.result;
            }

            set
            {
                if (this.result != value)
                {
                    this.result = value;
                    this.OnPropertyChanged("Result");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

