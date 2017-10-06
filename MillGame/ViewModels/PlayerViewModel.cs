using MillGame.Utilities.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MillGame.Models.Players;
using MillGame.Utilities;

namespace MillGame.ViewModels
{
    public class PlayerViewModel : ViewModelBase
    {
        public string Name
        {
            get { return _model.Name; }
        }

        public FieldState Color
        {
            get { return _model.Color; }
        }

        private int _fieldCount;
        public int FieldCount
        {
            get { return _fieldCount; }
            private set
            {
                if (_fieldCount != value)
                {
                    _fieldCount = value;
                    OnPropertyChanged();
                }
            }
        }

        private Player _model;

        public PlayerViewModel(Player model)
        {
            this._model = model;
            _model.StateChanged += (s, e) => FieldCount = _model.ControlledFields.Count;
        }
    }
}
