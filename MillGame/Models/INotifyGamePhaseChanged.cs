using MillGame.Models.GamePhases;
using System;

namespace MillGame.Models
{
    public class GamePhaseChangedEventArgs : EventArgs
    {
        public GamePhase Phase { get; private set; }

        public GamePhaseChangedEventArgs(GamePhase phase)
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