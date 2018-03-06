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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proiect_BD.Front_Office.Views
{
    /// <summary>
    /// Interaction logic for DataView.xaml
    /// </summary>
    public partial class DataView : UserControl   //fereastra de setare a datei
    {
        public DataView()
        {
            InitializeComponent();
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e) //editam butonul de alegere a datei
        {
            App.date_time = datePicker.SelectedDate.Value.Date;
        }
    }
}
