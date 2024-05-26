using game.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace game
{
    public partial class GameField : Form
    {
        private Game game;
        private List<Label> bugLabels = new List<Label>();
        private List<Panel> panels = new List<Panel>();
        private GameProcess gameProcess;
        private bool isFirstTurn = true;

        public GameField()
        {
            InitializeComponent();
        }

        public GameField(Game newGame)
        {
            game = newGame;
            gameProcess = game.gameProcess;

            InitializeComponent();
            InitializePlayersFields(game.playerList);
            SubscribeOnGameProcess();

            game.StartGame();
        }

        private void SubscribeOnGameProcess()
        {
            gameProcess.WonGame += GameProcess_WonGame;
            gameProcess.NeedNewRound += GameProcess_NeedNewRound;
            gameProcess.NeedNewTurn += GameProcess_NeedNewTurn;
            gameProcess.LabelChange += GameProcess_LabelChange;
            gameProcess.LabelUpdate += GameProcess_LabelUpdate;
            gameProcess.DrawBug += GameProcess_DrawBug;
            gameProcess.Wait += GameProcess_Wait;
            gameProcess.WonRound += GameProcess_WonRound;
            gameProcess.NextPlayerMove += GameProcess_NextPlayerMove;
            gameProcess.RollResultAddedOrNot += GameProcess_RollResultAddedOrNot;
        }

        private void InitializePlayersFields(List<Player> players)
        {
            var x = 20;
            var count = 0;

            if (players.Count > 4)
            {
                Height += 200;
            }

            var playerLabelcoords = getCoords(x, 260, 150, 200, players.Count, true);
            var panelncoords = getCoords(x, 295, 150, 200, players.Count, true);
            var panelBugncoords = getCoords(x, 285, 150, 200, players.Count, true);

            foreach (var player in players)
            {
                Label playerLabeln = new Label();
                this.Controls.Add(playerLabeln);
                playerLabeln.Text = player.name;
                playerLabeln.Location = new Point(playerLabelcoords[player.id].x, playerLabelcoords[player.id].y);
                playerLabeln.Name = $"panelLabel{count}";
                playerLabeln.Size = new Size(58, 17);

                Panel paneln = new Panel();
                Controls.Add(paneln);
                paneln.Location = new Point(panelncoords[player.id].x, panelncoords[player.id].y);
                paneln.Name = $"panel{count}";
                paneln.BackgroundImageLayout = ImageLayout.Zoom;
                paneln.Size = new Size((int)(130 / 1.25), (int)(130 / 1.25));

                Label panelBugn = new Label();
                this.Controls.Add(panelBugn);
                panelBugn.Text = "";
                panelBugn.Location = new Point(panelBugncoords[player.id].x, panelBugncoords[player.id].y);
                panelBugn.Name = $"panelBug{count}";
                panelBugn.Size = new Size(58, 17);
                panelBugn.AutoSize = true;

                panels.Add(paneln);
                bugLabels.Add(panelBugn);

                count += 1;
            }
            panelBorder.SendToBack();
        }

        public void GameProcess_RollResultAddedOrNot(object sender, GameEventArgs e)
        {
            if (e.isAdded)
            {
                panelBackground.BackgroundImage = Resources.borderGreen;
            }
            else
            {
                panelBackground.BackgroundImage = Resources.borderRed;
            }
        }

        private void GameProcess_NextPlayerMove(object sender, GameEventArgs e)
        {
            turnResult.Text = e.result;
        }

        private async void GameProcess_Wait(object sender, GameEventArgs e)
        {
            await Task.Delay(TimeSpan.FromSeconds(0));
            clean();
        }
        private void clean()
        {
            panelBackground.BackgroundImage = null;
            turnResult.Text = "";
            rollResultPanel.BackgroundImage = null;
            button1.Enabled = true;
        }

        private void GameProcess_DrawBug(object sender, GameEventArgs e)
        {
            drawBug(e.player, e.rollResult);
        }

        private void GameProcess_LabelUpdate(object sender, GameEventArgs e)
        {
            label1.Update();
        }

        private void GameProcess_LabelChange(object sender, GameEventArgs e)
        {
            var result = e.rollResult;

            if (result is RollResultNumber)
            {
                rollResultlabel.Text = result.getResultName();
            }
            else
            {
                rollResultPanel.BackgroundImage = setImagePart(result.getResultName());
            }
        }


        private void GameProcess_NeedNewTurn(object sender, GameEventArgs e)
        {
            startTurn(e.player.name, e.player.id);
        }

        private void GameProcess_NeedNewRound(object sender, GameEventArgs e)
        {
            foreach (var label in bugLabels)
            {
                label.Text = "";
            }
            foreach (var panel in panels)
            {
                panel.Controls.Clear();
                panel.BackgroundImage = null;
            }
        }

        private void GameProcess_WonGame(object sender, GameEventArgs e)
        {
            declareWin(e.playersList, e.result);
            Close();
        }

        private void GameProcess_WonRound(object sender, GameEventArgs e)
        {
            declareWin(e.playersList, e.result);
        }

        private List<Coords> getCoords(int startX, int startY, int offsetX, int offsetY, int count, bool isHighRes)
        {
            var list = new List<Coords>();
            var newX = startX;
            if (isHighRes)
            {
                startY = (int)(startY / 1.25);
            }

            for (int i = 0; i < count; i++)
            {
                if (i < 4)
                {
                    list.Add(new Coords(newX, startY));
                }
                else
                {
                    list.Add(new Coords(newX, startY + offsetY));
                }
                newX += offsetX;

                if (i == 3)
                {
                    newX = startX;
                }
            }
            return list;
        }

        private async void startTurn(string name, int id)
        {
            if (!isFirstTurn)
            {
                await Task.Delay(TimeSpan.FromSeconds(0));
            }
            else { isFirstTurn = false; }

            var location = panels[id].Location;
            panelBorder.Location = new Point(location.X - 10, location.Y - 8);
            panelBorder.Visible = true;

            label1.Text = $"{name}, ваш ход";
            rollResultlabel.Text = "";
        }

        private void declareWin(List<Player> players, string playersScore)
        {
            var congrats = players.Count > 1 ? "Победители: " : "Победитель: ";
            foreach (var player in players)
            {
                congrats += player.name;
                congrats += "\n";
            }
            MessageBox.Show(congrats, "Есть победитель!", MessageBoxButtons.OK);
            MessageBox.Show(playersScore, "Счет игроков", MessageBoxButtons.OK);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            game.throwDice();
        }

        private void drawBug(Player player, IRollResult result)
        {
            var label = bugLabels[player.id];
            var panel = panels[player.id];
            Bitmap image = getImage(player.currentBug, result);
            panel.BackgroundImage = image;
        }

        private Bitmap setImagePart(string name)
        {
            switch (name)
            {
                case "Туловище":
                    return Resources.body;
                case "Голова":
                    return Resources.head;
                case "Усики":
                    return Resources.antennaes;
                case "Глаза":
                    return Resources.eyes;
                case "Ножки":
                    return Resources.legs;
                case "Хвост":
                    return Resources.tail;
                default:
                    return Resources.body;
            }
        }

        private Bitmap getImage(Bug bug, IRollResult result)
        {
            switch (bug.getState())
            {
                case BugState.no_head:
                    return Resources.Bugbody;
                case BugState.no_accs:
                    return Resources.BugHead;
                case BugState.one_acc:
                    if (result.getResult() == BugParts.Eyes)
                    {
                        return Resources.BugEyes;
                    }
                    return Resources.BugAntennaes;
                case BugState.no_legs:
                    return Resources.BugAntennaesAndEyes;
                case BugState.one_legs:
                    return Resources.BugLegsL;
                case BugState.no_tail:
                    return Resources.BugLegsR;
                case BugState.complete:
                    return Resources.BugTail;
                default:
                    return Resources.Bugbody;
            }
        }
    }

    public class Coords
    {
        public int x;
        public int y;

        public Coords(int X, int Y)
        {
            x = X; y = Y;
        }
    }
}
