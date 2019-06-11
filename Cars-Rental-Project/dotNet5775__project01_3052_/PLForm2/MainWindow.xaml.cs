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
namespace PLForm2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl;
        
        public MainWindow()
        {
            bl = FactoryBL.getBL();
            InitializeComponent();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void carMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void faultsMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            addClient1 c = new addClient1(bl,1);
           c.ShowDialog();
        }
        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
           // addClient c = new addClient(bl, 2);
           // c.ShowDialog();
        }
        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
           // addClient c = new addClient(bl, 3);
         // c.ShowDialog();
        }
    }
}
