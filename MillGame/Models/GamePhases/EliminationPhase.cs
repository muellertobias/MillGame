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
        public override string Name => "Eliminate";

        public override bool NextPlayer()
        {
            return true;
        }

        public override bool Move(Field currentField, Player player, Player enemy)
        {
            if (currentField.CurrentState == enemy.Color)
            {
                enemy.Lose(currentField);
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
