using MillGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillGame.Models.Players
{
    public class Player : INotifyStateChanged
    {
        public event StateChangedEventHandler StateChanged;

        public string Name { get; private set; }
        public FieldState Color { get; private set; }
        public List<Field> ControlledFields { get; private set; }

        public Player(string name, FieldState color)
        {
            Name = name;
            Color = color;
            ControlledFields = new List<Field>();
        }

        public void Conquer(Field source, Field destination)
        {
            destination.CurrentState = Color;
            ControlledFields.Add(destination);
            _Lose(source);
            OnStateChanged();
        }
  
        public void Lose(Field lost)
        {
            _Lose(lost);
            OnStateChanged();
        }

        private void _Lose(Field lost)
        {
            if (lost != null)
            {
                lost.CurrentState = FieldState.Empty;
                ControlledFields.Remove(lost);
            }
        }

        public bool HasLost()
        {
            if (ControlledFields.Count == 0)
            {
                return true;
            }
            foreach (var field in ControlledFields)
            {
                if (field.Neighbors.Exists(f => f.CurrentState == FieldState.Empty))
                {
                    return false;
                }
            }
            return true;
        }

        private void OnStateChanged()
        {
            StateChanged?.Invoke(this, new StateChangedEventArgs());
        }

    }
}
