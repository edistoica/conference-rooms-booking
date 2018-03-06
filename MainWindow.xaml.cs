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

namespace Proiect_BD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<DataRow> usrList;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogIn(object sender, RoutedEventArgs e)
        {
            string userString = userTextBox.Text;
            string passString = passwordBox.Password;
            var result = new DataTable();
            

            if (String.IsNullOrEmpty(userString))
            {
                MessageBox.Show("Please enter your username:");
                userTextBox.Text = string.Empty;
                return;
            }

            if(String.IsNullOrEmpty(passString))
            {
                MessageBox.Show("Please enter your password:");
                passwordBox.Password = string.Empty;
                return;
            }

            try
            {
                using (var sqlConnection = new SqlConnection(App.connectionString)) //verificam userii 
                {
                    sqlConnection.Open();

                    using (var command = sqlConnection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = "select * from [User]";

                        using (var reader = command.ExecuteReader())
                        {
                            result.Load(reader);
                        }
                    }

                }
            }

            catch (Exception ex)
            {

                throw;
            }

            usrList = result.AsEnumerable().ToList();

            int ok = 0;
            foreach (var usr in usrList)
            {

                if (userString.Equals(usr.ItemArray[3]) && passString.Equals(usr.ItemArray[4]))
                {
                    ok = 1;
                    App.LogInId = (int)usr.ItemArray[0];

                    Menu_Window menuWindow = new Menu_Window();
                    this.Close();
                    menuWindow.ShowDialog();
                    return;
                }
            }
            if (ok == 0)
            {
                MessageBox.Show("Incorrect username or password. Try again!");
                userTextBox.Text = string.Empty;
                passwordBox.Password = string.Empty;
                return;
            }
        }
    }
}
