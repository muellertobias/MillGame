using MillGame.Models.Players;
using MillGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillGame.Models
{
    public class GameStatus : INotifyStateChanged
    {
        public event StateChangedEventHandler StateChanged;

        public Player[] Players { get; private set; }

        private int indexCurrentPlayer;

        public Player CurrentPlayer
        {
            get
            {
                return Players[indexCurrentPlayer];
            }
        }

        public GameStatus()
        {
            Players = new Player[2];
            Players[0] = new Player("Alice", FieldState.Red);
            Players[1] = new Player("Bob", FieldState.Blue);
            indexCurrentPlayer = 0;
        }

        public void NextPlayer(bool moveFinished)
        {
            if (moveFinished)
            {
                indexCurrentPlayer = (indexCurrentPlayer + 1) % 2;
                StateChanged?.Invoke(this, new StateChangedEventArgs());
            }
        }
    }
}
