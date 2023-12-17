namespace T_Rex
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            floor = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            trex = new PictureBox();
            txtScore = new Label();
            gameTimer = new System.Windows.Forms.Timer(components);
            gameOver = new Label();
            ((System.ComponentModel.ISupportInitialize)floor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trex).BeginInit();
            SuspendLayout();
            // 
            // floor
            // 
            floor.BackColor = Color.Black;
            floor.Location = new Point(-11, 397);
            floor.Name = "floor";
            floor.Size = new Size(818, 73);
            floor.TabIndex = 0;
            floor.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.obstacle_2;
            pictureBox2.Location = new Point(665, 352);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(32, 33);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            pictureBox2.Tag = "obstacle";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.obstacle_1;
            pictureBox3.Location = new Point(504, 335);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(23, 46);
            pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox3.TabIndex = 1;
            pictureBox3.TabStop = false;
            pictureBox3.Tag = "obstacle";
            // 
            // trex
            // 
            trex.Image = Properties.Resources.running;
            trex.Location = new Point(103, 335);
            trex.Name = "trex";
            trex.Size = new Size(40, 43);
            trex.SizeMode = PictureBoxSizeMode.AutoSize;
            trex.TabIndex = 1;
            trex.TabStop = false;
            // 
            // txtScore
            // 
            txtScore.AutoSize = true;
            txtScore.Font = new Font("Consolas", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtScore.Location = new Point(8, 10);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(135, 33);
            txtScore.TabIndex = 2;
            txtScore.Text = "Score: 0";
            // 
            // gameTimer
            // 
            gameTimer.Interval = 20;
            gameTimer.Tick += MainGameTimerEvent;
            // 
            // gameOver
            // 
            gameOver.AutoSize = true;
            gameOver.Font = new Font("Consolas", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gameOver.Location = new Point(230, 174);
            gameOver.Name = "gameOver";
            gameOver.Size = new Size(0, 33);
            gameOver.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 459);
            Controls.Add(gameOver);
            Controls.Add(txtScore);
            Controls.Add(trex);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(floor);
            Name = "Form1";
            Text = "T Rex";
            KeyDown += keyisdown;
            KeyUp += keyisup;
            ((System.ComponentModel.ISupportInitialize)floor).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)trex).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox floor;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox trex;
        private Label txtScore;
        private System.Windows.Forms.Timer gameTimer;
        private Label gameOver;
    }
}