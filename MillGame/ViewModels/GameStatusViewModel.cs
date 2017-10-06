using MillGame.Models;
using MillGame.Utilities;
using MillGame.Utilities.MVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillGame.ViewModels
{
    public class GameStatusViewModel : ViewModelBase
    {
        private string _currentPhase;
        public string CurrentPhase
        {
            get { return _currentPhase; }
            private set
            {
                if (_currentPhase != value)
                {
                    _currentPhase = value;
                    OnPropertyChanged();
                }
            }
        }
        public List<PlayerViewModel> PlayerViewModels { get; private set; }

        private FieldState _activePlayerColor;
        public FieldState ActivePlayerColor
        {
            get { return _activePlayerColor; }
            private set
            {
                if (_activePlayerColor != value)
                {
                    _activePlayerColor = value;
                    OnPropertyChanged();
                }
            }
        }

        private GameStatus _model;

        public GameStatusViewModel(GameStatus model)
        {
            _model = model;
            _model.PlayersSwitched += (s, e) => ActivePlayerColor = e.NewPlayer.Color;
            _model.GamePhaseChanged += (s, e) => CurrentPhase = e.Phase;

            PlayerViewModels = new List<PlayerViewModel>();
            foreach (var player in _model.Players)
            {
                PlayerViewModels.Add(new PlayerViewModel(player));
            }

            ActivePlayerColor = _model.ActivePlayer.Color;
        }
    }
}
