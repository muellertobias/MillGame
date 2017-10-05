using MillGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillGame.Models
{
    public class Field
    {
        private Mill _board;
        public bool IsCorner { get { return Neighbors.Count == 2; } }
        public FieldState CurrentState { get; set; } // TODO Notify ViewModel!
        public List<Field> Neighbors { get; private set; }

        public Field(Mill board)
        {
            _board = board;
            Neighbors = new List<Field>();
        }

        // Müssen 32 Verweise sein, da eine Mühle 32 Kanten besitzt!
        public void AddNeighbor(Field neighbor)
        {
            if (!Neighbors.Contains(neighbor))
            {
                Neighbors.Add(neighbor);
                neighbor.AddNeighbor(this);
            }
        }
        public void Move()
        {
            _board.Move(this);
        }
    }
}
