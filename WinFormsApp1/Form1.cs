using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T_Rex
{
    public partial class Form1 : Form
    {
        bool jumping = false;
        int jumpSpeed; // Vertical speed of trex
        int force = 12; // force during jump (height limit)
        int score = 0;
        int obstacleSpeed = 10;
        Random rand = new Random(); // Random for placing of the obstacle
        int position; // Position for the obstacles
        bool isGameOver = false;

        public Form1()
        {
            InitializeComponent();

            SQLiteHelper.InitializeDatabase(); // Call to initialize the SQLite database

            // Clear the high score when the application starts, preference
            SQLiteHelper.ClearScores();

            GameReset();
        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            // Vertical movement of trex based on the speed
            trex.Top += jumpSpeed;

            txtScore.Text = "Score: " + score;

            // Jumping is false when trex is on the ground
            if (jumping == true && force < 0)
            {
                jumping = false;
            }


            if (jumping == true)
            {
                jumpSpeed = -12; // Move up
                force -= 1;
            }
            else
            {
                jumpSpeed = 12; // Move down
            }

            // Make sure trex is on the floor when not jumping and not under or above it
            if (trex.Top > 254 && jumping == false)
            {
                force = 12;
                trex.Top = 255;
                jumpSpeed = 0;
            }

            // Go through all windows forms ellements
            foreach (Control x in this.Controls)
            {
                // If it is a picturebox with this tag...
                if (x is PictureBox && (string)x.Tag == "obstacle")
                {
                    x.Left -= obstacleSpeed;

                    if (x.Left < -100)
                    {
                        // Reset obstacle position and add score
                        x.Left = this.ClientSize.Width + rand.Next(200, 500) + (x.Width * 15);
                        score++;
                    }

                    // Check if the trex hit the obstacle, if so game over
                    if (trex.Bounds.IntersectsWith(x.Bounds))
                    {
                        gameTimer.Stop();
                        trex.Image = Properties.Resources.dead;

                        // Insert score
                        SQLiteHelper.InsertScore(score);

                        // Get score
                        Score highScore = new Score();
                        highScore.Value = SQLiteHelper.GetHighScore();

                        // Display score
                        gameOver.Text = $"Game Over! Press R\nYour High Score: {highScore.Value}";

                        isGameOver = true;
                    }
                }
            }

            if (score > 5)
            {
                obstacleSpeed = 15;
            }

        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && jumping == false)
            {
                // set jumping to true only if he is not jumping, otherwise you can fly
                jumping = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (jumping == true)
            {
                // stop jump when key is released
                jumping = false;
            }

            if (e.KeyCode == Keys.R && isGameOver == true)
            {
                // Reset game when the game is over and R is pressed
                GameReset();
            }
        }

        private void GameReset()
        {
            force = 12;
            jumpSpeed = 0;
            jumping = false;
            score = 0;
            obstacleSpeed = 10;
            txtScore.Text = "Score: " + score;

            trex.Image = Properties.Resources.running;
            isGameOver = false;

            // Position of the trex. Otherwise he wouldn't stand on the floor.
            trex.Top = 255;

            foreach (Control x in this.Controls)
            {

                if (x is PictureBox && (string)x.Tag == "obstacle")
                {
                    // generate random position
                    int position = rand.Next(600, 1000); 
                    // change the obstacles left position to a random location begining of the game
                    x.Left = 640 + (x.Left + position + x.Width * 3);
                }
            }

            gameOver.Text = "";

            gameTimer.Start();

        }

    }
}
