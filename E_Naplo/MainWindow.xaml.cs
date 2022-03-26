﻿using System;
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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in File.ReadAllLines("Tanulók.txt"))
            {
                enaplo.Add(new ReadIn(item));
            }
            datas.ItemsSource = enaplo;
            selectsearch.Items.Add("Név");
            selectsearch.Items.Add("Évfolyam");
            selectsearch.Items.Add("Osztály");
            CreateButton.Visibility=Visibility.Collapsed; 
        }

        private void Create()
        {
            
            for (int i = 0; i < enaplo.Count; i++)
            {
                string fileName = @"C:\Users\gomcs\Documents\GitHub\E-naplo\E_Naplo\bin\" + enaplo[i].Név + ".txt";

                FileStream stream = null;
                try
                {
                    // Create a FileStream with mode CreateNew  
                    stream = new FileStream(fileName, FileMode.OpenOrCreate);
                    // Create a StreamWriter from FileStream  
                    using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                    {
                        Random r = new Random();
                        for (int b = 0; b < 10; b++)
                        {
                            int vrg = r.Next(1, 6);
                            writer.WriteLine(vrg);
                        }
                    }
                }
                finally
                {
                    if (stream != null)
                        stream.Dispose();
                }
                // Read a file  
                string readText = File.ReadAllText(fileName);
                Console.WriteLine(readText);
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

        private void averagebutton_Click(object sender, RoutedEventArgs e)
        {
            /*if (selectsearch.Text == "Név")
            {
                datas.Items.Refresh();
                var averagevar = jegyek
                    .Where(x => x.Név == selectsearch.Text)
                    .Average(x => x.Osztályzat)
                    .Select(x => new { Név = x.Név, Osztály = x.Osztály, Évfolyam = x.Évfolyam, Osztályzat = x.Osztályzat })
                    .ToList();
                datas.ItemsSource = averagevar;

            }
            else if (selectsearch.Text == "Évfolyam")
            {
                datas.Items.Refresh();
                var averagevar = jegyek
                    .Where(x => x.Évfolyam == selectsearch.Text)
                    .Average(x => x.Osztályzat)
                    .Select(x => new { Név = x.Név, Osztály = x.Osztály, Évfolyam = x.Évfolyam, Osztályzat = x.Osztályzat })
                    .ToList();
                datas.ItemsSource = averagevar;
            }
            else if (selectsearch.Text == "Osztály")
            {
                datas.Items.Refresh();
                var averagevar = jegyek
                    .Where(x => x.Osztály == selectsearch.Text)
                    .Average(x => x.Osztályzat)
                    .Select(x => new { Név = x.Név, Osztály = x.Osztály, Évfolyam = x.Évfolyam, Osztályzat = x.Osztályzat })
                    .ToList();
                datas.ItemsSource = averagevar;
            }*/
            
        }
    }
}
