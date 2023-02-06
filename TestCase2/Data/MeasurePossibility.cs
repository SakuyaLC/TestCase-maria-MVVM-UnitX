using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.Data
{
    public class MeasurePossibility : INotifyPropertyChanged
    {

        private int possibilities;

        public string City { get; set; }

        public DateTime Date { get; set; }

        public string Time { get; set; }

        public int Possibilities
        {
            get { return possibilities; }
            set
            {
                possibilities = value;
                OnPropertyChanged("Possibilities");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}

