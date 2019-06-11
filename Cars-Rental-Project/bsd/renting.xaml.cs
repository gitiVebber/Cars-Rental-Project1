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
    /// Interaction logic for renting.xaml
    /// </summary>
    public partial class addRenting : Window
    {
        //Renting r;
        IBL bl;
        # region constractor
        public addRenting(IBL bl, int num)
        {
            this.bl = bl;
            InitializeComponent();
            for (int i = 0; i < 4; i++)
            {
                chairChildCombox.Items.Add(i);
                chairBabyCombox.Items.Add(i);
            }
            for (int i = 0; i < 2; i++)
                gpsCombox.Items.Add(i);
            switch (num)
            {

                case 1:
                    addRentingBotton.IsEnabled = true;
                    updateRentingBotton.IsEnabled = false;
                    numCarComboBox.ItemsSource = bl.getAllCars();
                    numCarComboBox.DisplayMemberPath = "LicensePlate";
                    firstNaneCombox.ItemsSource = bl.getAllClients();
                    firstNaneCombox.DisplayMemberPath = "IDClient";
                    startKMTextBox.IsEnabled = false;                
                    numberCallComboBox.IsEnabled = false;
                    nameSubDriversTextBox.IsEnabled = false;
                    nameMainDriversTextBox.IsEnabled = false;
                    subNameCombox.IsEnabled = false;
                    subNameCombox.ItemsSource = bl.getAllClients();
                    subNameCombox.DisplayMemberPath = "IDClient";
                    firstNaneCombox.IsEnabled = false;
                    numberCallComboBox.Visibility = Visibility.Hidden;
                    label.Visibility = Visibility.Hidden;
                  
                    break;

                case 2:
                    addRentingBotton.IsEnabled = false;
                    updateRentingBotton.IsEnabled = true;
                    numberCallComboBox.DataContext = bl.getAllRentings();
                    numberCallComboBox.DisplayMemberPath = "numberCall";
                    startKMTextBox.IsEnabled = false;
                    nameSubDriversTextBox.IsEnabled = false;
                    nameMainDriversTextBox.IsEnabled = false;
                    subNameCombox.IsEnabled = false;
                    firstNaneCombox.IsEnabled = false;
                    sumDriversCombox.IsEnabled = false;
                    numCarComboBox.IsEnabled = false;
                    startRentingDatePicker.IsEnabled = false;


                    break;
             

            }
        }
        #endregion
        /// <summary>
        /// אירוע של עידכון השכרה
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateRentingBotton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                Renting r = bl.GetRenting(int.Parse(numberCallComboBox.SelectedValue.ToString()));
                if (r != null)//עידכון הנתונים הרלוונטיים
                {
                    r.insurance = insuranceComboBox.Text;
                    r.endRenting = Convert.ToDateTime(endRentingDatePicker.Text);
                    r.chairChild = int.Parse(chairChildCombox.Text);
                    r.chairBaby = int.Parse(chairBabyCombox.Text);
                    r.price = (60 * r.chairBaby + 45 * r.chairChild);
                    if (gpsCombox.SelectedIndex == 1)
                    {
                      r.isGPS = true;
                      r.price += 150;
                    }
                    else  
                        r.isGPS = false;


                    bl.updateRenting(r);//bl שליחה לפונקצית ה
                    throw new Exception("Rental successfully updated");
                }

            }
            catch (Exception e1)
            {

                MessageBox.Show(""+e1.Message);
            }
           
            
        }
        /// <summary>
        /// בבחירת רכב מעדכן את את מספר הק"מ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numCarComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (numCarComboBox.SelectedValue != null)
            {
                Car car = bl.GetCar(numCarComboBox.SelectedValue.ToString());
                if (car != null)
                {
                    startKMTextBox.Text = car.KM.ToString();
                }

            }
        }
        /// <summary>
        /// הוספת השכרה למערכת
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addRentingBotton_Click(object sender, RoutedEventArgs e)
        {

            string s = "";//משתני עזר לנהג רכב שני במידה ולא יבחר
            int n = 99999999;
            try
            {
                if (sumDriversCombox.SelectedIndex == 1)//בבחירת נהג שני עדכון המשתנים
                {
                    s = nameSubDriversTextBox.Text;
                    n = int.Parse(subNameCombox.SelectedItem.ToString());
                }
                #region בדיקת תקינות קלט
                if (numCarComboBox.Text == "" || startRentingDatePicker.Text == "" || sumDriversCombox.Text == "" || endRentingDatePicker.Text == "")
                    throw new Exception("Please fill all fileds");
                DateTime st = Convert.ToDateTime(startRentingDatePicker.Text);
                DateTime end = Convert.ToDateTime(endRentingDatePicker.Text);
                if (st < DateTime.Now  || st > end)
                {
                    throw new Exception("Put an end date later start and a start date has not yet been");
                }
                if (sumDriversCombox.SelectedIndex == 0)
                {
                    if (firstNaneCombox.Text == "")
                        throw new Exception("Please select the driver");
                    if (bl.newDriver(int.Parse(firstNaneCombox.SelectedValue.ToString())))
                    {     
                        throw new Exception("this driver is a new driver con't renting alone\nshe need a second driver");
                    }
                }
                else
                    if ((subNameCombox.Text == "") || (firstNaneCombox.Text == ""))
                        throw new Exception("Please select the drivers");
                #endregion
                Renting r = new Renting
                {
                    sumDrivers = int.Parse(sumDriversCombox.Text),
                    StartRenting = Convert.ToDateTime(startRentingDatePicker.Text),
                    endRenting = Convert.ToDateTime(endRentingDatePicker.Text),

                    drivers = new Drivers
                    {
                        IDMainDrivers = int.Parse(firstNaneCombox.SelectedItem.ToString()),
                        IDSubDrivers = n,
                        nameMainDrivers = nameMainDriversTextBox.Text,
                        nameSubDrivers = s,
                    },
                    KM = int.Parse(startKMTextBox.Text),
                    licensePlate = numCarComboBox.SelectedValue.ToString(),
                    insurance=insuranceComboBox.Text,
                };
                if (chairBabyCombox.SelectedIndex >= 0)
                    r.chairBaby = chairBabyCombox.SelectedIndex;
                else
                    r.chairBaby = 0;
                if (chairChildCombox.SelectedIndex >= 0)
                    r.chairChild = chairChildCombox.SelectedIndex;
                else
                    r.chairChild = 0;
                if (gpsCombox.SelectedIndex == 1)
                {
                    r.isGPS = true;
                    r.price += 150;
                }
                else
                {
                    r.isGPS = false;
                }
                r.price += 60 * r.chairBaby;//עדכון מחיר ההשכרה לפי האביזרים הנלווים שנבחרו
                r.price += 45 * r.chairChild;
                bl.addrenting(r);//bl שליחה לפונקצית ה
                MessageBox.Show("renting ");
                this.Close();//סגירת חלונית
            }
            catch (Exception e1)
            {
                MessageBox.Show("" + e1.Message);
                this.Close();
            }
        }

     
        private void numberClientCombox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        /// <summary>
        /// מעדכן את שם המשכיר השני לפי הת"ז שלו
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (subNameCombox.Text != null)
            {
                Client c2 = bl.GetClient(int.Parse(subNameCombox.SelectedValue.ToString()));
                if (c2 != null)
                {
                    nameSubDriversTextBox.Text = c2.name;
                }
            }
        }
        /// <summary>
        /// מעדכן את שם המשכיר הראשון לפי הת"ז שלו
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void firstNaneCombox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (firstNaneCombox.Text != null)
            {
                Client c = bl.GetClient(int.Parse(firstNaneCombox.SelectedValue.ToString()));
                if (c != null)
                {
                    nameMainDriversTextBox.Text = c.name;
                }
            }
        }
        
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource rentingViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("rentingViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // rentingViewSource.Source = [generic data source]
        }
        /// <summary>
        /// בעידכון השכרה - בבחירת מסםר הזמנה העלאת כל הנתונים השייכים לאותו השכרה
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numberCallComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (numberCallComboBox.SelectedItem != null)
            {
                Renting r = bl.GetRenting(int.Parse(numberCallComboBox.SelectedItem.ToString()));
                if (r != null)
                {
                    startRentingDatePicker.Text = r.StartRenting.ToString();
                    endRentingDatePicker.Text = r.endRenting.ToString();
                    nameMainDriversTextBox.Text = r.drivers.nameMainDrivers.ToString();
                    nameSubDriversTextBox.Text = r.drivers.nameSubDrivers.ToString();
                    firstNaneCombox.Text = r.drivers.IDMainDrivers.ToString();
                    subNameCombox.Text = r.drivers.IDSubDrivers.ToString();
                    startKMTextBox.Text = r.startKM.ToString();
                    numCarComboBox.Text = r.licensePlate.ToString();
                    sumDriversCombox.Text = r.sumDrivers.ToString();
                    firstNaneCombox.Text = r.drivers.IDMainDrivers.ToString();
                    subNameCombox.Text = r.drivers.IDSubDrivers.ToString();
                    insuranceComboBox.Text = r.insurance.ToString();
                    chairBabyCombox.Text = r.chairBaby.ToString();
                    priceChairBaby.Text = (60 * r.chairBaby).ToString();
                    chairChildCombox.Text = r.chairChild.ToString();
                    priceChairChild.Text = (45 * r.chairChild).ToString();
                    if (r.isGPS)
                    {
                        gpsCombox.Text = "1";
                        priceGps.Text = "150";
                    }
                    else
                    {
                        gpsCombox.Text = "0";
                        priceGps.Text = "0";
                    }

                }

            }
        }
        /// <summary>
        /// בבחירת מספר נהגים מורשים שחרור הכפתורים המתאימים
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sumDriversCombox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (sumDriversCombox.SelectedIndex == 0)
            {
                firstNaneCombox.IsEnabled = true;
                subNameCombox.IsEnabled = false;        
            }
            if (sumDriversCombox.SelectedIndex == 1)
            {
                firstNaneCombox.IsEnabled = true;
                subNameCombox.IsEnabled = true;
            }
            sumDriversCombox.IsEnabled = false;
        }

        #region בבחירת אביזר נלווה עידכון חלונית המחיר בהתאם
       /// <summary>
       /// בחירת כסא לילד
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void chairChildCombox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int n = chairChildCombox.SelectedIndex;
            n = n * 45;
            priceChairChild.Text = n.ToString();
        }
        /// <summary>
        /// בחירת כסא לתינוק
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chairBabyCombox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int n = chairBabyCombox.SelectedIndex;
            n = n * 60;
            priceChairBaby.Text = n.ToString();

        }
        /// <summary>
        /// GPS בחירת
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gpsCombox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int n = gpsCombox.SelectedIndex;
            n = n * 150;
            priceGps.Text = n.ToString();

        }
        #endregion
  
    }
}
