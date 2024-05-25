
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
            this.rollResultPanel.SuspendLayout();
            this.panelBackground.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(637, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 62);
            this.button1.TabIndex = 0;
            this.button1.Text = "Бросить кубик";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(321, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Игрок н, ваш ход";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Результат броска:";
            // 
            // rollResultlabel
            // 
            this.rollResultlabel.AutoSize = true;
            this.rollResultlabel.Location = new System.Drawing.Point(13, 9);
            this.rollResultlabel.Name = "rollResultlabel";
            this.rollResultlabel.Size = new System.Drawing.Size(0, 16);
            this.rollResultlabel.TabIndex = 3;
            // 
            // turnResult
            // 
            this.turnResult.AutoSize = true;
            this.turnResult.Location = new System.Drawing.Point(323, 50);
            this.turnResult.Name = "turnResult";
            this.turnResult.Size = new System.Drawing.Size(0, 16);
            this.turnResult.TabIndex = 4;
            // 
            // rollResultPanel
            // 
            this.rollResultPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.rollResultPanel.Controls.Add(this.rollResultlabel);
            this.rollResultPanel.Location = new System.Drawing.Point(5, 4);
            this.rollResultPanel.Name = "rollResultPanel";
            this.rollResultPanel.Size = new System.Drawing.Size(100, 100);
            this.rollResultPanel.TabIndex = 5;
            // 
            // panelBackground
            // 
            this.panelBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelBackground.Controls.Add(this.rollResultPanel);
            this.panelBackground.Location = new System.Drawing.Point(14, 154);
            this.panelBackground.Name = "panelBackground";
            this.panelBackground.Size = new System.Drawing.Size(110, 110);
            this.panelBackground.TabIndex = 6;
            // 
            // GameField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.turnResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panelBackground);
            this.Name = "GameField";
            this.Text = "Игра";
            this.Load += new System.EventHandler(this.GameField_Load);
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
    }
}