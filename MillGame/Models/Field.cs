using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillGame.Models
{
    public class Field
    {
        public List<Field> Neighbors { get; private set; }

        public Field()
        {
            Neighbors = new List<Field>();
        }

        public void AddNeighbor(Field neighbor)
        {
            if (!Neighbors.Contains(neighbor))
            {
                Neighbors.Add(neighbor);
                neighbor.AddNeighbor(this);
            }
        }
    }
}
