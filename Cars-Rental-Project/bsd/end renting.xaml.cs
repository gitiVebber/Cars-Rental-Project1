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

namespace PLfrom
{
    /// <summary>
    /// Interaction logic for end_renting.xaml
    /// </summary>
    public partial class end_renting : Window
    {
        IBL bl;
        Renting r;
        /// <summary>
        /// קונסטרקטור
        /// </summary>
        /// <param name="bl"></param>
        public end_renting(IBL bl)
        {
            this.bl = bl;
            InitializeComponent();

            priceTextBox.IsEnabled = false;
            numberCallComboBox.DataContext = bl.getAllRentingToEnd();
            
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource rentingViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("rentingViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // rentingViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource tybeFaultViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tybeFaultViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // tybeFaultViewSource.Source = [generic data source]
        }
        /// <summary>
        /// אירוע של גמר השכרה כלומר עידכון המחיר הסופי ועידכון תקלות
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void finishBotton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (kMTextBox.Text == "" || endRentingDatePicker.Text == "")
                    throw new Exception("please fill all fields!");
                Renting r = bl.GetRenting(int.Parse(numberCallComboBox.Text));
                if (r != null)
                {
                    r.endRenting = Convert.ToDateTime(endRentingDatePicker.ToString());
                    r.KM = int.Parse(kMTextBox.Text);
                    if (isFaultCheckBox.IsChecked == true)
                        r.isFault = true;
                    else
                        r.isFault = false;
                   
                    bl.endRenting(r);//bl שליחה לפונקצית ה
                    
                    priceTextBox.Text = r.price.ToString();
                    throw new Exception("finish Renting!\nyour price is:  " + r.price);
                }
                else
                    throw new Exception("this renting dont find");
            }
            catch (Exception e1)
            {

                MessageBox.Show("" + e1.Message);
                this.Close();
            }

        }
        /// <summary>
        /// בבחירת הכפתור המודיע שהיה תקלה פתיחת חלונית של הוספת תקלה לרכב הספציפי
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void isFaultCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Fault f = new Fault(bl, 1, r);
            f.ShowDialog();
        }
        /// <summary>
        /// בבחירת מספר השכרה העלאת הנתונים הרלוונטיים לעידכון בסיום ההשכרה
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numberCallComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (numberCallComboBox.Text != null)
            {
                r = bl.GetRenting(int.Parse(numberCallComboBox.SelectedItem.ToString()));
                if (r != null)
                    endRentingDatePicker.Text = r.endRenting.ToString();

            }
        }
    }
}
