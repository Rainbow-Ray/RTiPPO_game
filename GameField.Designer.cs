
namespace game
{
    partial class GameField
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rollResultlabel = new System.Windows.Forms.Label();
            this.turnResult = new System.Windows.Forms.Label();
            this.rollResultPanel = new System.Windows.Forms.Panel();
            this.panelBackground = new System.Windows.Forms.Panel();
            this.panelBorder = new System.Windows.Forms.Panel();
            this.rollResultPanel.SuspendLayout();
            this.panelBackground.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(637, 102);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 62);
            this.button1.TabIndex = 0;
            this.button1.Text = "Бросить кубик";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Игрок н, ваш ход";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Результат броска:";
            // 
            // rollResultlabel
            // 
            this.rollResultlabel.AutoSize = true;
            this.rollResultlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rollResultlabel.Location = new System.Drawing.Point(30, 27);
            this.rollResultlabel.Name = "rollResultlabel";
            this.rollResultlabel.Size = new System.Drawing.Size(0, 22);
            this.rollResultlabel.TabIndex = 3;
            // 
            // turnResult
            // 
            this.turnResult.AutoSize = true;
            this.turnResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.turnResult.Location = new System.Drawing.Point(277, 41);
            this.turnResult.Name = "turnResult";
            this.turnResult.Size = new System.Drawing.Size(0, 18);
            this.turnResult.TabIndex = 4;
            this.turnResult.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // rollResultPanel
            // 
            this.rollResultPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rollResultPanel.Controls.Add(this.rollResultlabel);
            this.rollResultPanel.Location = new System.Drawing.Point(7, 6);
            this.rollResultPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rollResultPanel.Name = "rollResultPanel";
            this.rollResultPanel.Size = new System.Drawing.Size(85, 79);
            this.rollResultPanel.TabIndex = 5;
            // 
            // panelBackground
            // 
            this.panelBackground.BackColor = System.Drawing.Color.Transparent;
            this.panelBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelBackground.Controls.Add(this.rollResultPanel);
            this.panelBackground.Location = new System.Drawing.Point(22, 126);
            this.panelBackground.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelBackground.Name = "panelBackground";
            this.panelBackground.Size = new System.Drawing.Size(100, 95);
            this.panelBackground.TabIndex = 6;
            // 
            // panelBorder
            // 
            this.panelBorder.BackColor = System.Drawing.Color.Transparent;
            this.panelBorder.BackgroundImage = global::game.Properties.Resources.border;
            this.panelBorder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelBorder.Location = new System.Drawing.Point(12, 281);
            this.panelBorder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelBorder.Name = "panelBorder";
            this.panelBorder.Size = new System.Drawing.Size(160, 148);
            this.panelBorder.TabIndex = 7;
            // 
            // GameField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(191)))), ((int)(((byte)(163)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.turnResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panelBackground);
            this.Controls.Add(this.panelBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GameField";
            this.Text = "Игра";
            this.rollResultPanel.ResumeLayout(false);
            this.rollResultPanel.PerformLayout();
            this.panelBackground.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label rollResultlabel;
        private System.Windows.Forms.Label turnResult;
        private System.Windows.Forms.Panel rollResultPanel;
        private System.Windows.Forms.Panel panelBackground;
        private System.Windows.Forms.Panel panelBorder;
    }
}