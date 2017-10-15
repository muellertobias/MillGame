using MillGame.Models;
using MillGame.Models.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillGame.Algorithms
{
    public static class MillLogic
    {
        public static bool FindMill(Player player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            List<Field> fields = player.ControlledFields.FindAll(f => !f.IsCorner);

            foreach (var field in fields)
            {
                if (IsMill(field))
                {
                    return true;
                }
            }

            return true;
        }

        public static bool IsMill(Field current)
        {
            if (current == null)
                throw new ArgumentNullException(nameof(current));

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

        public static bool IsCornerToCornerMill(Field current)
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
    }
}
