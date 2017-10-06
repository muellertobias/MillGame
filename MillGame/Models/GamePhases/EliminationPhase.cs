using MillGame.Models.Players;
using MillGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillGame.Models.GamePhases
{
    class EliminationPhase : GamePhase
    {
        public override bool NextPlayer()
        {
            return true;
        }

        public override bool Move(Field currentField, Player player, List<Field> fields)
        {
            if (currentField.CurrentState != player.Color && currentField.CurrentState != FieldState.Empty)
            {
                currentField.CurrentState = FieldState.Empty;
                return true;
            }
            return false;
        }

        public override GamePhase NextPhase()
        {
            return new SelectionPhase();
        }
    }
}
