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
        private int numberOfBugsToWin { get; set; }
        private int numberOfPointsToWin { get; set; }
        private List<Player> winners = new List<Player>();

        private Dice dice { get; set; }
        private GameProcess gameProcess { get; set; }

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
        }

        public GameProcess createGameProcess(Dice dice) {
            gameProcess = new GameProcess(dice);
            return gameProcess;
        }

        internal void addPlayers(ListBox.ObjectCollection items)
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
            return new Dice(type);
        }

        internal bool IsLastPlayer(Player player)
        {
            return player.id >= playerList.Count - 1;
        }
        internal Round getLastRound()
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
            gameProcess.startRound(playerList.First());
        }

        private void startTurn(Player player)
        {
            var round = getLastRound();
            var turn = newTurn(player, round);
            gameProcess.startTurn(player);
        }

        internal Round newRound()
        {
            var round = new Round();
            roundList.Add(round);

            foreach (var player in playerList)
            {
                player.createCurrentBug();
            }
            return round;
        }

        internal Turn newTurn(Player player, Round round)
        {
            var turn = new Turn(player);
            round.addTurn(turn);
            return turn;
        }


        internal List<Player> getWinners()
        {
            if (numberOfBugsToWin != 0 || numberOfPointsToWin != 0)
            {
                return checkWinners();
            }
            else
            {
                return checkRoundWinners();
            }
        }

        public List<Player> checkWinners()
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

        internal List<Player> checkRoundWinners()
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

        internal string formatPlayersScore()
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


        internal void throwDice()
        {
            var round = getLastRound();
            var turn = round.getLastTurn();
            var isAdded = round.throwDice(dice);
            var a = gameProcess.throwDice(turn, isAdded);

            nextMove(isAdded, turn);
        }

        internal void nextMove(bool isPartAdded, Turn turn)
        {
            if (!isTurnContinuous || (!isPartAdded && isTurnContinuous))
            {
                nextPlayer(turn.currentPlayer);
            }
            else
            {
                startTurn(turn.currentPlayer);
            }
        }

        public void nextPlayer(Player player)
        {
            var firstPlayer = playerList.First();
            if (IsLastPlayer(player))
            {
                var roundWinners = checkRoundWinners();
                //Два игрока могут выиграть, например при игре до 5 очков
                //var roundWinners = gameProperties.playerList;
                //gameProperties.playerList[0].score = 5;
                //gameProperties.playerList[1].score = 5;

                if (roundWinners.Count > 0)
                {
                    var gameWinners = getWinners();
                    if (gameWinners.Count > 0)
                    {
                        gameProcess.finishGame(gameWinners, formatPlayersScore());
                    }
                    else
                    {
                        gameProcess.finishRound(roundWinners, "Выигран раунд");
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
                var nextPlayer = playerList[player.id + 1];
                startTurn(nextPlayer);
            }
        }
    }
}
