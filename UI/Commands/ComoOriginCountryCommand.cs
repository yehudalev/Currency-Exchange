using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.ViewModel;

namespace UI.Commands
{
    public class ComoOriginCountryCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var liveViewModel = (LiveViewModel)parameter;
            liveViewModel.liveCollection = new System.Collections.ObjectModel.ObservableCollection<Model.LiveModel>();
            liveViewModel.liveCollection = liveViewModel.getLiveCurrencies(); //current plan does not support select source 
        }
    }
}
