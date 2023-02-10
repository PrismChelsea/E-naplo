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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace E_Naplo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ReadIn> enaplo = new List<ReadIn>();
        List<Jegyek> jegyek = new List<Jegyek>();

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in File.ReadAllLines("Tanulók.txt"))
            {
                enaplo.Add(new ReadIn(item));

                //switch (new ReadIn(item).Sorszám % 6)
                //{
                //    case 0:
                //        datas.RowBackground = new SolidColorBrush(Colors.Red);
                //        break;
                //    case 1:
                //        datas.AlternatingRowBackground = new SolidColorBrush(Colors.Orange);
                //        break;
                //    case 2:
                //        datas.AlternatingRowBackground = new SolidColorBrush(Colors.Yellow);
                //        break;
                //    case 3:
                //        datas.AlternatingRowBackground = new SolidColorBrush(Colors.DarkGreen);
                //        break;
                //    case 4:
                //        datas.AlternatingRowBackground = new SolidColorBrush(Colors.Blue);
                //        break;
                //    case 5:
                //        datas.AlternatingRowBackground = new SolidColorBrush(Colors.Purple);
                //        break;
                //}
            }
            datas.ItemsSource = enaplo;
            selectsearch.Items.Add("Név");
            selectsearch.Items.Add("Évfolyam");
            selectsearch.Items.Add("Osztály");
            CreateButton.Visibility = Visibility.Collapsed;



        }

        private void Create()
        {

            for (int i = 0; i < enaplo.Count; i++)
            {
                string fileName = @"C:\Users\gomcs\Documents\GitHub\E-naplo\E_Naplo\jegyek.txt";

                FileStream stream = null;
                try
                {
                    stream = new FileStream(fileName, FileMode.OpenOrCreate);
                    using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                    {

                        for (int j = 0; j < enaplo.Count; j++)
                        {
                            string classyear = enaplo[j].Évfolyam + enaplo[j].Osztály;

                            Random r = new Random();
                            for (int b = 0; b < 10; b++)
                            {
                                int vrg = r.Next(1, 6);
                                writer.Write(vrg + ";");
                            }
                            writer.Write(enaplo[j].Név + ";");
                            writer.WriteLine(classyear + ";");
                        }
                    }
                }
                finally
                {
                    if (stream != null)
                        stream.Dispose();
                }
                string readText = File.ReadAllText(fileName);
                Console.WriteLine(readText);


                //Ez az eredeti profram, amiben létrejött minden diákhoz egy fájl, de ez sokkal energiaigényesebb volt, mint egy hosszú fájlt létrehozni.

                /*string fileName = @"C:\Users\gomcs\Documents\GitHub\E-naplo\E_Naplo\" + enaplo[i].Név + ".txt";

                FileStream stream = null;
                try
                {
                    stream = new FileStream(fileName, FileMode.OpenOrCreate);
                    using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                    {
                        Random r = new Random();
                        writer.Write(enaplo[i].Név);
                        for (int b = 0; b < 10; b++)
                        {
                            int vrg = r.Next(1, 6);
                            writer.Write(";" + vrg );
                        }
                    }
                }
                finally
                {
                    if (stream != null)
                        stream.Dispose();
                }
                string readText = File.ReadAllText(fileName);
                Console.WriteLine(readText);
                */
            }

        }


        private void searchbutton_Click(object sender, RoutedEventArgs e)
        {
            if (selectsearch.Text == "Név")
            {
                datas.Items.Refresh();
                var srchname = enaplo
                  .Where(x => x.Név == searchtext.Text)
                  .Select(x => new { Sorszám = x.Sorszám, Név = x.Név, Évfolyam = x.Évfolyam, Osztály = x.Osztály })
                   .ToList();
                datas.ItemsSource = srchname;
            }
            else if (selectsearch.Text == "Évfolyam")
            {
                datas.Items.Refresh();
                var srchclass = enaplo
                  .Where(x => x.Évfolyam == searchtext.Text)
                  .Select(x => new { Sorszám = x.Sorszám, Név = x.Név, Évfolyam = x.Évfolyam, Osztály = x.Osztály })
                   .ToList();
                datas.ItemsSource = srchclass;
            }
            else if (selectsearch.Text == "Osztály")
            {
                datas.Items.Refresh();
                var srchclass = enaplo
                  .Where(x => x.Osztály == searchtext.Text)
                  .Select(x => new { Sorszám = x.Sorszám, Név = x.Név, Évfolyam = x.Évfolyam, Osztály = x.Osztály })
                  .ToList();
                datas.ItemsSource = srchclass;
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Create();
        }


        private void newmark_Click(object sender, RoutedEventArgs e)
        {
            NewMark sw = new NewMark();
            sw.Show();
            Close();
        }

        private void kilepesgomb_Click(object sender, RoutedEventArgs e)
        {
            foablak.Close();
        }
    }
}
