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
namespace PLForm2
{
    /// <summary>
    /// Interaction logic for addClient.xaml
    /// </summary>
    public partial class addClient1 : Window
    {
        IBL bl;
        public addClient1(IBL bl, int num)
        {
            this.bl = bl;
            InitializeComponent();
            switch (num)
            {
                case 1:
                    addButton.IsEnabled = true;
                    deleteBotton.IsEnabled = false;
                    updateBotton.IsEnabled = false;
                    break;

                case 2:
                    addButton.IsEnabled = false;
                    deleteBotton.IsEnabled = false;
                    updateBotton.IsEnabled = true;
                    break;
            }
        }
        //public addClient()
        //{
        //    this.bl = bl;
        //    InitializeComponent();
        //}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
