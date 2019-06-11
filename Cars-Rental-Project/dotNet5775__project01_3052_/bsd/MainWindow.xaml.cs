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
namespace bsd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl;
        public MainWindow()
        {bl = FactoryBL.getBL();
            InitializeComponent();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }
        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {

        }
        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            
        }
        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            addClient2 c = new addClient2(bl, 1);
            c.ShowDialog();
        }
        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            addClient2 c = new addClient2(bl, 2);
            c.ShowDialog();
        }
        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            addClient2 c = new addClient2(bl, 3);
            c.ShowDialog();
        }
        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            addCars c = new addCars(bl, 1);
            c.ShowDialog();
        }
        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            addCars c = new addCars(bl, 2);
            c.ShowDialog();
        }
        private void MenuItem_Click_10(object sender, RoutedEventArgs e)
        {
            addCars c = new addCars(bl,3);
            c.ShowDialog();
        }
        private void MenuItem_Click_11(object sender, RoutedEventArgs e)
        {

        }
        private void MenuItem_Click_12(object sender, RoutedEventArgs e)
        {

        }
        private void MenuItem_Click_13(object sender, RoutedEventArgs e)
        {

        }
        private void MenuItem_Click_14(object sender, RoutedEventArgs e)
        {

        }
        private void MenuItem_Click_15(object sender, RoutedEventArgs e)
        {

        }
        private void MenuItem_Click_16(object sender, RoutedEventArgs e)
        {

        }
    }
}
