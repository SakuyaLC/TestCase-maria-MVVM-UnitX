using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestCase.Data
{
    public class MeasureOrder : INotifyPropertyChanged
    {
        private DateTime? measure_date;
        private string measure_time;

        public int Measure_id { get; set; }

        public string Client_fio { get; set; }

        public string Client_address { get; set; }

        public string Client_phoneNumber { get; set; }

        public DateTime? Measure_date
        {
            get { return measure_date; }
            set
            {
                measure_date = value;
                OnPropertyChanged("Measure_date");
            }
        }

        public string Measure_time
        {
            get { return measure_time; }
            set
            {
                measure_time = value;
                OnPropertyChanged("Measure_time");
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
