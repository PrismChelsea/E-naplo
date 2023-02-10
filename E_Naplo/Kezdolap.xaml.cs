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

namespace E_Naplo
{
    /// <summary>
    /// Interaction logic for Kezdolap.xaml
    /// </summary>
    public partial class Kezdolap : Window
    {
        public Kezdolap()
        {
            InitializeComponent();
        }
        private void startsbutton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow sw2 = new MainWindow();
            sw2.Show();
            Close();
        }

        private void felhasznalo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (felhasznalo.Text != "" && jelszo.Password != "")
            {
                startsbutton.IsEnabled = true;
            }
            else
            {
                startsbutton.IsEnabled = false;
            }
        }

        private void jelszo_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (felhasznalo.Text != "" && jelszo.Password != "")
            {
                startsbutton.IsEnabled = true;
            }
            else
            {
                startsbutton.IsEnabled = false;
            }
        }

        private void kilepesgomb_Click(object sender, RoutedEventArgs e)
        {
            kezdolap.Close();
        }
    }
}
