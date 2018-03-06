using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace Proiect_BD
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application //clasa pentru varaibile statice care sa ne ajute cand dorim sa luam un camp popular care se modifica(vezi data, timp, id_sala...)
    {
        public static string connectionString= @"Data Source=LENOVO-PC\SQLEXPRESS;Initial Catalog=Conference Rooms;Integrated Security=True";  //string-ul de login pentru server
        public static int LogInId { get; set; }
        public static DateTime date_time;
        public static int hour_time;
        public static int IdSala;
    }
}
