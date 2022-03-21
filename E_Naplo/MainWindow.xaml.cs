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
        List<ReadIn> enaplo=new List<ReadIn>();

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
            selectsearch.Items.Add("Sorszám");
            selectsearch.Items.Add("Név");
            selectsearch.Items.Add("Évfolyam");
            selectsearch.Items.Add("Osztály");
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

        
    }
}
