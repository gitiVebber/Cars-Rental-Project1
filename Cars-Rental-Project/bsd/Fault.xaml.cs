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

namespace PLfrom
{
    /// <summary>
    /// Interaction logic for Fault.xaml
    /// </summary>
    public partial class Fault : Window
    {
        IBL bl;
        Renting ren;
        /// <summary>
        /// קונסטרקטור
        /// </summary>
        /// <param name="bl"></param>
        /// <param name="num"></param>
        /// <param name="r"></param>
        public Fault(IBL bl, int num, Renting r = null)
        {
            this.bl = bl;
            ren = r;
            InitializeComponent();
            switch (num)
            {
                case 1:///בבחירת הוספת תקלה
                    numberFaultComboBox.IsEnabled = false;
                    numberFaultComboBox.Visibility = Visibility.Hidden;
                    nameFaultComboBox.DataContext = bl.getAllTypeFaults();
                    numberCarTextBox.IsEnabled = false;
                    numberCarTextBox.Text = ren.licensePlate;
                    updateFaultBotton.IsEnabled = false;
                    deleteFaultBotton.IsEnabled = false;
                    break;
                
            }
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource tybeFaultViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tybeFaultViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // tybeFaultViewSource.Source = [generic data source]
        }
        /// <summary>
        /// הוספת סוג תקלה לא קיימת כלומר פתיחת החלונית של סוגי תקלות
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addTypeFault_Click(object sender, RoutedEventArgs e)
        {
            typeFault t = new typeFault(bl);
            t.ShowDialog();
            nameFaultComboBox.DataContext = bl.getAllTypeFaults();
        }
        /// <summary>
        /// בבחירת סוג תקלה מסוים
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nameFaultComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (nameFaultComboBox.Text != null)
            {
                TybeFault t = bl.getTybeFault(nameFaultComboBox.SelectedValue.ToString());
            }
        }
        /// <summary>
        /// הוספת התקלה לרשימת התקלות ולרכב הנתון
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addFaultBotton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                #region בדיקת תקינות קלט
                if (numberFaultTextBox.Text == "" || dateOfFaultDatePicker.Text == "" || nameFaultComboBox.Text == "")
                {
                    throw new Exception("please fill all Fields");
                }
                BE.Fault f = bl.GetFault(int.Parse(numberFaultTextBox.Text));
                if (f != null)
                {
                    throw new Exception("this number fault existent");
                }
                #endregion
                TybeFault t = bl.getTybeFault(nameFaultComboBox.SelectedValue.ToString());

                f = new BE.Fault
                {
                    dateOfFault = DateTime.Parse(dateOfFaultDatePicker.ToString()),
                    numberFault = int.Parse(numberFaultTextBox.Text),
                    typeFault = t,
                    numberCar = int.Parse(numberCarTextBox.Text),
                    garageOfFix = garageOfFixComboBox.Text,
                };
                if (isWearCheckBox.IsChecked == true)
                    f.isWear = true;
                else
                    f.isWear = false;
                if (ren.insurance != "comprehensive")
                    if ((ren.insurance == "handicap insurance" && t.insurance != "handicap insurance") || ren.insurance == "no")
                        ren.price += t.priceOfFault;//עידכון מחיר ההשכרה בתוספת התקלה במידה שאין ביטוח מתאים
                f.priceOfFault = f.typeFault.priceOfFault;
                bl.addFault(f);//לרשימת התקלות bl שליחה לפונקצית ה 
                bl.addFaultForCar(ren.licensePlate, f);//לרכב הנתון bl שליחה לפונקצית ה

            }
            catch (Exception e1)
            {

                MessageBox.Show("" + e1.Message);
            }

        }
    }
}
