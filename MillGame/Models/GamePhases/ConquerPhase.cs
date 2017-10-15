using MillGame.Models.Players;
using MillGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillGame.Models.GamePhases
{
    public class ConquerPhase : GamePhase
    {
        private Field selectedField;
        private bool millBuilded;

        public override string Name => "Conquer";

        public ConquerPhase(Field selectedField)
        {
            this.selectedField = selectedField;
            millBuilded = false;
        }

        public override bool NextPlayer()
        {
            if (!millBuilded && selectedField.CurrentState == FieldState.Empty)
            {
                millBuilded = false;
                return true;
            }
            return false;
        }

        public override bool Move(Field currentField, Player player, Player enemy)
        {
            if (currentField.CurrentState == FieldState.Empty 
                && (selectedField.Neighbors.Contains(currentField) || player.ControlledFields.Count <= 3))
            {
                player.Conquer(selectedField, currentField);

                //selectedField.CurrentState = FieldState.Empty;
                //currentField.CurrentState = player.Color;

                millBuilded = Algorithms.MillLogic.FindMill(player);

                return true;
            }
            return false;
        }

        public override GamePhase NextPhase()
        {
            if (selectedField.CurrentState != FieldState.Empty)
            {
                return this;
            }
            else
            {
                if (millBuilded)
                {
                    return new EliminationPhase();
                }
                else
                {
                    return new SelectionPhase();
                }
            }
        }
    }
}
