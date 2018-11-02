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

namespace CookieClickerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double Cookies = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void bt_Clicker_Click(object sender, RoutedEventArgs e)
        {
            Cookies++;

            txt_Cookies.Text = Convert.ToString(Cookies);
        }
    }
}
