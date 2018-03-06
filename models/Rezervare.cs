using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Proiect_BD.Models
{
    public class Rezervare: INotifyPropertyChanged ////modelul unui clase de rezzervare: constructor si proprietati de get si set pentru fiecare camp din tabel
    {
        private int rezervare_id;
        private int sala_id;
        private int manager_id;
        private string nume_sala;
        private DateTime date;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Rezervare_Id
        {
            get { return rezervare_id; }
            set
            {
                rezervare_id = value;
                NotifyPropertyChanged("Rezervare_Id");
            }
        }
        public int Sala_Id
        {
            get { return sala_id; }
            set
            {
                sala_id = value;
                NotifyPropertyChanged("Sedinta_Id");
            }
        }
        public int Manager_Id
        {
            get { return manager_id; }
            set
            {
                manager_id = value;
                NotifyPropertyChanged("Manager_Id");
            }
        }
        public string Nume_Sala
        {
            get { return nume_sala; }
            set
            {
                nume_sala = value;
                NotifyPropertyChanged("Nume_Sala");
            }
        }
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                NotifyPropertyChanged("Date");
            }
        }


        private void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public Rezervare()
        {

        }

        public Rezervare(int rezervare_id, int sala_id,int manager_id, string nume_sala,DateTime date)
        {
            this.rezervare_id = rezervare_id;
            this.sala_id = sala_id;
            this.manager_id = manager_id;
            this.nume_sala = nume_sala;
            this.date = date;
        }
    }
}
