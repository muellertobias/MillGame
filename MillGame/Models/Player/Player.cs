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
        public string Name { get; private set; }
        public FieldState Color { get; private set; }
        public List<Field> ControlledFields { get; private set; }

        public Player(string name, FieldState color)
        {
            Name = name;
            Color = color;
            ControlledFields = new List<Field>();
        }

        public event StateChangedEventHandler StateChanged;
    }
}
