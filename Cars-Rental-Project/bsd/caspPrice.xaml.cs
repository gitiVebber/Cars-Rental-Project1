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
    /// Interaction logic for profit.xaml
    /// </summary>
    public partial class profit : Window
    {

        IBL bl;
        #region constractor
        public profit(IBL bl)
        {
            this.bl = bl;
            InitializeComponent();
            IDcombox.IsEditable = false;
            IDcombox.IsEnabled = false;

        }
        #endregion
        DateTime start, end;
        int ID;
        /// <summary>
        /// בחירת לקוח שעבורו יוצג כל ההשכרות בין התאריכים שנבחרו
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

            ID = int.Parse(IDcombox.SelectedItem.ToString());
            CostPriceTextBox.Text = bl.getCostForClient(ID).ToString();
            profitTextBox.Text = bl.getCostForClient1(ID, start, end).ToString();
            rentingDataGrid.ItemsSource = bl.getAllrentingsForClientBeetweenDates(ID, start, end);
        }
        /// <summary>
        /// בחירת תאריך התחלת הצגת כל ההשכרות ללקוח המסויים הזה 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            start = startDatePicker.SelectedDate.Value;
            if (end != null)
            {
                IDcombox.IsEnabled = true;
                IDcombox.ItemsSource = bl.getAllClients();
                IDcombox.DisplayMemberPath = "IDClient";
            }
        }
        /// <summary>
        /// בחירת תאריך סיום הצגת כל ההשכרות ללקוח המסויים הזה
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatePicker_SelectedDateChanged_1(object sender, SelectionChangedEventArgs e)
        {
            end = endDatePicker.SelectedDate.Value;
            if (start != null)
            {
                IDcombox.IsEnabled = true;
                IDcombox.ItemsSource = bl.getAllClients();
                IDcombox.DisplayMemberPath = "IDClient";
            }

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {


        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource rentingViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("rentingViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // rentingViewSource.Source = [generic data source]
        }

        private void profitTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void rentingDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }
}
