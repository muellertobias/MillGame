using MillGame.Models;
using MillGame.Utilities;
using MillGame.Utilities.MVVM;
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
        public FieldState CurrentState
        {
            get { return _model.CurrentState; }
        }

        private Field _model;

        public ICommand GameActionCommand { get; private set; }

        public FieldViewModel(Field model)
        {
            _model = model;
            GameActionCommand = new Command(o => GameAction());
        }

        private void GameAction()
        {
            _model.Move();
            OnPropertyChanged("CurrentState");
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
