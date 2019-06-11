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
    /// Interaction logic for getRentings.xaml
    /// </summary>
    public partial class getRentings : Window
    {
        IBL bl;
        #region constractor
        public getRentings(IBL bl, int num)
        {
            this.bl = bl;
            InitializeComponent();
            switch (num)
            {
                case 1:
                    rentingDataGrid.IsEnabled = false;
                    rentingDataGrid.ItemsSource = bl.getAllRentings();
                    // getRentingsCombox.ItemsSource = bl.isMore30Days();
                    selectClient.Visibility = Visibility.Hidden;
                    getRentingsCombox.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    allRentings.Visibility = Visibility.Hidden;
                    getRentingsCombox.IsEnabled = true;
                    getRentingsCombox.ItemsSource = bl.getAllClients();

                    getRentingsCombox.DisplayMemberPath = "IDClient";
                    break;
            }
        }
        #endregion

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource rentingViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("rentingViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // rentingViewSource.Source = [generic data source]
        }
        /// <summary>
        /// לפי הלקוח שנבחר  יוצג כל ההזמנות שלו
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (getRentingsCombox.SelectedItem != null)
            {
                Client c = bl.GetClient(int.Parse(getRentingsCombox.SelectedItem.ToString()));
                if (c != null)
                    rentingDataGrid.ItemsSource = bl.getRentings(c.IDClient);

            }
        }

        private void rentingDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
