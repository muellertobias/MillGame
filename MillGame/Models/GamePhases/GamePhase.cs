using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MillGame.Models.Players;

namespace MillGame.Models.GamePhases
{
    abstract class GamePhase
    {
        public abstract string Name { get; }
        public abstract bool Move(Field currentField, Player player, Player enemy);
        public abstract bool NextPlayer();
        public abstract GamePhase NextPhase();
    }
}
