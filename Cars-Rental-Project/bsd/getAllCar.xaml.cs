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
using BE;
using BL;
namespace bsd
{
    /// <summary>
    /// Interaction logic for getAllCar.xaml
    /// </summary>
    public partial class getAllCar : Window
    {
        IBL bl;
        #region constractor
        public getAllCar(IBL bl,int num)
        {
            this.bl=bl;
            InitializeComponent();
            switch (num)
            { 
                case 1://בבחירת הצגת כל המכוניות
                    carDataGrid.ItemsSource = bl.getAllCars();
                    sitPlaceTextBox.Visibility = Visibility.Hidden;
                    sumDoorsCombox.Visibility = Visibility.Hidden;
                    girCombox.Visibility = Visibility.Hidden;
                    lable.Visibility = Visibility.Hidden;
                    label1.Visibility = Visibility.Hidden;
                    label3.Visibility = Visibility.Hidden;
                     lable2.Visibility = Visibility.Hidden;

                     textBoxProfit.Text = bl.getAllspace().ToString();
                     showBotton.Visibility = Visibility.Hidden;
                    break;
                case 2://בבחירת הצגת מכוניות לפי מספר דלתות
                    lable10.Visibility = Visibility.Hidden;
                    label1.Visibility = Visibility.Hidden;
                    label3.Visibility = Visibility.Hidden;
                    girCombox.Visibility = Visibility.Hidden;
                    sitPlaceTextBox.Visibility = Visibility.Hidden;
                    textBoxProfit.Visibility = Visibility.Hidden;
                    labeltextBoxProfit.Visibility = Visibility.Hidden;
                    for (int i = 2; i < 7; i++)
                        sumDoorsCombox.Items.Add(i);
                    showBotton.Visibility = Visibility.Hidden;
                    break;  
                case 3://הצגת מכוניות לפי מקומות ישיבה
                    lable10.Visibility = Visibility.Hidden;
                    label1.Visibility = Visibility.Hidden;
                     lable2.Visibility = Visibility.Hidden;
                    girCombox.Visibility = Visibility.Hidden;
                    sumDoorsCombox.Visibility = Visibility.Hidden;
                    textBoxProfit.Visibility = Visibility.Hidden;
                    labeltextBoxProfit.Visibility = Visibility.Hidden;

                    break;
                case 4://הצגת מכוניות לפי אוטומט 
                    lable10.Visibility = Visibility.Hidden;
                    label3.Visibility = Visibility.Hidden;
                     lable2.Visibility = Visibility.Hidden;
                     sitPlaceTextBox.Visibility = Visibility.Hidden;
                      sumDoorsCombox.Visibility = Visibility.Hidden;
                      showBotton.Visibility = Visibility.Hidden;
                    textBoxProfit.Visibility = Visibility.Hidden;
                    labeltextBoxProfit.Visibility = Visibility.Hidden;
                    girCombox.Items.Add("automaton");
                    girCombox.Items.Add("not automaton");
                    carDataGrid.ItemsSource = Enum.GetValues(typeof(automat));

                    break;
            }
    
        }
        #endregion

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource carViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("carViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // carViewSource.Source = [generic data source]
        }

          
        /// <summary>
        /// הצגת כל המכוניות שעונים למספר הדלתות שנבחר
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            
            int n = int.Parse(sumDoorsCombox.SelectedItem.ToString());
            Predicate<Car> p = c => c.sumDoors == n;
            carDataGrid.ItemsSource = bl.getAllCarsByPredicate(p);
            
        }

        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        /// <summary>
        /// הצגת כל המכוניות שהם אוטומט או לא אוטומט לפי מה שנבחר
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void girCombox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            automat a = (automat)girCombox.SelectedIndex;
            Predicate<Car> p1 = c => c.isAutomat == a;
            carDataGrid.ItemsSource = bl.getAllCarsByPredicate(p1);

        }
        /// <summary>
        /// הצגת כל המכוניות שעונים למספר מקומות הישיבה שנבחר
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showBotton_Click(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(sitPlaceTextBox.Text);
            Predicate<Car> p = c => c.sumTravelers == n;
            carDataGrid.ItemsSource = bl.getAllCarsByPredicate(p);
        }

        private void textBoxProfit_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
