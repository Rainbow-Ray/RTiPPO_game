using game.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace game
{
    public partial class GameField : Form
    {
        Game game;
        List<Label> bugLabels = new List<Label>();
        List<Panel> panels = new List<Panel>();
        GameProcess gameProcess;
        bool isFirstTurn = true;

        public GameField()
        {
            InitializeComponent();
        }

        public GameField(Game newGame)
        {
            game = newGame;
            gameProcess = game.gameProcess;

            InitializeComponent();
            panelBorder.BackColor = Color.Transparent;
            this.BackColor = Color.FromArgb(142, 191, 163);
            var count = 0;
            var x = 13;
            var panelLabelcoords = getCoords(x, 270, 150, 200, game.playerList.Count, true);
            var panelncoords = getCoords(x, 295, 150, 200, game.playerList.Count, true);
            var panelBugncoords = getCoords(x, 285, 150, 200, game.playerList.Count, true);
            if (game.playerList.Count > 4)
            {
                this.Height += 200;
            }
            foreach (var player in game.playerList)
            {
                Label panelLabeln = new Label();
                this.Controls.Add(panelLabeln);
                panelLabeln.Text = player.name;
                panelLabeln.Location = new Point(panelLabelcoords[player.id].x, panelLabelcoords[player.id].y);
                panelLabeln.Name = $"panelLabel{count}";
                panelLabeln.Size = new Size(58, 17);

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


            gameProcess.WonGame += Game_WonGame;
            gameProcess.NeedNewRound += Game_NeedNewRound;
            gameProcess.NeedNewTurn += Game_NeedNewTurn;
            gameProcess.LabelChange += Game_LabelChange;
            gameProcess.LabelUpdate += Game_LabelUpdate;
            gameProcess.DrawBug += Game_DrawBug;
            gameProcess.Wait += Game_Wait;
            gameProcess.WonRound += Game_WonRound;
            gameProcess.NextPlayerMove += GameProcess_NextPlayerMove;
            gameProcess.RollResultAddedOrNot += GameProcess_RollResultAddedOrNot;

            game.StartGame();
        }

        public void GameProcess_RollResultAddedOrNot(object sender, GameEventArgs e)
        {
            if (e.isAdded)
            {
                panelBackground.BackColor = Color.Green;
            }
            else
            {
                panelBackground.BackColor = Color.Red;
            }
        }

        private void  GameProcess_NextPlayerMove(object sender, GameEventArgs e)
        {
            turnResult.Text = e.result;
        }

        private async void Game_Wait(object sender, GameEventArgs e)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            clean();
        }
        private void clean()
        {
            panelBackground.BackColor = Color.FromArgb(163, 210, 168);
            turnResult.Text = "";
            rollResultPanel.BackgroundImage = null;
            button1.Enabled = true;
        }

        private void Game_DrawBug(object sender, GameEventArgs e)
        {
            drawBug(e.player, e.rollResult);
        }

        private void Game_LabelUpdate(object sender, GameEventArgs e)
        {
            label1.Update();
        }

        private void Game_LabelChange(object sender, GameEventArgs e)
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

        private void Game_NeedNewTurn(object sender, GameEventArgs e)
        {
            startTurn(e.player.name, e.player.id);
        }

        private void Game_NeedNewRound(object sender, GameEventArgs e)
        {
            startRound();
        }

        private void Game_WonGame(object sender, GameEventArgs e)
        {
            declareWin(e.playersList, e.result);
            this.Close();
        }

        private void Game_WonRound(object sender, GameEventArgs e)
        {
            declareWin(e.playersList, e.result);
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

        private List<Coords> getCoords(int startX, int startY, int offsetX, int offsetY, int count, bool isHighRes)
        {
            var list = new List<Coords>();
            var newX = startX;
            if (isHighRes)
            {
                startY = (int)(startY/ 1.25);
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

        private void GameField_Load(object sender, EventArgs e)
        {
        }

        private void startRound()
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

        private async void startTurn(string name, int id)
        {
            if (!isFirstTurn)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
            else { isFirstTurn = false; }

            var location = panels[id].Location;
            panelBorder.Location = new Point(location.X - 5, location.Y - 5);
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
    }
