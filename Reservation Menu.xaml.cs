using Proiect_BD.Front_Office.ViewModels;
using Proiect_BD.Front_Office.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Proiect_BD
{
    /// <summary>
    /// Interaction logic for Reservation_Menu.xaml
    /// </summary>
    public partial class Reservation_Menu : Window
    {
        public Reservation_Menu()
        {
            InitializeComponent();
        }

        private void Data_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new DataViewModel();
        }

        private void Ora_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new OraViewModel();

        }

        private void Sala_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new SalaViewModel();

        }

        private void Observatii_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ObservatiiViewModel();

        }
    }
}
