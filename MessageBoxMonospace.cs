using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game
{
    internal class MessageBoxMonospace : Form
    {
        string bodyText;
        string headerText;

        public MessageBoxMonospace(string bodyText, string headerText)
        {
            this.bodyText = bodyText;
            this.headerText = headerText;
            Initialize();
        }

        private void Initialize()
        {
            this.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Text = headerText;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            var tableLayout = new TableLayoutPanel();
            tableLayout.ColumnCount = 1;
            tableLayout.RowCount = 2;
            tableLayout.AutoSize = true;
            tableLayout.Dock = DockStyle.Fill;

            var label = new Label();
            label.Anchor = AnchorStyles.Top;
            label.Margin = new Padding(0, 10, 0, 0);
            label.Parent = this;
            label.AutoSize = true;
            label.Text = bodyText;

            var button1 = new Button();
            button1.Anchor = AnchorStyles.Right;
            button1.Parent = this;
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(45, 25);
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new System.EventHandler(this.button1_Click);

            Controls.Add(tableLayout);
            tableLayout.Controls.Add(label);
            tableLayout.Controls.Add(button1);
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
