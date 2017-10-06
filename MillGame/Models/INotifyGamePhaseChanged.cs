using System;

namespace MillGame.Models
{
    public class GamePhaseChangedEventArgs : EventArgs
    {
        public string Phase { get; private set; }

        public GamePhaseChangedEventArgs(string phase)
        {
            Phase = phase;
        }
    }

    public delegate void GamePhaseChangedEventHandler(object sender, GamePhaseChangedEventArgs e);

    public interface INotifyGamePhaseChanged
    {
        event GamePhaseChangedEventHandler GamePhaseChanged;
    }
}