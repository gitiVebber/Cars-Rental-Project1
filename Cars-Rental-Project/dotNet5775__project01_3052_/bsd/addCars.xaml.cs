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
        public addCars(IBL bl, int num)
        {
            this.bl = bl;

            InitializeComponent();
            switch (num)
            {
                case 1:
                    addCarBotton.IsEnabled = true;
                    deleteCarBotton.IsEnabled = false;
                    updateCarBotton.IsEnabled = false;
                    numberCarsComboBox.IsEditable = false;

                    break;
                case 2:
                    addCarBotton.IsEnabled = false;
                    deleteCarBotton.IsEnabled = false;
                    updateCarBotton.IsEnabled = true;
                    numberCarsComboBox.DataContext= bl.getAllCars();
                    //numberCarsComboBox.DisplayMemberPath= "id";
                   // numberCarsComboBox.DataContext = bl.getAllCars();
                    //ComboBoxItem b=new ComboBoxItem();
                    //foreach (var item in bl.getAllCars())

                    //{
                    //    b.Content = item.numberCar;
                        
                    //}

                    //numberCarsComboBox.Items.Add(b);
                    
                    break;
                case 3:
                    addCarBotton.IsEnabled = false;
                    deleteCarBotton.IsEnabled = true;
                    updateCarBotton.IsEnabled = false;
                    break;
            }
        }

        void addCarBotton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car c = new Car
                {
                    
                    adressBranch = adressBranchTextBox.Text,
                    creatureCar = DateTime.Parse(creatureCarDatePicker.Text),
                    dateLicensed = DateTime.Parse(dateLicensedDatePicker.Text),
                    KM = int.Parse(kMTextBox.Text),
                    sumDoors = int.Parse(sumDoorsTextBox.Text),
                    LicensePlate = numberCarTextBox.Text,
                    sumTravelers = int.Parse(sumTravelersTextBox.Text),
                    tybeCar = new TybeCar { model = modelTextBox.Text, name = nameTextBox.Text, sizeMotor = int.Parse(sizeMotorTextBox.Text) }

                };
                bl.addCar(c);
                MessageBox.Show("Car added successfuly!");
                
            
            }
            catch (Exception)
            {
                MessageBox.Show("not add");
            }
            

        }

        private void updateCarBotton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car c = new Car
                {
                // adressBranchTextBox.Text=c.

                    adressBranch = adressBranchTextBox.Text,
                    creatureCar = DateTime.Parse(creatureCarDatePicker.Text),
                    dateLicensed = DateTime.Parse(dateLicensedDatePicker.Text),
                    KM = int.Parse(kMTextBox.Text),
                    sumDoors = int.Parse(sumDoorsTextBox.Text),
                    numberCar = int.Parse(numberCarTextBox.Text),
                    sumTravelers = int.Parse(sumTravelersTextBox.Text),
                    tybeCar = new TybeCar { model = modelTextBox.Text, name = nameTextBox.Text, sizeMotor = int.Parse(sizeMotorTextBox.Text) }
                };

                bl.updateCar(c);
                MessageBox.Show("Car updete successfuly!");
            }
            catch (Exception)
            {
                MessageBox.Show("not update");

            }
        }

        private void numberCarsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // this.bl = bl;
            if (numberCarsComboBox.ToString() != null)
            {
               // Car car = bl.GetCar(numberCarsComboBox.SelectedItem.ToString());
             // Car car = bl.getAllCars().FirstOrDefault(c => c.numberCar == (numberCarsComboBox.SelectedItem)));
               Car car = bl.getAllCars().FirstOrDefault(c => c.numberCar ==(Convert.ToInt16(numberCarsComboBox.SelectedItem.ToString())));
                if (car != null)
                {
                    deleteCarBotton.IsEnabled = true;
                    updateCarBotton.IsEnabled = true;
                    adressBranchTextBox.Text = car.adressBranch;
                    creatureCarDatePicker.Text = car.creatureCar.ToString();
                    // dateLicensedDatePicker.Text = car.dateLicensed.ToString();
                    kMTextBox.Text = car.KM.ToString();
                    sumDoorsTextBox.Text = car.sumDoors.ToString();
                    numberCarTextBox.Text = car.numberCar.ToString();
                    sumTravelersTextBox.Text = car.sumTravelers.ToString();
                    modelTextBox.Text = car.tybeCar.model.ToString();
                    nameTextBox.Text = car.tybeCar.name;
                    sizeMotorTextBox.Text = car.tybeCar.sizeMotor.ToString();
                }
            }
        }
    }
}
    

