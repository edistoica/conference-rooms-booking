using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Proiect_BD.Models
{
    public class Departament : INotifyPropertyChanged //modelul unui clase de departament: constructor si proprietati de get si set pentru fiecare camp din tabel
    {
        private int depart_id;
        private int manager_id;
        private string nume;
        private int nr_angajati;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Depart_Id
        {
            get { return depart_id; }
            set
            {
                depart_id = value;
                NotifyPropertyChanged("Depart_Id");
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
        public string Nume
        {
            get { return nume; }
            set
            {
                nume = value;
                NotifyPropertyChanged("Nume");
            }
        }    
        public int Nr_Angajati
        {
            get { return nr_angajati; }
            set
            {
                nr_angajati = value;
                NotifyPropertyChanged("Nr_Angajati");
            }
        }

        private void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public Departament()
        {

        }

        public Departament(int depart_id, int manager_id, string nume, int nr_angajati)
        {
            this.manager_id = manager_id;
            this.depart_id = depart_id;
            this.nume = nume;
            this.nr_angajati = nr_angajati;
        }
    }
}
