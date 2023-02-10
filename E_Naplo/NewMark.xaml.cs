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
using System.IO;


namespace E_Naplo
{
    /// <summary>
    /// Interaction logic for NewMark.xaml
    /// </summary>
    public partial class NewMark : Window
    {
       public  List<Jegyek> jegyek = new List<Jegyek>();

        public NewMark()
        {

            InitializeComponent();

            selectclass.Items.Add("9A");
            selectclass.Items.Add("9B");
            selectclass.Items.Add("9C");
            selectclass.Items.Add("10A");
            selectclass.Items.Add("10B");
            selectclass.Items.Add("10C");
            selectclass.Items.Add("11A");
            selectclass.Items.Add("11B");
            selectclass.Items.Add("11C");
            selectclass.Items.Add("12A");
            selectclass.Items.Add("12B");
            selectclass.Items.Add("12C");


        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            foreach (var item in File.ReadAllLines("jegyek.txt"))
            {
                jegyek.Add(new Jegyek(item));
            }
            grades.ItemsSource = jegyek;

           
        }

        private void averagebutton_Click(object sender, RoutedEventArgs e)
        {
            if (selectclass.Text != "")
            {
                grades.Items.Refresh();
                var averagevar = jegyek
                    .Where(x => x.PontosOsztály == selectclass.Text)
                    //Averege(x => x.ValamilyenTantárgy)
                    .Select(x => new { PontosOsztáy = x.PontosOsztály, Név = x.Név, Matematika = x.Matematika, Szorgalom = x.Szorgalom, Nyelvtan = x.Nyelvtan, Irodalom = x.Irodalom, Földrajz = x.Földrajz, Biológia = x.Biológia, Kémia = x.Kémia, Informatika = x.Informatika, Történelem = x.Történelem, Magatartás = x.Magatartás })
                    .ToList();
                grades.ItemsSource = averagevar;

            }


        }

        private void backbutton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow sw2 = new MainWindow();
            sw2.Show();
            Close();
        }

        private void studentbutton_Click(object sender, RoutedEventArgs e)
        {
            List<ReadIn> enaplo = new List<ReadIn>();
                var srchname = jegyek
                  .Where(x => x.Név.Contains(searchtext.Text))
                  .Select(x => new { PontosOsztáy = x.PontosOsztály, Név = x.Név, Matematika = x.Matematika, Szorgalom = x.Szorgalom, Nyelvtan = x.Nyelvtan, Irodalom = x.Irodalom, Földrajz = x.Földrajz, Biológia = x.Biológia, Kémia = x.Kémia, Informatika = x.Informatika, Történelem = x.Történelem, Magatartás = x.Magatartás })
                  .ToList();
                grades.ItemsSource = srchname;
            grades.Items.Refresh();

        }

        private void kilepesgomb_Click(object sender, RoutedEventArgs e)
        {
            newmark.Close();
        }
    }
}
