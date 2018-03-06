using Proiect_BD.Front_Office.ViewModels;
using Proiect_BD.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for SalaView.xaml
    /// </summary>
    public partial class SalaView : UserControl, INotifyPropertyChanged //fereastra de alegere a salii
    {
        private ObservableCollection<Sala> list;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Sala> List
        {
            get { return list; }
            set
            {
                list = value;
                NotifyPropertyChanged("List");
            }
        }

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public SalaView()
        {
            InitializeComponent();
            Loaded += SalaView_Loaded;
            DataContext = this;
        }

        private void SalaView_Loaded(object sender, RoutedEventArgs e)
        {
            List = new ObservableCollection<Sala>();
            var dt = new DataTable();
            List<DataRow> dtList;

            try
            {
                using (var sqlConnection = new SqlConnection(App.connectionString))  //comadnad e select a salii
                {
                    sqlConnection.Open();

                    using (var command = sqlConnection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = "select * from Sala";

                        using (var reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            dtList = dt.AsEnumerable().ToList();
            foreach (var item in dtList)
            {
                Sala salaModel = new Sala((int)item.ItemArray[0], (int)item.ItemArray[1], (int)item.ItemArray[2], (bool)item.ItemArray[3]);
                List.Add(salaModel);
            }
        }

        private void salaGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sala row = (Sala)salaGrid.SelectedItems[0];
            App.IdSala = row.Sala_Id;
        }
    }
}
