using MillGame.Models.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillGame.Models.GamePhases
{
    class SelectionPhase : GamePhase
    {
        private Field selectedField;

        public override bool NextPlayer()
        {
            return false;
        }

        public override bool Move(Field currentField, Player player, List<Field> fields)
        {
            if (currentField.CurrentState == player.Color)
            {
                selectedField = currentField;
                return true;
            }
            return false;
        }

        public override GamePhase NextPhase()
        {
            if (selectedField != null)
            {
                return new ConquerPhase(selectedField);
            }

            return this;
        }
    }
}
