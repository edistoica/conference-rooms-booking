using Proiect_BD.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
    /// Interaction logic for Cancel_Menu.xaml
    /// </summary>
    public partial class Cancel_Menu : Window, INotifyPropertyChanged  //meniu pentru stergerea rezervarii
    {
        private ObservableCollection<Rezervare> list;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Rezervare> List
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

        public Cancel_Menu()
        {
            InitializeComponent();
            Loaded += Cancel_Menu_Loaded;
            DataContext = this;
        }

        private void Cancel_Menu_Loaded(object sender, RoutedEventArgs e)
        {
            List = new ObservableCollection<Rezervare>();
            var dt = new DataTable();
            List<DataRow> dtList;

            try
            {
                using (var sqlConnection = new SqlConnection(App.connectionString)) //selectam rezevrarea
                {
                    sqlConnection.Open();

                    using (var command = sqlConnection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = "select * from Rezervare";

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
                Rezervare rezervareModel = new Rezervare((int)item.ItemArray[0], (int)item.ItemArray[1], (int)item.ItemArray[2], (string)item.ItemArray[3], (DateTime)item.ItemArray[4]);
                List.Add(rezervareModel);
            }
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            var row = (Rezervare)rezervareGrid.SelectedItem;

            if (row == null)
                return;
            else
                List.Remove(row);

            try
            {
                using (var sqlConnection = new SqlConnection(App.connectionString)) //stergem din baza de date
                {
                    sqlConnection.Open();

                    using (var command = sqlConnection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("@id", SqlDbType.Int);
                        command.Parameters["@id"].Value = row.Rezervare_Id;
                        command.CommandText = "DELETE FROM Rezervare WHERE Id=@id";
                        command.ExecuteNonQuery();

                        MessageBox.Show("Rezervarea a fost staerasa cu succes!");
                        Process ps = new Process();

                        ps.StartInfo.FileName = @"C:\Users\Lenovo\Desktop\Proiect BD\Proiect BD\Proiect BD\bin\Debug\Proiect BD.exe";
                        ps.Start();
                        Process.GetCurrentProcess().Kill();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void rezervareGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
