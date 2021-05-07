using System.ComponentModel;


namespace Maze_Knight.ViewModels
{
    //Base ViewModel with INotifyPropertyChanged implementation to be used by all ViewModels
    public class BaseViewModel : INotifyPropertyChanged
    {

       
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
