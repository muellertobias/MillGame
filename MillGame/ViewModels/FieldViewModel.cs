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
    public class FieldViewModel : ViewModelBase
    {
        private FieldState _currentState;
        public FieldState CurrentState
        {
            get { return _currentState; }
            private set
            {
                if (_currentState != value)
                {
                    _currentState = value;
                    OnPropertyChanged();
                }
            }
        }

        private Field _model;

        public ICommand GameActionCommand { get; private set; }

        public FieldViewModel(Field model)
        {
            _model = model;
            _model.StateChanged += _model_StateChanged;
            GameActionCommand = new Command(o => GameAction());
        }

        private void _model_StateChanged(object sender, StateChangedEventArgs e)
        {
            CurrentState = _model.CurrentState;
        }

        private void GameAction()
        {
            _model.Move();
        }
    }
}
