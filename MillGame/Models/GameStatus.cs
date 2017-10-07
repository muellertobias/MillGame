using MillGame.Models.Players;
using MillGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MillGame.Models.GamePhases;

namespace MillGame.Models
{
    public class GameStatus : INotifyPlayersSwitched, INotifyGamePhaseChanged
    {
        public event PlayersSwitchedEventHandler PlayersSwitched;
        public event GamePhaseChangedEventHandler GamePhaseChanged;

        public Player[] Players { get; private set; }

        private int indexCurrentPlayer;

        public Player ActivePlayer
        {
            get
            {
                return Players[indexCurrentPlayer];
            }
        }

        public Player CurrentEnemy
        {
            get
            {
                return Players[(indexCurrentPlayer + 1) % 2];
            }
        }

        public GameStatus()
        {
            Players = new Player[2];
            Players[0] = new Player("Alice", FieldState.Red);
            Players[1] = new Player("Bob", FieldState.Blue);
            indexCurrentPlayer = 0;
        }

        public void Publish(GamePhase currentPhase)
        {
            GamePhaseChanged?.Invoke(this, new GamePhaseChangedEventArgs(currentPhase));
        }

        public void NextPlayer(bool moveFinished)
        {
            if (moveFinished)
            {
                var oldPlayer = Players[indexCurrentPlayer];
                indexCurrentPlayer = (indexCurrentPlayer + 1) % 2;
                var newPlayer = Players[indexCurrentPlayer];

                PlayersSwitched?.Invoke(this, new PlayersSwitchedEventArgs(newPlayer, oldPlayer));
            }
        }
    }
}
