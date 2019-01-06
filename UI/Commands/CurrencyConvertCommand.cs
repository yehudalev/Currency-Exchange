using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.ViewModel;

namespace UI.Commands
{
    class CurrencyConvertCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var exchangeViewModel = (ExchangeViewModel)parameter;

            if (exchangeViewModel.selectedForeignItem != null && exchangeViewModel.selectedOriginItem != null && exchangeViewModel.amount != null)
            {
                exchangeViewModel.Result = exchangeViewModel.computeExchange(exchangeViewModel.selectedForeignItem, Convert.ToDouble(exchangeViewModel.amount)).ToString();
            } 
        }
    }
}
