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

using System.Windows.Threading;

namespace CookieClickerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Global Variables
        double Cookies = 0;
        double UpgradeCost = 10;
        double CPS = 1;

        public MainWindow()
        {
            InitializeComponent();

            // creates instance 
            DispatcherTimer TickTimer = new System.Windows.Threading.DispatcherTimer();
            TickTimer.Tick += new EventHandler(Timer);
            // Sets time interval on how often TickTimer is called
            TickTimer.Interval = new TimeSpan(0, 0, 1);
            // Starts the timer
            TickTimer.Start();
        }

        void Timer(object sender, EventArgs e)
        {
            Cookies = Cookies + CPS;
            txt_Cookies.Text = Convert.ToString(Cookies);
        }

        // Adds the CPS to the total amount of Cookies every time the button is clicked
        private void bt_Clicker_Click(object sender, RoutedEventArgs e)
        {
            Cookies = Cookies + CPS;
            
            Cookies = Round(Cookies);
            txt_Cookies.Text = Convert.ToString(Cookies);
        }

        private void bt_Multiplyer_Click(object sender, RoutedEventArgs e)
        {
            // Player needs to have enough cookies to meet the UpgradeCost
            if (UpgradeCost <= Cookies)
            {
                // Takes away the Cookies for the upgrade
                Cookies = Cookies - UpgradeCost;
                // Sets a new upgrade cost
                UpgradeCost = UpgradeCost * 1.6;
                // Changes how many cookies per click you get
                CPS = CPS * 1.4;
                // Updates the Cookie count to the new deducted amount
                txt_Cookies.Text = Convert.ToString(Cookies);
            }
            // If player doesn't have enough cookies tell them
            else
            {
                txt_Multiplier.Text = "Not Enough Cookies";
            }
            // Either way update what the button says the cost is to the new cost
            bt_Multiplyer.Content = "Cost : " + UpgradeCost;

            Cookies = Round(Cookies);
            txt_Cookies.Text = Convert.ToString(Cookies);
        }

        double Round (double _roundy)
        {
            // Code from RodH257 at https://stackoverflow.com/questions/6092243/c-sharp-check-if-a-decimal-has-more-than-3-decimal-places
            // Checks if the number has 4 decimal places is equal to the number
            if (Decimal.Round(Convert.ToDecimal(_roundy), 4) != Convert.ToDecimal(_roundy))
            {
                Decimal.Round(Convert.ToDecimal(_roundy), 4);
                return Convert.ToDouble(_roundy);
            }
            return Convert.ToDouble(_roundy);
        }
    }
}
