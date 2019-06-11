using BL;
using BE;
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
    /// Interaction logic for typeFault.xaml
    /// </summary>
    public partial class typeFault : Window
    {
        IBL bl;
        /// <summary>
        /// קונסטרקטור
        /// </summary>
        /// <param name="bl"></param>
        public typeFault(IBL bl)
        {
            this.bl = bl;
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource tybeFaultViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tybeFaultViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // tybeFaultViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource faultViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("faultViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // faultViewSource.Source = [generic data source]
        }
        /// <summary>
        /// אירוע של הוספת סוג תקלה
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addTybeFaultBotton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                #region בדיקת תקינות קלט
                if (nameFaultTextBox.Text == "" || numberFaultTextBox.Text == "" || priceOfFaultTextBox.Text == "" || insuranceComboBox.SelectedValue == "")
                    throw new Exception("please fill all fields!");
                int num;
                if (!int.TryParse(numberFaultTextBox.Text, out num))
                    throw new Exception("put only numbers for number fault!");
                if (!int.TryParse(priceOfFaultTextBox.Text, out num))
                    throw new Exception("put only numbers for price!");
                TybeFault f = bl.getTybeFault(numberFaultTextBox.Text);
                if (f != null)
                {
                    throw new Exception("this type existent!");
                }
                f = bl.getTybeFault(nameFaultTextBox.Text);
                if (f != null)
                {
                    throw new Exception("this type existent!");
                }
                #endregion
                TybeFault t = new TybeFault { numberFault = int.Parse(numberFaultTextBox.Text), nameFault = nameFaultTextBox.Text, priceOfFault = int.Parse(priceOfFaultTextBox.Text), insurance = insuranceComboBox.Text, };
                bl.addTypeFault(t);//bl שליחה לפונקצית ה
                throw new Exception("ok!");
            }
            catch (Exception e1)
            {

                MessageBox.Show("" + e1.Message);
            }


        }
        /// <summary>
        /// הדפסת הודעה בגין סוג הביטוח שבחרו כלומר סוג הביטוח שבתוכו נכללת התקלה
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void insuranceComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (insuranceComboBox.SelectedIndex == 0)
            {
                MessageBox.Show("This fault only comprehensive insurance included");//תקלה זאת נכללת רק בביטוח מקיף
            }
            if (insuranceComboBox.SelectedIndex == 1)
                MessageBox.Show("This fault accident insurance included");//תקלה זאת נכללת בביטוח תאונות
        }
    }
}
