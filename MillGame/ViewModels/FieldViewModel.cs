using MillGame.Models;
using MillGame.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MillGame.ViewModels
{
    public class FieldViewModel : INotifyPropertyChanged
    {
        public Field Model { get; private set; }

        public ICommand GameActionCommand { get; private set; }

        public FieldViewModel()
        {
            Model = new Field();
            GameActionCommand = new Command(GameAction);
        }

        // Müssen 32 Verweise sein, da eine Mühle 32 Kanten besitzt!
        public void AddNeighbor(FieldViewModel neighbor)
        {
            Model.AddNeighbor(neighbor.Model);
        }

        private void GameAction(object parameter)
        {

        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion INotifyPropertyChanged
    }
}
