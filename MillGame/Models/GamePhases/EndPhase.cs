using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MillGame.Models.Players;

namespace MillGame.Models.GamePhases
{
    public class EndPhase : GamePhase
    {
        private Player winner;
        public override string Name => string.Format("{0} has won!", winner.Name);

        public EndPhase(Player winner)
        {
            this.winner = winner;
        }

        public override bool Move(Field currentField, Player player, Player enemy)
        {
            return false;
        }

        public override GamePhase NextPhase()
        {
            return this;
        }

        public override bool NextPlayer()
        {
            return false;
        }
    }
}
