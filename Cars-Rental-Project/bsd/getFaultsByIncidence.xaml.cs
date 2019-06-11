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
    /// Interaction logic for getFaultsByIncidence.xaml
    /// </summary>
    public partial class getFaultsByIncidence : Window
    {
        IBL bl;
        #region constractor
        public getFaultsByIncidence(IBL bl)
        {
            this.bl = bl;
            InitializeComponent();
            tybeFaultDataGrid.ItemsSource = bl.getFaultSorting();
        }
        #endregion
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource tybeFaultViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tybeFaultViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // tybeFaultViewSource.Source = [generic data source]
        }
    }
}
