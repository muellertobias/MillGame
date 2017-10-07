using MillGame.Models.Players;
using MillGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillGame.Models.GamePhases
{
    public class EliminationPhase : GamePhase
    {
        public override string Name => "Eliminate";
        private Player winner;

        public override bool NextPlayer()
        {
            return winner == null;
        }

        public override bool Move(Field currentField, Player player, Player enemy)
        {
            if (currentField.CurrentState == enemy.Color)
            {
                enemy.Lose(currentField);
                if (enemy.HasLostGame())
                {
                    winner = player;
                }
                return true;
            }
            return false;
        }

        public override GamePhase NextPhase()
        {
            if (winner != null)
            {
                return new EndPhase(winner);
            }
            else
            {
                return new SelectionPhase();
            }
        }
    }
}
