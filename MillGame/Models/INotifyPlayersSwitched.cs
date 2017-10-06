using MillGame.Models.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillGame.Models
{
    public class PlayersSwitchedEventArgs : EventArgs
    {
        public Player NewPlayer { get; private set; }
        public Player OldPlayer { get; private set; }

        public PlayersSwitchedEventArgs(Player newPlayer, Player oldPlayer)
        {
            NewPlayer = newPlayer;
            OldPlayer = oldPlayer;
        }
    }

    public delegate void PlayersSwitchedEventHandler(object sender, PlayersSwitchedEventArgs e);

    public interface INotifyPlayersSwitched
    {
        event PlayersSwitchedEventHandler PlayersSwitched;
    }
}
