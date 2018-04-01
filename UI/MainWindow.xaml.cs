using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BL;
using BE;
using System.Threading;
using System.Net.Http;


namespace UI
{



    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            //ModelView.LiveModelView liveModels = new ModelView.LiveModelView();

            IBL myBL = BL.Factory.getBL();
            
            //myBL.initHistoryRatesAnnual();

           // DataContext = myBL.getRatesByRange(new DateTime(2017, 3, 26), DateTime.Today);

           // ICollection<HistoricalRateData> liveCurrencies = myBL.getLiveCurrencies();
            
            
        }

        
    }
    
}
