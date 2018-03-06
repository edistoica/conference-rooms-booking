using System;
using System.Collections.Generic;
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
    /// Interaction logic for ObservatiiView.xaml
    /// </summary>
    public partial class ObservatiiView : UserControl  //ferestra de observatii privind mangerul si departmentul care fac rezervarea
    {
        private List<DataRow> obsList_Manager;
        private List<DataRow> obsList_Departament;
        private string manager_name, department_name;
        private string nume_rezervare;

        public ObservatiiView()
        {
            InitializeComponent();
            Loaded += ObservatiiView_Loaded;
        }

        private void ObservatiiView_Loaded(object sender, RoutedEventArgs e) 
        {
            var result = new DataTable();
            try
            {
                using (var sqlConnection = new SqlConnection(App.connectionString))
                {
                    sqlConnection.Open();

                    using (var command = sqlConnection.CreateCommand()) //comanda de selectare a id-ului managerului
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = "SELECT Id, Nume FROM Manager";

                        using (var reader = command.ExecuteReader())
                        {
                            result.Load(reader);
                        }
                    }
                    obsList_Manager = result.AsEnumerable().ToList();

                    using (var command = sqlConnection.CreateCommand()) //comanda de selectare a id-ului departamentului
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = "SELECT Id, Nume FROM Department";

                        using (var reader = command.ExecuteReader())
                        {
                            result.Load(reader);
                        }
                    }
                    obsList_Departament = result.AsEnumerable().ToList();

                }
            }

            catch (Exception ex)
            {

                throw;
            }

            foreach (var item in obsList_Manager)
            {
                textbox_Manager.Items.Add(item[1]);
            }

            foreach (var item in obsList_Departament)
            {
                textbox_Departament.Items.Add(item[1]);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int manager_id=0;

            TimeSpan span = new TimeSpan(App.hour_time, 0, 0);
            DateTime date = App.date_time.Add(span);

            manager_name = (string)textbox_Manager.SelectedValue;
            department_name = (string)textbox_Departament.SelectedValue;
            nume_rezervare = (string)Nume_Rezervare.Text;            

            if (String.IsNullOrEmpty(manager_name)&&String.IsNullOrEmpty(department_name)&&String.IsNullOrEmpty(nume_rezervare))
            {
                MessageBox.Show("Please introduce manager&department:");
            }

            foreach (var item in obsList_Manager)
            {
                if ((string)item[1] == manager_name)
                    manager_id = (int)item[0];
            }

            try
            {
                using (var sqlConnection = new SqlConnection(App.connectionString))
                {
                    sqlConnection.Open();

                    using (var command = sqlConnection.CreateCommand()) //se insereaza datele noi introduse in baza de date
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("@sala_id", SqlDbType.Int);
                        command.Parameters["@sala_id"].Value = App.IdSala;

                        command.Parameters.Add("@manager_id", SqlDbType.Int);
                        command.Parameters["@manager_id"].Value = manager_id;

                        command.Parameters.Add("@nume", SqlDbType.NVarChar);
                        command.Parameters["@nume"].Value = nume_rezervare;

                        command.Parameters.Add("@data", SqlDbType.DateTime);
                        command.Parameters["@data"].Value = date;

                        command.CommandText = "INSERT into Rezervare (Sala_Id, Manager_Id, Nume, Data) values(@sala_id, @manager_id, @nume, @data)";

                        command.ExecuteNonQuery();
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
