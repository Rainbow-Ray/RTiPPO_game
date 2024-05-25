using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game
{
    public class Game
    {
        public List<Player> playerList { get; private set; } = new List<Player>();
        public List<Round> roundList { get; private set; } = new List<Round>();
        public bool isTurnContinuous { get; private set; }
        private bool isPointsToWin { get; set; }
        private int numberOfBugsToWin { get; set; } = 1;
        private int numberOfPointsToWin { get; set; }
        private List<Player> winners = new List<Player>();

        private Dice dice { get; set; }
        public GameProcess gameProcess { get; private set; }

        public Game(bool isTurnContinuous, bool isPointsToWin, int numberOfPointsToWin) {
            this.isTurnContinuous = isTurnContinuous;
            this.isPointsToWin = isPointsToWin;
            if (isPointsToWin)
            {
                this.numberOfPointsToWin = numberOfPointsToWin;
            }
            else
            {
                this.numberOfBugsToWin = numberOfPointsToWin;
            }
            gameProcess = new GameProcess();
        }

        public void addPlayers(ListBox.ObjectCollection items)
        {
            var playerList = new List<Player>();
            foreach (var player in items)
            {
                var name = player.ToString();
                var nPlayer = new Player(name, playerList.Count);
                playerList.Add(nPlayer);
            }
            this.playerList = playerList;
        }

        public Dice createDice(string type)
        {
            dice = new Dice(type);
            return dice;
        }

        public bool IsLastPlayer(Player player)
        {
            return player.id >= playerList.Count - 1;
        }
        public Round getLastRound()
        {
            return roundList.Last();
        }


        public void StartGame()
        {
            startRound();
            startTurn(playerList.First());
        }
        private void startRound()
        {
            newRound();
            var eventsArgs = new GameEventArgs(playerList.First());
            gameProcess.startRound(eventsArgs);
        }

        private void startTurn(Player player)
        {
            var round = getLastRound();
            var turn = newTurn(player, round);
            var eventargs = new GameEventArgs(player);
            gameProcess.startTurn(eventargs);

        }

        private Round newRound()
        {
            var round = new Round();
            roundList.Add(round);

            foreach (var player in playerList)
            {
                player.createCurrentBug();
            }
            return round;
        }

        private Turn newTurn(Player player, Round round)
        {
            var turn = new Turn(player);
            round.addTurn(turn);
            return turn;
        }

        public List<Player> checkGameWinners()
        {
            foreach (var player in playerList)
            {
                if (isPointsToWin)
                {
                    if (player.score >= numberOfPointsToWin)
                    {
                        winners.Add(player);
                    }
                }
                else
                {
                    if (player.numberOfBugs >= numberOfBugsToWin)
                    {
                        winners.Add(player);
                    }
                }
            }
            return winners;
        }

        public List<Player> checkRoundWinners()
        {
            var winners = new List<Player>();
            foreach (var player in playerList)
            {
                if (player.isBugComplete())
                {
                    winners.Add(player);
                }
            }
            return winners;
        }

        public string formatPlayersScore()
        {
            StringBuilder a = new StringBuilder();
            a.AppendLine($"{"Игрок",-30} {"Очки",5}");
            foreach (var player in playerList)
            {
                a.AppendLine($"{player.name,-30} {player.score,5}");
                a.AppendLine($"");
            }
            return a.ToString();
        }

        public void throwDice()
        {
            var round = getLastRound();
            var turn = round.getLastTurn();
            turn.rollDice(dice);
            var isPartAdded = turn.addPart();
            gameProcess.throwDice(turn, isPartAdded);

            nextMove(turn, isPartAdded);
        }

        private void nextMove(Turn turn, bool isPartAdded)
        {
            if (!isTurnContinuous || (!isPartAdded && isTurnContinuous))
            {
                var result = isPartAdded ? "Часть подошла!" : "Часть не подходит.";
                result += "\nПередаем ход следующему игроку";
                var eventArgs = new GameEventArgs(result);
                gameProcess.nextMove(eventArgs);
                nextPlayer(turn.currentPlayer);
            }
            else
            {
                var result = "Часть подошла! \nПередаем ход следующему игроку";
                var eventArgs = new GameEventArgs(result);
                gameProcess.nextMove(eventArgs);

                startTurn(turn.currentPlayer);
            }
        }

        private void nextPlayer(Player player)
        {
            var firstPlayer = playerList.First();
            if (IsLastPlayer(player))
            {
                var gameWinners = checkGameWinners();
                var roundWinners = checkRoundWinners();
                //Два игрока могут выиграть, например при игре до 5 очков
                //var roundWinners = gameProperties.playerList;
                //gameProperties.playerList[0].score = 5;
                //gameProperties.playerList[1].score = 5;

                if (gameWinners.Count > 0)
                {
                    var eventsArgs = new GameEventArgs(gameWinners, formatPlayersScore());
                    gameProcess.finishGame(eventsArgs);
                }
                else if (roundWinners.Count > 0)
                {
                        var eventargs = new GameEventArgs(roundWinners, formatPlayersScore());
                        gameProcess.finishRound(eventargs);
                        startRound();
                        startTurn(firstPlayer);
                }
                else
                {
                    startTurn(firstPlayer);
                }
            }
            else
            {
                var nextPlayer = playerList[player.id + 1];
                startTurn(nextPlayer);
            }
        }
    }
}
