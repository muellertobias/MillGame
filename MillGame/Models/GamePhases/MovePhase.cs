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

        public MovePhase()
        {
            subPhase = new SelectionPhase();
        }

        public override bool IsMoveFinished()
        {
            return subPhase.IsMoveFinished();
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

        class SelectionPhase : GamePhase
        {
            private Field selectedField;

            public override bool IsMoveFinished()
            {
                return false;
            }

            public override bool Move(Field currentField, Player player, List<Field> fields)
            {
                if (currentField.CurrentState == player.Color)
                {
                    selectedField = currentField;
                    return true;
                }
                return false;
            }

            public override GamePhase NextPhase()
            {
                if (selectedField != null)
                {
                    return new ConquerPhase(selectedField);
                }

                return this;
            }
        }

        class ConquerPhase : GamePhase
        {
            private Field selectedField;
            private bool millBuilded;
            public ConquerPhase(Field selectedField)
            {
                this.selectedField = selectedField;
                millBuilded = false;
            }

            public override bool IsMoveFinished()
            {
                return !millBuilded && selectedField.CurrentState == FieldState.Empty;
            }

            public override bool Move(Field currentField, Player player, List<Field> fields)
            {
                if (currentField.CurrentState == FieldState.Empty && selectedField.Neighbors.Contains(currentField))
                {
                    player.ControlledFields.Remove(selectedField);
                    player.ControlledFields.Add(currentField);
                    selectedField.CurrentState = FieldState.Empty;
                    currentField.CurrentState = player.Color;

                    // Prüfe hier auf Mühlen!

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

        class EliminationPhase : GamePhase
        {
            public override bool IsMoveFinished()
            {
                throw new NotImplementedException();
            }

            public override bool Move(Field currentField, Player player, List<Field> fields)
            {
                throw new NotImplementedException();
            }

            public override GamePhase NextPhase()
            {
                throw new NotImplementedException();
            }
        }
    }
}
