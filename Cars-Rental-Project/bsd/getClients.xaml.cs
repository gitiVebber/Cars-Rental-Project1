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
    /// Interaction logic for getClients.xaml
    /// </summary>
    public partial class getClients : Window
    {
        IBL bl;
        #region constractor
        public getClients(IBL bl, int num)
        {
            this.bl = bl;
            InitializeComponent();
            switch (num)
            {
                case 1:
                    clientDataGrid.IsEnabled = false;
                    clientDataGrid.ItemsSource = bl.getAllClients();
                    Combox.Visibility = Visibility.Hidden;
                    lable2.Visibility = Visibility.Hidden;
                    lable3.Visibility = Visibility.Hidden;


                    break;
                case 2:
                    lable1.Visibility = Visibility.Hidden;
                    lable3.Visibility = Visibility.Hidden;
                    clientDataGrid.IsEnabled = false;
                    for (int i = 1; i <= 12; i++)
                        Combox.Items.Add(i);
                    break;

            }

        }
        #endregion
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource clientViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clientViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // clientViewSource.Source = [generic data source]
        }
        /// <summary>
        /// לפי החודש הנבחר יוצג כל הלקוחות שחוגגים יום הולדת באותא חודש
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {


            try
            {
                int month = int.Parse(Combox.SelectedItem.ToString());
                Predicate<Client> p1 = m => m.dateOfBirth.Month == month;
                clientDataGrid.ItemsSource = bl.getAllClientsByPredicate(p1);

            }
            catch (Exception e1)
            {
                MessageBox.Show("" + e1.Message);
            }
        }
    }
}
