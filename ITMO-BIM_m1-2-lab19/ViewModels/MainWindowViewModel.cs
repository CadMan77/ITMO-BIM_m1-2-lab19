using ITMO_BIM_m1_2_lab19.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ITMO_BIM_m1_2_lab19.ViewModels
{
    class MainWindowViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //void OnPropertyChanged(string PropertyName = null)
        void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private double radius;
        public double Radius
        {
            get => radius;
            set
            {
                radius = value;
                OnPropertyChanged();
            }
        }

        private double circleLength;
        public double CircleLength
        {
            get => circleLength;
            set
            {
                circleLength = value;
                OnPropertyChanged();
            }
        }

        public ICommand LenCalcCommand { get; }
        private void OnLenCalcCommandExecute(object p)
        {
            CircleLength = Arif.LenCalc(Radius);
        }

        private bool CanLenCalcCommandExecuted(object p)
        {
            if (Radius > 0)
                return true;
            else
                return false;
        }

        public MainWindowViewModel()
        {
            LenCalcCommand = new RelayCommand(OnLenCalcCommandExecute, CanLenCalcCommandExecuted);
        }
    }
}
