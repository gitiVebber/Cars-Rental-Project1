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
    /// Interaction logic for client.xaml
    /// </summary>
    public partial class client : Window
    {
        IBL bl;
        /// <summary>
        /// constractor
        /// </summary>
        /// <param name="bl"></param>
        /// <param name="i"></param>
        public client(IBL bl, int i)
        {
            this.bl = bl;
            InitializeComponent();
            switch (i)
            {
                case 1://בבחירת הוספת לקוח
                    addClientBotton.IsEnabled = true;
                    deleteClientBotton.IsEnabled = false;
                    updateClientBotton.IsEnabled = false;
                    iDClientComboBox.Visibility = Visibility.Hidden;
                    iDClientComboBox.IsEnabled = false;
                    break;
                case 2://בבחירת עדכון לקוח
                    addClientBotton.IsEnabled = false;
                    deleteClientBotton.IsEnabled = false;
                    updateClientBotton.IsEnabled = true;
                    iDClientTextBox.IsEnabled = false;
                    iDClientComboBox.DataContext = bl.getAllClients();
                    dateOfDatePicker.IsEnabled = false;
                    break;
                case 3://בבחירת מחיקת לקוח
                    addClientBotton.IsEnabled = false;
                    deleteClientBotton.IsEnabled = true;
                    updateClientBotton.IsEnabled = false;
                    iDClientComboBox.DataContext = bl.getAllClients();
                    nameTextBox.IsEnabled = false;
                    lastNameTextBox.IsEnabled = false;
                    dateOfBirthDatePicker.IsEnabled = false;
                    addressClientTextBox.IsEnabled = false;
                    emailTextBox.IsEnabled = false;
                    codeTelephoneComboBox.IsEnabled = false;
                    numTelephoneTextBox.IsEnabled = false;
                    codePelePhoneComboBox.IsEnabled = false;
                    numPelePhoneTextBox.IsEnabled = false;
                    creditCerdTextBox.IsEnabled = false;
                    cVVTextBox.IsEnabled = false;
                    validityDatePicker.IsEnabled = false;
                    iDClientTextBox.IsEnabled = false;
                    dateOfDatePicker.IsEnabled = false;
                    break;
            }
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource clientViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clientViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // clientViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource tybeCarViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tybeCarViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // tybeCarViewSource.Source = [generic data source]
        }
        /// <summary>
        /// אירוע של מחיקת לקוח
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteClientBotton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client c = new Client
                {
                    IDClient = int.Parse(iDClientComboBox.Text),
                };
                bl.removeClient(c.IDClient);
                MessageBox.Show("Client delete successfuly!");
            }
            catch (Exception e1)
            {

                MessageBox.Show("" + e1.Message);
            }
        }
        /// <summary>
        /// אירוע של הוספת לקוח
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddClientButton_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

                #region Test Data:====בודק האם הלקוח הכניס את כל הנתונים וגם תקינות קלט לדוגמא לקוח צעיר מגיל 20 או תוקף כרטיס אשראי שפג
                if (iDClientTextBox.Text == "" || nameTextBox.Text == "" || lastNameTextBox.Text == "" || dateOfBirthDatePicker.Text == "" ||dateOfDatePicker.Text==""|| addressClientTextBox.Text == "" || emailTextBox.Text == "" || creditCerdTextBox.Text == "" || cVVTextBox.Text == "" || validityDatePicker.Text == "")
                {
                    throw new Exception("please fill all fields!");
                }
                if ((codeTelephoneComboBox.SelectedIndex == -1 || numTelephoneTextBox.Text == "") && (codePelePhoneComboBox.SelectedIndex == -1 || numPelePhoneTextBox.Text == ""))
                {
                    throw new Exception("Please fill in at least one contact number!");
                }

                long id; int num; DateTime d = new DateTime(1995, 1, 6); DateTime D = DateTime.Now;//משתני עזר
                if (!long.TryParse(iDClientTextBox.Text, out id))
                {
                    throw new Exception("put only numbers for ID!");
                }

                if (dateOfBirthDatePicker.SelectedDate > d)
                {
                    throw new Exception("Unable to add an early customer!");
                }

                if (validityDatePicker.SelectedDate < D)
                {
                    throw new Exception("Credit card validity expired!");
                }

                if ((!int.TryParse(numTelephoneTextBox.Text, out num) && numTelephoneTextBox.Text != "") || (!int.TryParse(numPelePhoneTextBox.Text, out num) && numPelePhoneTextBox.Text != ""))
                {
                    throw new Exception("put only numbers for Telephone!");
                }

                if (!int.TryParse(creditCerdTextBox.Text, out num) || !int.TryParse(cVVTextBox.Text, out num))
                {
                    throw new Exception("put only numbers for Credit card information!");
                }
                #endregion
                Client c = new Client
                {
                    IDClient = int.Parse(iDClientTextBox.Text),
                    name = nameTextBox.Text,
                    lastName = lastNameTextBox.Text,
                    dateOfBirth = Convert.ToDateTime(dateOfBirthDatePicker.ToString()),
                    addressClient = addressClientTextBox.Text,
                    Email = emailTextBox.Text,
                    codeTelephone = codeTelephoneComboBox.Text,
                    numTelephone = numTelephoneTextBox.Text,
                    codePelePhone = codePelePhoneComboBox.Text,
                    numPelePhone = numPelePhoneTextBox.Text,
                    creditCerd = creditCerdTextBox.Text,
                    CVV = cVVTextBox.Text,
                    validity = Convert.ToDateTime(validityDatePicker.ToString()),
                     dateOf=Convert.ToDateTime(dateOfDatePicker.ToString()),
                };

                bl.addClient(c);//bl שליחה לפונקצית ה
                MessageBox.Show("Client add successfuly!");
            }
            catch (Exception e1)
            {
                MessageBox.Show("" + e1.Message);
            }
        }
        /// <summary>
        /// אירוע של עידכון לקוח
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateClientBotton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                #region Test Data:====בודק האם הלקוח הכניס את כל הנתונים וגם תקינות קלט לדוגמא תוקף כרטיס אשראי שפג
                if (addressClientTextBox.Text == "" || emailTextBox.Text == "" || creditCerdTextBox.Text == "" || cVVTextBox.Text == "" || validityDatePicker.Text == "")
                {
                    throw new Exception("please fill all fields!");
                }
                if ((codeTelephoneComboBox.SelectedIndex == -1 || numTelephoneTextBox.Text == "") && (codePelePhoneComboBox.SelectedIndex == -1 || numPelePhoneTextBox.Text == ""))
                {
                    throw new Exception("Please fill in at least one contact number!");
                }

                int num; DateTime D = DateTime.Now;//משתני עזר


                if (validityDatePicker.SelectedDate < D)
                {
                    throw new Exception("Credit card validity expired!");
                }

                if ((!int.TryParse(numTelephoneTextBox.Text, out num) && numTelephoneTextBox.Text != "") || (!int.TryParse(numPelePhoneTextBox.Text, out num) && numPelePhoneTextBox.Text != ""))
                {
                    throw new Exception("put only numbers for Telephone!");
                }

                if (!int.TryParse(creditCerdTextBox.Text, out num) || !int.TryParse(cVVTextBox.Text, out num))
                {
                    throw new Exception("put only numbers for Credit card information!");
                }
                #endregion

                Client c = new Client
                {

                    IDClient = int.Parse(iDClientComboBox.Text),
                    addressClient = addressClientTextBox.Text,
                    Email = emailTextBox.Text,
                    codeTelephone = codeTelephoneComboBox.Text,
                    numTelephone = numTelephoneTextBox.Text,
                    codePelePhone = codePelePhoneComboBox.Text,
                    numPelePhone = numPelePhoneTextBox.Text,
                    creditCerd = creditCerdTextBox.Text,
                    CVV = cVVTextBox.Text,
                    validity = Convert.ToDateTime(validityDatePicker.ToString()),
                };

                bl.updateClient(c);//bl שליחה לפונקצית ה
                MessageBox.Show("Client updete successfuly!");
            }
            catch (Exception e1)
            {

                MessageBox.Show("" + e1.Message);
            }

        }
        /// <summary>
        /// האירוע בבחירת מספר זהות של לקוח (במקרה של עידכון או מחיקה) העלאת כל הנתונים של  אותו לקוח
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iDClientComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (iDClientComboBox.Text != null)
            {
                Client c = bl.GetClient(int.Parse(iDClientComboBox.SelectedValue.ToString()));
                if (c != null)
                {
                    nameTextBox.Text = c.name;
                    lastNameTextBox.Text = c.lastName;
                    dateOfBirthDatePicker.Text = c.dateOfBirth.ToString();
                    addressClientTextBox.Text = c.addressClient;
                    emailTextBox.Text = c.Email;
                    codeTelephoneComboBox.Text = c.codeTelephone;
                    numTelephoneTextBox.Text = c.numTelephone;
                    codePelePhoneComboBox.Text = c.codePelePhone;
                    numPelePhoneTextBox.Text = c.numPelePhone;
                    creditCerdTextBox.Text = c.creditCerd;
                    cVVTextBox.Text = c.CVV;
                    validityDatePicker.Text = c.validity.ToString();
                    dateOfDatePicker.Text = c.dateOf.ToString();
                    nameTextBox.IsEnabled = false;
                    lastNameTextBox.IsEnabled = false;
                    dateOfBirthDatePicker.IsEnabled = false;
                }
            }
        }
    }
}
