namespace BlackJack
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button button1;
        private Button button2;
        private Label labelTitle;
        private Label labelPlayerScore;
        private Label labelDealerScore;
        private Label labelStatus;
        private Panel panelScore;
        private Label labelScoreTitle;
        private Label labelWins;
        private Label labelLosses;
        private Label labelDraws;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            labelTitle = new Label();
            labelPlayerScore = new Label();
            labelDealerScore = new Label();
            labelStatus = new Label();
            panelScore = new Panel();
            labelScoreTitle = new Label();
            labelWins = new Label();
            labelLosses = new Label();
            labelDraws = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panelScore.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(10, 72, 51);
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(46, 307);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1054, 232);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(10, 72, 51);
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Location = new Point(245, 90);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(860, 150);
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(433, 579);
            button1.Name = "button1";
            button1.Size = new Size(120, 42);
            button1.TabIndex = 0;
            button1.Text = "Hit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(592, 579);
            button2.Name = "button2";
            button2.Size = new Size(120, 42);
            button2.TabIndex = 1;
            button2.Text = "Stand";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // labelTitle
            // 
            labelTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(255, 9);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(850, 44);
            labelTitle.TabIndex = 2;
            labelTitle.Text = "BLACKJACK";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            labelTitle.Click += labelTitle_Click;
            // 
            // labelPlayerScore
            // 
            labelPlayerScore.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelPlayerScore.ForeColor = Color.White;
            labelPlayerScore.Location = new Point(255, 276);
            labelPlayerScore.Name = "labelPlayerScore";
            labelPlayerScore.Size = new Size(400, 28);
            labelPlayerScore.TabIndex = 3;
            labelPlayerScore.Text = "Player total:";
            // 
            // labelDealerScore
            // 
            labelDealerScore.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelDealerScore.ForeColor = Color.White;
            labelDealerScore.ImageAlign = ContentAlignment.MiddleRight;
            labelDealerScore.Location = new Point(705, 59);
            labelDealerScore.Name = "labelDealerScore";
            labelDealerScore.RightToLeft = RightToLeft.Yes;
            labelDealerScore.Size = new Size(400, 28);
            labelDealerScore.TabIndex = 4;
            labelDealerScore.Text = "Dealer Total:";
            labelDealerScore.Click += labelDealerScore_Click;
            // 
            // labelStatus
            // 
            labelStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelStatus.ForeColor = Color.White;
            labelStatus.Location = new Point(250, 542);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(850, 34);
            labelStatus.TabIndex = 5;
            labelStatus.Text = "Choose Hit or Stand.";
            labelStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelScore
            // 
            panelScore.BackColor = Color.FromArgb(10, 72, 51);
            panelScore.BorderStyle = BorderStyle.FixedSingle;
            panelScore.Controls.Add(labelScoreTitle);
            panelScore.Controls.Add(labelWins);
            panelScore.Controls.Add(labelLosses);
            panelScore.Controls.Add(labelDraws);
            panelScore.Location = new Point(12, 20);
            panelScore.Name = "panelScore";
            panelScore.Size = new Size(190, 220);
            panelScore.TabIndex = 8;
            // 
            // labelScoreTitle
            // 
            labelScoreTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            labelScoreTitle.ForeColor = Color.White;
            labelScoreTitle.Location = new Point(15, 18);
            labelScoreTitle.Name = "labelScoreTitle";
            labelScoreTitle.Size = new Size(155, 34);
            labelScoreTitle.TabIndex = 0;
            labelScoreTitle.Text = "SCORE";
            labelScoreTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelWins
            // 
            labelWins.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelWins.ForeColor = Color.White;
            labelWins.Location = new Point(18, 72);
            labelWins.Name = "labelWins";
            labelWins.Size = new Size(150, 28);
            labelWins.TabIndex = 1;
            labelWins.Text = "Wins: 0";
            // 
            // labelLosses
            // 
            labelLosses.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelLosses.ForeColor = Color.White;
            labelLosses.Location = new Point(18, 117);
            labelLosses.Name = "labelLosses";
            labelLosses.Size = new Size(150, 28);
            labelLosses.TabIndex = 2;
            labelLosses.Text = "Losses: 0";
            // 
            // labelDraws
            // 
            labelDraws.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelDraws.ForeColor = Color.White;
            labelDraws.Location = new Point(18, 162);
            labelDraws.Name = "labelDraws";
            labelDraws.Size = new Size(150, 28);
            labelDraws.TabIndex = 3;
            labelDraws.Text = "Draws: 0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 91, 65);
            ClientSize = new Size(1134, 661);
            Controls.Add(panelScore);
            Controls.Add(labelStatus);
            Controls.Add(labelDealerScore);
            Controls.Add(labelPlayerScore);
            Controls.Add(labelTitle);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            MinimumSize = new Size(1150, 700);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blackjack";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panelScore.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
