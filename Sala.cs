using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Proiect_BD.Models
{
    public class Sala : INotifyPropertyChanged ////modelul unui clase de sala: constructor si proprietati de get si set pentru fiecare camp din tabel
    {
        private int sala_id;
        private int floor;
        private int capacity;
        private bool occupied;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Sala_Id
        {
            get { return sala_id; }
            set
            {
                sala_id = value;
                NotifyPropertyChanged("Sala_Id");
            }
        }
        public int Floor
        {
            get { return floor; }
            set
            {
                floor= value;
                NotifyPropertyChanged("Floor");
            }
        }
        public int Capacity
        {
            get { return capacity; }
            set
            {
                capacity= value;
                NotifyPropertyChanged("Capacity");
            }
        }
        public bool Occupied
        {
            get { return occupied; }
            set
            {
                occupied = value;
                NotifyPropertyChanged("Occupied");
            }
        }

        private void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public Sala()
        {

        }
        public Sala(int sala_id, int floor, int capacity, bool occupied)
        {
            this.sala_id =sala_id;
            this.floor = floor;
            this.capacity = capacity;
            this.occupied = occupied;
        }

    }
}
