using Proiect_BD.Models;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for ExecuteModification.xaml
    /// </summary>
    public partial class ExecuteModification : Window  //modificarea unei rezervari
    {
        public ExecuteModification()
        {
            InitializeComponent();
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            App.date_time = datePicker.SelectedDate.Value.Date;
        }

        private void Ok_button(object sender, RoutedEventArgs e)
        {
            string nume_sala = Nume_Sala.Text;            
            try
            {

                using (var sqlConnection = new SqlConnection(App.connectionString)) //update-ul campurilor
                {
                    sqlConnection.Open();

                    using (var command = sqlConnection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("@nume", SqlDbType.Text);
                        command.Parameters["@nume"].Value = nume_sala;

                        command.Parameters.Add("@data", SqlDbType.DateTime);
                        command.Parameters["@data"].Value = App.date_time;

                        command.Parameters.Add("@IdSala", SqlDbType.Int);
                        command.Parameters["@IdSala"].Value =App.IdSala;

                        command.CommandText = "UPDATE Rezervare SET Nume=@nume, Data=@data WHERE Sala_Id=@IdSala";

                        command.ExecuteNonQuery();

                        MessageBox.Show("Ati efectuat modificarea cu succes!");

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
    }
}
