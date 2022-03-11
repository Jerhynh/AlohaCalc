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

namespace AlohaCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public decimal UPTTransactionsNum { get; set; }
        public decimal UPTUnitsNum { get; set; }

        public decimal ADSSalesNum { get; set; }
        public decimal ADSTransactionsNum { get; set; }

        public decimal YTDPreviousNum { get; set; }
        public decimal YTDCurrentNum { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            var uri = new Uri("pack://application:,,,/logo.ico");
            LogoImg.Source = new BitmapImage(uri);
            UPTUnitsSold.Focus();
        }

        private void UPTTransactions_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                UPTTransactionsNum = decimal.Parse(UPTTransactions.Text);
                CalculateUPT();
            }
            catch (Exception)
            {
                return;
            }
        }

        private void UPTUnitsSold_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                UPTUnitsNum = decimal.Parse(UPTUnitsSold.Text);
                CalculateUPT();
            }
            catch (Exception)
            {
                return;
            }
            
        }

        private void CalculateUPT()
        {
            decimal res = UPTUnitsNum / UPTTransactionsNum;
            UPTResult.Text = $"{res:0.0}";
        }

        private void ADSSalesTotal_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ADSSalesNum = decimal.Parse(ADSSalesTotal.Text);
                CalculateUPT();
            }
            catch (Exception)
            {
                return;
            }
        }

        private void ADSTransactions_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ADSTransactionsNum = decimal.Parse(ADSTransactions.Text);
                CalculateADS();
            }
            catch (Exception)
            {
                return;
            }
        }

        private void CalculateADS()
        {
            decimal res = ADSSalesNum / ADSTransactionsNum;
            ADSResult.Text = $"{res:C}";
        }

        private void YTDCurrent_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                YTDCurrentNum = decimal.Parse(YTDCurrent.Text);
                CalculateYTD();
            }
            catch (Exception)
            {
                return;
            }
        }

        private void YTDPreviousYear_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                YTDPreviousNum = decimal.Parse(YTDPreviousYear.Text);
                CalculateYTD();
            }
            catch (Exception)
            {
                return;
            }
        }

        private void CalculateYTD()
        {
            decimal res = YTDCurrentNum - YTDPreviousNum;
            string arrow;
            if (YTDCurrentNum > YTDPreviousNum)
            {
                arrow = "↑";
            }else if (YTDCurrentNum < YTDPreviousNum)
            {
                arrow = "↓";
            }
            else
            {
                arrow = "(No Difference)";
            }
            YTDResult.Text = $"{arrow} {res:C}";
        }

        private void YTDResult_GotFocus(object sender, RoutedEventArgs e)
        {
            UPTUnitsSold.Focus();
            
        }

        private void ADSResult_GotFocus(object sender, RoutedEventArgs e)
        {
            YTDPreviousYear.Focus();
        }

        private void UPTResult_GotFocus(object sender, RoutedEventArgs e)
        {
            ADSSalesTotal.Focus();
        }
    }
}
