using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UI.Model;
using UI.View;
using UI.ViewModel;

namespace UI.Commands
{
    public class ButtonClickUpdateLiveCommand : ICommand
    {

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var liveViewModel = (LiveViewModel)parameter;
            ObservableCollection<LiveModel> currentliveCollection = new ObservableCollection<LiveModel>();
            currentliveCollection = liveViewModel.getLiveCurrencies();
            if (liveViewModel.liveCollection.First().Date == currentliveCollection.First().Date)
                MessageBox.Show("there are no updates");
            foreach(LiveModel item in liveViewModel.liveCollection)
                foreach (LiveModel item1 in currentliveCollection)
                {
                    if (item.CurrencyOrigin == item1.CurrencyOrigin && item.CurrencyForeign == item1.CurrencyOrigin)
                    {
                        item.Date = item1.Date;
                        item.Value = item1.Value;
                    }
                }
        }
    }
}