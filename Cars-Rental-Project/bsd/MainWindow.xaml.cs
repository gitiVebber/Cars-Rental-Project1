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
using PLfrom;
namespace bsd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl;
        #region constractor
        public MainWindow()
        {
            bl = FactoryBL.getBL();
          
            InitializeComponent();
           
        }
        #endregion

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            getAllFaults ff = new getAllFaults(bl, 1);
            ff.ShowDialog();
        }
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            getAllFaults ff = new getAllFaults(bl, 2);
            ff.ShowDialog();
        }
        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
           
        }
        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
          
        }
        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            client c = new client(bl, 1);
            c.ShowDialog();
        }
        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {

            client c= new client(bl, 2);
            c.ShowDialog();
        }
        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            client c = new client(bl, 3);
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
            addRenting r = new addRenting(bl, 1);
            r.ShowDialog();
        }
        private void MenuItem_Click_12(object sender, RoutedEventArgs e)
        {
            addRenting r = new addRenting(bl, 2);
            r.ShowDialog();
        }
        private void MenuItem_Click_13(object sender, RoutedEventArgs e)
        {
            addRenting r = new addRenting(bl, 3);
            r.ShowDialog();
        }
        private void MenuItem_Click_14(object sender, RoutedEventArgs e)
        {

        }
        private void MenuItem_Click_15(object sender, RoutedEventArgs e)
        {
            getFaultsByIncidence f = new getFaultsByIncidence(bl);
            f.ShowDialog();

        }
        private void MenuItem_Click_16(object sender, RoutedEventArgs e)
        {

        }
        private void MenuItem_Click_17(object sender, RoutedEventArgs e)
        {
            
        }
        private void MenuItem_Click_18(object sender, RoutedEventArgs e)
        {
          
        }
        private void MenuItem_Click_19(object sender, RoutedEventArgs e)
        {
            end_renting r1 = new end_renting(bl);
            r1.ShowDialog();
        }
        private void MenuItem_Click_20(object sender, RoutedEventArgs e)
        {
            getRentings getR = new getRentings(bl,1);
            getR.ShowDialog();
        }
        private void MenuItem_Click_21(object sender, RoutedEventArgs e)
        {
            getRentings getR = new getRentings(bl, 2);
            getR.ShowDialog();
        }
        private void MenuItem_Click_22(object sender, RoutedEventArgs e)
        {
            getClients getc = new getClients(bl, 1);
            getc.ShowDialog();
        }
        private void MenuItem_Click_23(object sender, RoutedEventArgs e)
        {
            getClients getc = new getClients(bl, 2);
            getc.ShowDialog();
        }
        private void MenuItem_Click_24(object sender, RoutedEventArgs e)
        {
            getAllCar c = new getAllCar(bl,1);
            c.ShowDialog();
        }
        private void MenuItem_Click_25(object sender, RoutedEventArgs e)
        {
            getAllCar c = new getAllCar(bl,2);
            c.ShowDialog();
        }

        private void MenuItem_Click_26(object sender, RoutedEventArgs e)
        {
            getAllCar c = new getAllCar(bl, 3);
            c.ShowDialog();
        }
        private void MenuItem_Click_27(object sender, RoutedEventArgs e)
        {
            getAllCar c = new getAllCar(bl, 4);
            c.ShowDialog();
        }
        private void MenuItem_Click_28(object sender, RoutedEventArgs e)
        {
            profit p = new profit(bl);
            p.ShowDialog();
        }
        private void MenuItem_Click_29(object sender, RoutedEventArgs e)
        {
           ;
        }
    }
}
