using MillGame.Models.Players;
using MillGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillGame.Models.GamePhases
{
    class MovePhase : GamePhase
    {
        private GamePhase subPhase;

        [Obsolete]
        public MovePhase()
        {
            subPhase = new SelectionPhase();
        }

        public override bool NextPlayer()
        {
            return subPhase.NextPlayer();
        }

        public override GamePhase NextPhase()
        {
            subPhase = subPhase.NextPhase();
            return this;

            // kriterium zum wechsel zu EndPhase => p1.Fields == 3 || p2.Fields == 3
        }

        public override bool Move(Field currentField, Player currentPlayer, List<Field> fields)
        {
            return subPhase.Move(currentField, currentPlayer, fields);
        }
    }
}
