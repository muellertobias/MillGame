﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MillGame.Models.Players;

namespace MillGame.Models.GamePhases
{
    abstract class GamePhase
    {
        public abstract bool Move(Field currentField, Player player, List<Field> fields);
        public abstract bool NextPlayer();
        public abstract GamePhase NextPhase();
    }
}
