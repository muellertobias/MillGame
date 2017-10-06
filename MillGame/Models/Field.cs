using MillGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillGame.Models
{
    public class Field : INotifyStateChanged
    {
        private Mill _board;

        public event StateChangedEventHandler StateChanged;

        public bool IsCorner { get { return Neighbors.Count == 2; } }

        private FieldState _currentState;
        public FieldState CurrentState
        {
            get { return _currentState; }
            set
            {
                if (_currentState != value)
                {
                    _currentState = value;
                    OnStateChanged();
                }
            }
        }

        public FieldState LastState { get; private set; }

        public List<Field> Neighbors { get; private set; }

        public Field(Mill board)
        {
            _board = board;
            Neighbors = new List<Field>();

            LastState = FieldState.Empty;
            _currentState = FieldState.Empty;
        }

        // Müssen 32 Verweise sein, da eine Mühle 32 Kanten besitzt!
        public void AddNeighbor(Field neighbor)
        {
            if (!Neighbors.Contains(neighbor))
            {
                Neighbors.Add(neighbor);
                neighbor.AddNeighbor(this);
            }
        }
        public void Move()
        {
            _board.Move(this);
        }

        public void MoveFinished(object sender, PlayersSwitchedEventArgs e)
        {
            LastState = CurrentState;
        }

        private void OnStateChanged()
        {
            StateChanged?.Invoke(this, new StateChangedEventArgs());
        }
    }
}
