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
    /// Interaction logic for addCars.xaml
    /// </summary>
    public partial class addCars : Window
    {
        IBL bl;
        #region  consrtactor
        public addCars(IBL bl, int num)
        {
            this.bl = bl;
            InitializeComponent();
            switch (num)
            {
                case 1://add car
                    addCarBotton.IsEnabled = true;
                    deleteCarBotton.IsEnabled = false;
                    updateCarBotton.IsEnabled = false;
                    numberCarsComboBox.IsEditable = false;
                    numberCarsComboBox.Visibility = Visibility.Hidden;
                    break;
                case 2://update car
                    addCarBotton.IsEnabled = false;
                    deleteCarBotton.IsEnabled = false;
                    updateCarBotton.IsEnabled = true;
                    numberCarsComboBox.ItemsSource = bl.getAllCars();
                    numberCarsComboBox.DisplayMemberPath = "LicensePlate";
                    numberCarTextBox.IsEnabled = false;
                    deleteCarBotton.IsEnabled = false;
                    sumDoorsTextBox.IsEnabled = false;
                    numberCarTextBox.IsEnabled = false;
                    sumTravelersTextBox.IsEnabled = false;
                    nameComboBox.IsEnabled = false;
                    modelTextBox.IsEnabled = false;
                    automtonCombox.IsEditable = false;
                    break;
                case 3://delete car                
                    automtonCombox.IsEditable = false;
                    updateCarBotton.IsEnabled = false;
                    addCarBotton.IsEnabled = false;
                    deleteCarBotton.IsEnabled = true;
                    updateCarBotton.IsEnabled = false;
                    numberCarsComboBox.ItemsSource = bl.getAllCars();
                    numberCarsComboBox.DisplayMemberPath = "LicensePlate";
                    numberCarTextBox.IsEnabled = false;
                    adressBranchComboBox.IsEnabled = false;
                    creatureCarDatePicker.IsEnabled = false;
                    creatureCarDatePicker1.IsEnabled = false;
                    sizeMotorTextBox.IsEnabled = false;
                    sumDoorsTextBox.IsEnabled = false;
                    numberCarTextBox.IsEnabled = false;
                    sumTravelersTextBox.IsEnabled = false;
                    kMTextBox.IsEnabled = false;
                    dateLicensedDatePicker.IsEnabled = false;
                    nameComboBox.IsEnabled = false;
                    modelTextBox.IsEnabled = false;
                    automtonCombox.IsEnabled = false;
                    break;
            }
        }
        #endregion
        /// <summary>
        /// אירוע של הוספת רכב
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void addCarBotton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int num;
                if ((!int.TryParse(numberCarTextBox.Text, out num)) || (numberCarTextBox.Text == ""))//בודק תקינות קלט מספר רכב
                    throw new Exception("put only numbers for  number Car");

                if (kMTextBox.Text == "" || sizeMotorTextBox.Text == "")//בודק האם מילאו את כל הפרטים הדרושים
                    throw new Exception("not fill all Fields");

                if (!int.TryParse(kMTextBox.Text, out num))//תקינות קלט KM
                {
                    throw new Exception("put only numbers for KM");
                }
                if ((!int.TryParse(sumDoorsTextBox.Text, out num)) || (int.Parse(sumDoorsTextBox.Text) < 1) || (int.Parse(sumDoorsTextBox.Text) > 6))//תקינות קלט מספר דלתות
                    throw new Exception("put only reasonable numbers for doors between 1-6");
                DateTime d = DateTime.Now;
                if (creatureCarDatePicker1.SelectedDate > d)//תקינות קלט תאריך יצור רכב
                    throw new Exception("Please enter cars already created");
                DateTime d1 = new DateTime(2010, 1, 6);//תאריך רשוי ישן
                if (dateLicensedDatePicker.SelectedDate < d1)
                    throw new Exception("The car needs to pass test");
                if (!int.TryParse(sizeMotorTextBox.Text, out num))
                    throw new Exception("put only  reasonable numbers for  size Motor");

                Car c = new Car
                {

                    adressBranch = adressBranchComboBox.Text,
                    creatureCar = DateTime.Parse(creatureCarDatePicker1.ToString()),
                    dateLicensed = DateTime.Parse(dateLicensedDatePicker.ToString()),
                    KM = int.Parse(kMTextBox.Text),
                    sumDoors = int.Parse(sumDoorsTextBox.Text),
                    LicensePlate = numberCarTextBox.Text,
                    sumTravelers = int.Parse(sumTravelersTextBox.Text),
                    tybeCar = new TybeCar { model = modelTextBox.Text, name = nameComboBox.Text, sizeMotor = int.Parse(sizeMotorTextBox.Text) },
                    isAutomat = (automat)automtonCombox.SelectedIndex
                };
                bl.addCar(c);//bl שליחה לפונקצית ה 
                MessageBox.Show("Car added successfuly!");


            }
            catch (Exception e1)
            {
                MessageBox.Show("" + e1.Message);
            }


        }
        /// <summary>
        /// אירוע של עדכון רכב
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateCarBotton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                //תקינות קלט במשתנים שאופשרו לעידכון (כנ"ל בהוספה) י
                if (kMTextBox.Text == "" || sizeMotorTextBox.Text == "")
                    throw new Exception("not fill all Fields");
                int num;
                if (!int.TryParse(kMTextBox.Text, out num))
                {
                    throw new Exception("put only numbers for KM");
                }
                if ((!int.TryParse(sumDoorsTextBox.Text, out num)) || (int.Parse(sumDoorsTextBox.Text) < 1))
                    throw new Exception("put only  reasonable numbers for  doors");
                DateTime d = DateTime.Now;
                if (creatureCarDatePicker1.SelectedDate > d)
                    throw new Exception("Please enter cars already created");
                DateTime d1 = new DateTime(2010, 1, 6);
                if (dateLicensedDatePicker.SelectedDate < d1)
                    throw new Exception("The car needs to pass test");
                if (!int.TryParse(sizeMotorTextBox.Text, out num))
                    throw new Exception("put only  reasonable numbers for  size Motor");

                Car c = new Car
                {
                    LicensePlate = numberCarsComboBox.SelectedValue.ToString(),
                    numberCar = int.Parse(numberCarsComboBox.Text),
                    adressBranch = adressBranchComboBox.Text,
                    KM = int.Parse(kMTextBox.Text),
                    sumDoors = int.Parse(sumDoorsTextBox.Text),
                    sumTravelers = int.Parse(sumTravelersTextBox.Text),
                    tybeCar = new TybeCar { model = modelTextBox.Text, name = nameComboBox.Text, sizeMotor = int.Parse(sizeMotorTextBox.Text) }
                };

                bl.updateCar(c);//bl שליחה לפונקצית ה 
                MessageBox.Show("Car updete successfuly!");
            }
            catch (Exception e1)
            {
                MessageBox.Show("not update becaus \n" + e1.Message);

            }
        }
        /// <summary>
        /// אירוע של העלאת הנתונים של הרכבים שנבחר בכפתור
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numberCarsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (numberCarsComboBox.SelectedValue != null)
            {
                Car car = bl.GetCar(numberCarsComboBox.SelectedValue.ToString());

                if (car != null)
                {
                    adressBranchComboBox.Text = car.adressBranch.ToString();
                    creatureCarDatePicker1.Text = car.creatureCar.ToString();
                    dateLicensedDatePicker.Text = car.dateLicensed.ToString();
                    kMTextBox.Text = car.KM.ToString();
                    sumDoorsTextBox.Text = car.sumDoors.ToString();
                    numberCarTextBox.Text = car.LicensePlate.ToString();
                    sumTravelersTextBox.Text = car.sumTravelers.ToString();
                    modelTextBox.Text = car.tybeCar.model.ToString();
                    nameComboBox.Text = car.tybeCar.name;
                    sizeMotorTextBox.Text = car.tybeCar.sizeMotor.ToString();
                    creatureCarDatePicker1.IsEnabled = false;
                    automtonCombox.Text = car.isAutomat.ToString();

                }
            }
        }
        /// <summary>
        /// פונקצית מחיקת רכב
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteCarBotton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car c = new Car
                {
                    LicensePlate = numberCarTextBox.Text
                };

                bl.removeCar(c.LicensePlate);//bl שליחה לפונקצית ה 
                MessageBox.Show("Car remove successfuly!");
            }
            catch (Exception)
            {
                MessageBox.Show("not remove because this car is by renting");

            }
            this.Close();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource carViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("carViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // carViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource tybeCarViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tybeCarViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // tybeCarViewSource.Source = [generic data source]
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void numberCarTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}


