using MillGame.Models.Players;
using MillGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillGame.Models.GamePhases
{
    class ConquerPhase : GamePhase
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

                selectedField.CurrentState = FieldState.Empty;
                currentField.CurrentState = player.Color;

                FindMill(player);

                return true;
            }
            return false;
        }

        private bool FindMill(Player player)
        {
            List<Field> fields = player.ControlledFields.FindAll(f => !f.IsCorner);

            foreach (var field in fields)
            {
                if (_isMill(field))
                {
                    millBuilded = true;
                    return true;
                }
            }

            return true;
        }

        private bool _isMill(Field current)
        {
            if (current.IsCorner)
                throw new ArgumentException("Current Field darf keine Ecke sein!");

            if (current.Neighbors.Count == 3)
            {
                return IsCornerToCornerMill(current);
            }

            else if (current.Neighbors.Count == 4)
            {
                bool isCornerToCornerMill = IsCornerToCornerMill(current);
                if (isCornerToCornerMill)
                    return true;

                var nonCornerFields = current.Neighbors.FindAll(f => !f.IsCorner && f.CurrentState == current.CurrentState);
                if (nonCornerFields.Count == 2)
                {
                    return nonCornerFields[0].LastState != nonCornerFields[0].CurrentState
                        || nonCornerFields[1].LastState != nonCornerFields[0].CurrentState
                        || current.LastState != current.CurrentState;
                }
            }

            return false;
        }

        private bool IsCornerToCornerMill(Field current)
        {
            var cornerFields = current.Neighbors.FindAll(f => f.IsCorner && f.CurrentState == current.CurrentState);
            if (cornerFields.Count == 2)
            {
                return cornerFields[0].LastState != cornerFields[0].CurrentState
                    || cornerFields[1].LastState != cornerFields[0].CurrentState
                    || current.LastState != current.CurrentState;
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
