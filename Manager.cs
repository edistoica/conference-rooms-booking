using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Proiect_BD.Models
{
    public class Manager: INotifyPropertyChanged ////modelul unui clase de manager: constructor si proprietati de get si set pentru fiecare camp din tabel
    {
        private int manager_id;
        private string nume;
        private string prenume;
        private char sex;
        private string cnp;
        private string telefon;
        private DateTime data_angajare;

        public event PropertyChangedEventHandler PropertyChanged;

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
        public string Prenume
        {
            get { return prenume; }
            set
            {
                prenume = value;
                NotifyPropertyChanged("Prenume");
            }
        }
        public char Sex
        {
            get { return sex; }
            set
            {
                sex = value;
                NotifyPropertyChanged("Sex");
            }
        }
        public string Cnp
        {
            get { return cnp; }
            set
            {
                cnp = value;
                NotifyPropertyChanged("Cnp");
            }
        }
        public string Telefon
        {
            get { return telefon; }
            set
            {
                telefon = value;
                NotifyPropertyChanged("Telefon");
            }
        }
        public DateTime Data_Angajare
        {
            get { return data_angajare; }
            set
            {
                data_angajare = value;
                NotifyPropertyChanged("Data_Angajare");
            }
        }

        private void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public Manager()
        {

        }

        public Manager(int manager_id, string nume, string prenume, char sex, string cnp, string telefon,DateTime data_angajare)
        {
            this.manager_id = manager_id;
            this.nume = nume;
            this.prenume = prenume;
            this.sex = sex;
            this.cnp = cnp;
            this.telefon = telefon;
            this.data_angajare = data_angajare;
        }
    }
}
