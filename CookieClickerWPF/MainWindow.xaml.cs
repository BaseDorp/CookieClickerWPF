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

// Task.Delay code from Jimmy Hannon at https://stackoverflow.com/questions/24371440/how-to-run-a-method-after-a-specific-time-interval
// Decimal.Round code from RodH257 at https://stackoverflow.com/questions/6092243/c-sharp-check-if-a-decimal-has-more-than-3-decimal-places

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
        double GrandmaUpCost = 25;
        double FactoryUpCost = 100;
        double CPS = 1;

        public MainWindow()
        {
            InitializeComponent();

            // creates instance 
            DispatcherTimer TickTimer = new System.Windows.Threading.DispatcherTimer();
            TickTimer.Tick += new EventHandler(TicTimer);

            // Sets time interval on how often TickTimer is called
            TickTimer.Interval = new TimeSpan(0, 0, 1);

            // Starts the timer
            TickTimer.Start();
        }
        
        // Adds the CPS every time called
        void TicTimer(object sender, EventArgs e)
        {
            Cookies = Cookies + CPS;
            // Cookies = Round(Cookies);
            // CPS = Round(CPS);
            txt_Cookies.Text = Convert.ToString(Cookies);
        }

        // Adds the CPS to the total amount of Cookies every time the button is clicked
        private void bt_Clicker_Click(object sender, RoutedEventArgs e)
        {
            Cookies = Cookies + CPS;
            
            txt_Cookies.Text = Convert.ToString(Cookies);
        }

        // Function must be async so the await works
        private async void bt_Upgrade_Click(object sender, RoutedEventArgs e)
        {
            // Player needs to have enough cookies to meet the UpgradeCost
            if (UpgradeCost <= Cookies)
            {
                // Takes away the Cookies for the upgrade
                Cookies = Cookies - UpgradeCost;
                // Sets a new upgrade cost
                UpgradeCost = UpgradeCost * 5;
                // Changes how many cookies per click you get
                CPS = CPS * 2;
                // Updates the Cookie count to the new deducted amount
                txt_Cookies.Text = Convert.ToString(Cookies);
            }
            else
            {
                txt_Upgrades.Text = "Not Enough Cookies";
                // waits for 2 seconds before moving on
                await Task.Delay(2000);
                txt_Upgrades.Text = "Upgrades:";
            }
            // Either way update what the button says the cost is to the new cost
            bt_Upgrade.Content = "CPS * 2\n\nCost : " + UpgradeCost;

            txt_Cookies.Text = Convert.ToString(Cookies);
            txt_CPS.Text = "Cookies per second: " + CPS;
        }
        
        private  async void bt_Grandma_Click(object sender, RoutedEventArgs e)
        {
            if (GrandmaUpCost <= Cookies)
            {
                Cookies = Cookies - GrandmaUpCost;
                GrandmaUpCost = GrandmaUpCost * 1.5;
                CPS = CPS + CPS * 0.2;
                txt_Cookies.Text = Convert.ToString(Cookies);
            }
            else
            {
                txt_Upgrades.Text = "Not Enough Cookies";
                await Task.Delay(2000);
                txt_Upgrades.Text = "Upgrades:";
            }
            bt_Grandma.Content = "CPS * 0.2\n\nCost : " + GrandmaUpCost;
            
            txt_Cookies.Text = Convert.ToString(Cookies);
            txt_CPS.Text = "Cookies per second: " + CPS;
        }

        private async void bt_Factory_Click(object sender, RoutedEventArgs e)
        {
            if (FactoryUpCost <= Cookies)
            {
                Cookies = Cookies - FactoryUpCost;
                FactoryUpCost = FactoryUpCost * 3;
                CPS = CPS + CPS * .5;
                txt_Cookies.Text = Convert.ToString(Cookies);
            }
            else
            {
                txt_Upgrades.Text = "Not Enough Cookies";
                await Task.Delay(2000);
                txt_Upgrades.Text = "Upgrades:";
            }
            bt_Factory.Content = "CPS * 0.5\n\nCost : " + FactoryUpCost;
            
            txt_Cookies.Text = Convert.ToString(Cookies);
            txt_CPS.Text = "Cookies per second: " + CPS;
        }

        double Round(double _roundy)
        {

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
