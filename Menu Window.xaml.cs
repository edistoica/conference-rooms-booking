using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace Proiect_BD
{
    /// <summary>
    /// Interaction logic for Menu_Window.xaml
    /// </summary>
    public partial class Menu_Window : Window
    {
        public Menu_Window()
        {
            InitializeComponent();
        }

        private void Make_Reservation(object sender, RoutedEventArgs e)
        {
            Reservation_Menu window = new Reservation_Menu();
            window.ShowDialog();
        }

        private void Modify_Reservation(object sender, RoutedEventArgs e)
        {
            ModifyMenu window = new ModifyMenu();
            window.ShowDialog();
        }

        private void Cancel_Reservation(object sender, RoutedEventArgs e)
        {
            Cancel_Menu window = new Cancel_Menu();
            window.ShowDialog();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Process ps = new Process();

            ps.StartInfo.FileName = @"C:\Users\Lenovo\Desktop\Proiect BD\Proiect BD\Proiect BD\bin\Debug\Proiect BD.exe";
            ps.Start();
            Process.GetCurrentProcess().Kill();
        }

        private void Query1_Click(object sender, RoutedEventArgs e)
        {
            var result = new DataTable();
            List<DataRow> usrList;
            try
            {
                using (var sqlConnection = new SqlConnection(App.connectionString))
                {
                    sqlConnection.Open();

                    using (var command = sqlConnection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"SELECT D.Nume FROM Department D
                                                WHERE D.Id IN
                                                (SELECT Depart_ID from Manager M
                                                where M.Id IN 
                                                (SELECT Id from Manager M where M.Sex='M')
                                                )";
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

            foreach (var item in usrList)
            {
                Console.WriteLine(item.ItemArray[0].ToString());
            }
        }

        private void Query2_Click(object sender, RoutedEventArgs e)
        {
            var result = new DataTable();
            List<DataRow> usrList;
            try
            {
                using (var sqlConnection = new SqlConnection(App.connectionString))
                {
                    sqlConnection.Open();

                    using (var command = sqlConnection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"SELECT [Sala ID], Etaj FROM Sala
                                                WHERE Capacitate IN (SELECT Capacitate FROM Sala WHERE [Sala ID] >= (SELECT Ocupata=0))";
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
            Console.WriteLine("Sala ID   Etaj");
            foreach (var item in usrList)
            {
                Console.Write("  ");
                Console.Write(item.ItemArray[0].ToString()+"           ");
                Console.WriteLine(item.ItemArray[1].ToString());
            }
        }

        private void Query3_Click(object sender, RoutedEventArgs e)
        {
            var result = new DataTable();
            List<DataRow> usrList;
            try
            {
                using (var sqlConnection = new SqlConnection(App.connectionString))
                {
                    sqlConnection.Open();

                    using (var command = sqlConnection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"SELECT R.Nume, R.Data
                                                FROM Rezervare R, Sala S
                                                WHERE R.Id NOT IN
		                                        (SELECT R.Id FROM Rezervare R, Rezervare F
	                                            WHERE R.Data NOT IN
		                                        (select r.Id FROM Rezervare R, Rezervare F Where
		                                        R.Manager_Id=F.Id))";
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

            foreach (var item in usrList)
            {

                string str;
                for (int i = 0; i < usrList.Count(); i++)
                {
                    str = item[0].ToString() + " ";
                    Console.WriteLine(str);
                }
            }
        }

        private void Query4_Click(object sender, RoutedEventArgs e)
        {
            var result = new DataTable();
            List<DataRow> usrList;
            try
            {
                using (var sqlConnection = new SqlConnection(App.connectionString))
                {
                    sqlConnection.Open();

                    using (var command = sqlConnection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"SELECT S.Etaj, S.Capacitate
                                                FROM Sala S
                                                WHERE S.[Sala ID] IN
		                                        (SELECT S.[Sala ID] FROM Sala R, Sala F
		                                        WHERE R.[Sala ID] IN 
		                                        (SELECT F.Etaj FROM Sala F))";
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

            Console.WriteLine("Etaj   Capacitate");
            foreach (var item in usrList)
            {
                Console.Write(" ");
                Console.Write(item.ItemArray[0].ToString() + "         ");
                Console.WriteLine(item.ItemArray[1].ToString());
            }
        }
    }
}
