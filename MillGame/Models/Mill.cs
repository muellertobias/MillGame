﻿using MillGame.Models.GamePhases;
using MillGame.Models.Players;
using MillGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillGame.Models
{
    public class Mill
    {
        private GamePhase currentPhase;

        public Dictionary<int, Field> Fields { get; private set; }

        public Player[] Players { get; private set; }
        private int indexCurrentPlayer;

        public Mill()
        {
            currentPhase = new SettingPhase();

            Players = new Player[2];
            Players[0] = new Player("Alice", FieldState.Red);
            Players[1] = new Player("Bob", FieldState.Blue);
            indexCurrentPlayer = 0;

            SetupFields();
        }

        public void Move(Field activeField)
        {
            if (currentPhase.Move(activeField, Players[indexCurrentPlayer], Fields.Values.ToList()))
            {
                NextPlayer(currentPhase.NextPlayer());
                currentPhase = currentPhase.NextPhase();
            }
        }

        private void NextPlayer(bool moveFinished)
        {
            if (moveFinished)
            {
                indexCurrentPlayer = (indexCurrentPlayer + 1) % 2;
            }
        }

        private void SetupFields()
        {
            Fields = new Dictionary<int, Field>();
            for (int i = 0; i < 24; i++)
            {
                Fields.Add(i, new Field(this));
            }

            Fields[0].AddNeighbor(Fields[1]);
            Fields[0].AddNeighbor(Fields[9]);
            Fields[1].AddNeighbor(Fields[2]);
            Fields[1].AddNeighbor(Fields[4]);
            Fields[2].AddNeighbor(Fields[14]);
            Fields[4].AddNeighbor(Fields[3]);
            Fields[4].AddNeighbor(Fields[7]);
            Fields[4].AddNeighbor(Fields[5]);
            Fields[3].AddNeighbor(Fields[10]);
            Fields[5].AddNeighbor(Fields[13]);
            Fields[9].AddNeighbor(Fields[10]);
            Fields[9].AddNeighbor(Fields[21]);
            Fields[10].AddNeighbor(Fields[11]);
            Fields[10].AddNeighbor(Fields[18]);
            Fields[11].AddNeighbor(Fields[6]);
            Fields[11].AddNeighbor(Fields[15]);
            Fields[6].AddNeighbor(Fields[7]);
            Fields[7].AddNeighbor(Fields[8]);
            Fields[8].AddNeighbor(Fields[12]);
            Fields[12].AddNeighbor(Fields[13]);
            Fields[12].AddNeighbor(Fields[17]);
            Fields[13].AddNeighbor(Fields[14]);
            Fields[13].AddNeighbor(Fields[20]);
            Fields[14].AddNeighbor(Fields[23]);
            Fields[15].AddNeighbor(Fields[16]);
            Fields[16].AddNeighbor(Fields[17]);
            Fields[16].AddNeighbor(Fields[19]);
            Fields[18].AddNeighbor(Fields[19]);
            Fields[19].AddNeighbor(Fields[20]);
            Fields[19].AddNeighbor(Fields[22]);
            Fields[21].AddNeighbor(Fields[22]);
            Fields[22].AddNeighbor(Fields[23]);
        }
    }
}
