using System;
using System.Windows.Forms;

namespace game
{
    public partial class StartMenuForm : Form
    {
        public StartMenuForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameProperties GameProperties = new GameProperties();
            GameProperties.ShowDialog();
        }
    }
}
