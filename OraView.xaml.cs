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
    /// Interaction logic for OraView.xaml
    /// </summary>
    public partial class OraView : UserControl //ferestra de alegere a orei
    {
        public OraView()
        {
            InitializeComponent();
        }

        private void Hour_Picker_SelectionChanged(object sender, SelectionChangedEventArgs e) //butonul de setare a timpului
        {
            App.hour_time = Hour_Picker.SelectedIndex;
        }
    }
}
