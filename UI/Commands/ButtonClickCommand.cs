using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.ViewModel;

namespace UI.Commands
{
    public class ButtonClickCommand : ICommand
    {

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            var historyModelView = (HistoryModelView)parameter;
            historyModelView.removeAllTLiveModelCollection();
            historyModelView.addToLiveModelCollection(historyModelView.dateFrom, historyModelView.dateTo);
        }
    }
}
