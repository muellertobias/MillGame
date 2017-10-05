﻿using MillGame.Utilities;
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

        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }
        public Player CurrentPlayer { get; private set; }

        public Mill()
        {
            currentPhase = new SettingPhase();
            Player1 = new Player() { Name = "Alice", Color = FieldState.Player1 };
            Player2 = new Player() { Name = "Bob", Color = FieldState.Player2 };
            CurrentPlayer = Player1;

            Fields = new Dictionary<int, Field>();
            for (int i = 0; i < 24; i++)
            {
                Fields.Add(i, new Field(this));
            }
            SetupNeighborhoods();
        }

        public void Move(Field activeField)
        {
            if (currentPhase.Move(CurrentPlayer, activeField))
            {
                currentPhase = currentPhase.NextPhase();
                SetNextPlayer(currentPhase.IsMoveFinished());
            }
        }

        private void SetNextPlayer(bool moveFinished)
        {
            if (moveFinished) // TODO Statemachine für die Spieler
            {
                if (CurrentPlayer == Player1)
                {
                    CurrentPlayer = Player2;
                }
                else
                {
                    CurrentPlayer = Player1;
                }
            }
        }

        private void SetupNeighborhoods()
        {
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

        abstract class GamePhase
        {
            public abstract bool Move(Player currentPlayer, Field currentField);

            public abstract bool IsMoveFinished();
            public abstract GamePhase NextPhase();
        }

        class SettingPhase : GamePhase
        {
            private int Counter;
            private const int MAX_Counter = 18;

            public SettingPhase()
            {
                Counter = 0;
            }

            public override bool IsMoveFinished()
            {
                return true;
            }

            public override GamePhase NextPhase()
            {
                if (Counter >= MAX_Counter)
                {
                    return new MovePhase();
                }
                return this;
            }

            public override bool Move(Player currentPlayer, Field currentField)
            {
                if (currentField.CurrentState == FieldState.Empty)
                {
                    Counter++;
                    currentField.CurrentState = currentPlayer.Color;
                    return true;
                }
                return false;
            }
        }

        class MovePhase : GamePhase
        {
            public override bool IsMoveFinished()
            {
                throw new NotImplementedException();
            }

            public override GamePhase NextPhase()
            {
                throw new NotImplementedException();
            }

            public override bool Move(Player currentPlayer, Field currentField)
            {
                throw new NotImplementedException();
            }
        }
        class EndPhase : GamePhase
        {
            public override bool IsMoveFinished()
            {
                throw new NotImplementedException();
            }

            public override GamePhase NextPhase()
            {
                throw new NotImplementedException();
            }

            public override bool Move(Player currentPlayer, Field currentField)
            {
                throw new NotImplementedException();
            }
        }
    }
}
