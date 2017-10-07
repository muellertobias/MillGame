using MillGame.Models.Players;
using MillGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillGame.Models.GamePhases
{
    public class SelectionPhase : GamePhase
    {
        private Field selectedField;

        public override string Name => "Select";

        public override bool NextPlayer()
        {
            return false;
        }

        public override bool Move(Field currentField, Player player, Player enemy)
        {
            if (currentField.CurrentState == player.Color 
                && (player.ControlledFields.Count <= 3 || currentField.Neighbors.Exists(f => f.CurrentState == FieldState.Empty)))
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
