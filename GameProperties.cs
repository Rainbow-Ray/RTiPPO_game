using System;
using System.Windows.Forms;

namespace game
{
    public partial class GameProperties : Form
    {
        public GameProperties()
        {
            InitializeComponent();
        }

        private void GameProperties_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 1)
            {
                MessageBox.Show("Введите имя", "Игрок без имени", MessageBoxButtons.OK);
            }
            else
            {
                listBox1.Items.Add(textBox1.Text);
            }
            textBox1.Clear();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in groupBox2.Controls)
            {
                ((Control)item).Enabled = checkBox1.Checked ? true : false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkFields())
            {
                var isPointsToWin = (radioButton4.Checked && checkBox1.Checked);
                var ifTurnIsContinuous = checkBox2.Checked;
                var numberToWin = checkBox1.Checked ? int.Parse(numericUpDown1.Value.ToString()) : 1;

                Game newGame = new Game(ifTurnIsContinuous, isPointsToWin, numberToWin);
                newGame.addPlayers(listBox1.Items);
                var type = radioButton1.Checked ? "numbers" : "parts";
                var dice = newGame.createDice(type);
                GameField game = new GameField(newGame);
                game.ShowDialog();
                this.Close();
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Value = 1;
        }

        private bool checkFields()
        {
            if (checkBox1.Checked)
            {
                if (numericUpDown1.Value < 1)
                {
                    MessageBox.Show("Введите, до какого количества очков или жучков вы хотите играть", "Не задано количество для выигрыша", MessageBoxButtons.OK);
                    return false;
                }
            }
            if (listBox1.Items.Count < 2)
            {
                MessageBox.Show("Введите больше игроков, минимальное количество: 2", "Слишком мало игроков", MessageBoxButtons.OK);
                return false;
            }
            if (listBox1.Items.Count > 8)
            {
                MessageBox.Show("Введите меньше игроков, максимальное количество: 8", "Слишком много игроков", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                var player = listBox1.SelectedItems[0];
                listBox1.Items.Remove(player);
            }
        }
    }
}
