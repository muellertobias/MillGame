using MillGame.Models.Players;
using MillGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillGame.Models.GamePhases
{
    class SettingPhase : GamePhase
    {
        private int Counter;
        private const int MAX_Counter = 18;

        public override string Name => "Set";

        public SettingPhase()
        {
            Counter = 0;
        }

        public override bool NextPlayer()
        {
            return true;
        }

        public override GamePhase NextPhase()
        {
            if (Counter >= MAX_Counter)
            {
                return new SelectionPhase();
            }
            return this;
        }

        public override bool Move(Field currentField, Player player, Player enemy)
        {
            if (currentField.CurrentState == FieldState.Empty)
            {
                Counter++;
                currentField.CurrentState = player.Color;
                player.Conquer(null, currentField);
                //player.ControlledFields.Add(currentField);
                return true;
            }
            return false;
        }
    }
}
