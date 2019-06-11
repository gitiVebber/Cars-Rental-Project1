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
using System.Windows.Shapes;
using BL;
using BE;
namespace bsd
{
    /// <summary>
    /// Interaction logic for getAllFaults.xaml
    /// </summary>
    public partial class getAllFaults : Window
    {
        IBL bl;
        #region constractor
        public getAllFaults(IBL bl, int num)
        {


            this.bl = bl;
            InitializeComponent();
            switch (num)
            {
                case 1:
                    faultDataGrid.ItemsSource = bl.getAllFaults();
                    lable2.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    Predicate<Fault> p = f => f.isWear = true;
                    faultDataGrid.ItemsSource = bl.getAllFaultsByPredicate(p);
                    break;

            }
        }
        #endregion
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource faultViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("faultViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // faultViewSource.Source = [generic data source]
        }

        private void faultDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
