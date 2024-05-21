using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace game
{
    public class GameProcess
    {
        public event EventHandler<GameEventArgs> WonGame;
        public event EventHandler<GameEventArgs> WonRound;
        public event EventHandler<GameEventArgs> NeedNewRound;
        public event EventHandler<GameEventArgs> NeedNewTurn;

        public event EventHandler<GameEventArgs> LabelChange;
        public event EventHandler<GameEventArgs> LabelUpdate;
        public event EventHandler<GameEventArgs> DrawBug;
        public event EventHandler<GameEventArgs> Wait;

        public GameProcess() {
        }

        public void RaiseEvent(EventHandler<GameEventArgs> Event, GameEventArgs eventArgs) {
            EventHandler<GameEventArgs> eventHandler = Event;
            if (Event!= null)
            {
                Event(this, eventArgs);
            }
        }
        public void startRound(GameEventArgs e)
        {
            RaiseEvent(NeedNewRound, e);
        }
        public void startTurn(GameEventArgs e)
        {
            RaiseEvent(NeedNewTurn, e);
        }
        public bool throwDice(Turn turn, bool isPartAdded)
        {
            var result = turn.rollResult;
            RaiseEvent(LabelChange, new GameEventArgs(result.getResultName()));
            RaiseEvent(LabelUpdate, null);

            if (isPartAdded)
            {
                RaiseEvent(DrawBug, new GameEventArgs(turn.currentPlayer, result));
            }
            RaiseEvent(Wait, null);

            return isPartAdded;
        }
        public void finishRound(GameEventArgs e)
        {
            RaiseEvent(WonRound, e);
        }
        public void finishGame(GameEventArgs e)
        {
            RaiseEvent(WonGame, e);
        }
    }
}


/*
public void nextPlayer(Player player)
{
    var firstPlayer = gameProperties.playerList[0];
    if (gameProperties.IsLastPlayer(player))
    {
        var roundWinners = gameProperties.checkRoundWinners();
        //Два игрока могут выиграть, например при игре до 5 очков
        //var roundWinners = gameProperties.playerList;
        //gameProperties.playerList[0].score = 5;
        //gameProperties.playerList[1].score = 5;

        if (roundWinners.Count > 0)
        {
            var gameWinners = gameProperties.getWinners();
            if (gameWinners.Count > 0)
            {
            }
            else
            {
                RaiseEvent(WonRound, new GameEventArgs(roundWinners, "Выигран раунд"));
                startRound();
                startTurn(firstPlayer);
            }
        }
        else
        {
            startTurn(firstPlayer);
        }
    }
    else
    {
        var nextPlayer = gameProperties.playerList[player.id + 1];
        startTurn(nextPlayer);
    }
}
*/
