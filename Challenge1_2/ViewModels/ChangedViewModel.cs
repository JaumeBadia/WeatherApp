using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Challenge1_2.Models
{

    public class ChangedViewModel : INotifyPropertyChanged
    {
        public int temp { get; private set; }
        public ICommand TempChanged { get; private set; }

        public ChangedViewModel ()
        {
            TempChanged = new Command<Int16> (CalculateTemp);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void CalculateTemp (Int16 value)
        {
            temp = (value - 32) * 5 / 6;

            OnPropertyChanged("ToCelcius");
        }

        protected virtual void OnPropertyChanged(string v) => throw new NotImplementedException();

    }
}
