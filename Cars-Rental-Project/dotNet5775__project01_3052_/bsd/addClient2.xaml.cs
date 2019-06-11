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
    /// Interaction logic for addClient2.xaml
    /// </summary>
    public partial class addClient2 : Window
    {
         IBL bl;
        public addClient2(IBL bl, int num)
        {
            this.bl = bl;
            InitializeComponent();
            switch (num)
            { 
                case 1:
                    addBotton.IsEnabled = true;
                    deleteBotton.IsEnabled = false;
             updeteBotton.IsEnabled = false;
                    
                    break;
                       case 2:
                    addBotton.IsEnabled = false;
                    deleteBotton.IsEnabled = false;
                 updeteBotton.IsEnabled   = true;
                    break;
                       case 3:
                    addBotton.IsEnabled = false;
                    deleteBotton.IsEnabled = true;
                    updeteBotton.IsEnabled = false;
                    break;
            }
            }

        private void addBotton_Click(object sender, RoutedEventArgs e)
        {
            Client c = new Client();
            c.IDClient = int.Parse(lableID.Text);
           // c.Celephone=int.Parse(
           // bl.addClient(c);
            
        }
        }
    }

