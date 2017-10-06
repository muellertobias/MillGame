using MillGame.Models.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillGame.Models.GamePhases
{
    class EndPhase : MovePhase
    {
        public EndPhase()
        {

        }

        public override bool NextPlayer()
        {
            return base.NextPlayer();
        }

        public override GamePhase NextPhase()
        {
            return base.NextPhase();
        }

        public override bool Move(Field currentField, Player currentPlayer, List<Field> fields)
        {
            return base.Move(currentField, currentPlayer, fields);
        }
    }
}
