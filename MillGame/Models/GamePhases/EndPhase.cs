using MillGame.Models.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillGame.Models.GamePhases
{
    class EndPhase : GamePhase
    {
        public override bool IsMoveFinished()
        {
            throw new NotImplementedException();
        }

        public override GamePhase NextPhase()
        {
            throw new NotImplementedException();
        }

        public override bool Move(Field currentField, Player currentPlayer, List<Field> fields)
        {
            throw new NotImplementedException();
        }
    }
}
