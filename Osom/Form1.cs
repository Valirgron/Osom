using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Osom
{
    public partial class Form1 : Form
    {
        int rounds = 3;
        int timerPerRound = 6;
        bool gameOver = false;

        string[] AIchoiceList = { "rock", "paper", "scissor", "rock", "paper", "scissor" };
        int randomNumber = 0;

        Random rnd = new Random();
        string AIchoice;
        string playerChoice;
        int playerScore;
        int AIScore;



        public Form1()
        {
            InitializeComponent();
            counDownTimer.Enabled = true;

            playerChoice = "none";

            txtCountDown.Text = "5";

        }

        private void btnRock_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.rock;
            playerChoice = "rock";
        }

        private void btnPaper_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.paper;
            playerChoice = "paper";
        }

        private void btnScissors_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.scissors;
            playerChoice = "scissor";
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            playerScore = 0;
            AIScore = 0;
            rounds = 3;
            txtScore.Text = "Player " + playerScore + ":" + AIScore + " AI";

            playerChoice = "none";

            counDownTimer.Enabled = true;

            picPlayer.Image = Properties.Resources.qq;
            picAI.Image = Properties.Resources.qq;

            gameOver = false;

        }

        private void countDownTimerEvent(object sender, EventArgs e)
        {
            timerPerRound -= 1;
            txtCountDown.Text = timerPerRound.ToString();
            txtRounds.Text = "Rounds:" + rounds;

            if(timerPerRound < 1)
            {
                counDownTimer.Enabled = false;
                timerPerRound = 6;
                randomNumber = rnd.Next(0, AIchoiceList.Length);
                AIchoice = AIchoiceList[randomNumber];

                switch(AIchoice)
                {
                    case "rock":
                        picAI.Image = Properties.Resources.rock;
                        break;

                    case "paper":
                        picAI.Image = Properties.Resources.paper;
                        break;

                    case "scissor":
                        picAI.Image = Properties.Resources.scissors;
                        break;

                }
                if (rounds > 0)
                {
                    checkGame();
                }
                else
                {
                    if(playerScore > AIScore)
                    {
                        MessageBox.Show("Player Won!!!");
                    }
                    else
                    {
                        MessageBox.Show("AI Won!!!");
                    }
                    gameOver = true;
                }
            }

            

        }
        private void checkGame()
        {
            if(playerChoice == "rock" && AIchoice == "paper")
            {
                AIScore += 1;
                rounds -= 1;
                MessageBox.Show("AI Wins, butuh Player noob");
            }
            else if (playerChoice == "paper" && AIchoice == "scissor")
            {
                AIScore += 1;
                rounds -= 1;
                MessageBox.Show("AI Wins, butuh Player noob");
            }
            else if (playerChoice == "scissor" && AIchoice == "rock")
            {
                AIScore += 1;
                rounds -= 1;
                MessageBox.Show("AI Wins, butuh Player noob");
            }
            else if (playerChoice == "rock" && AIchoice == "scissor")
            {
                playerScore += 1;
                rounds -= 1;
                MessageBox.Show("Player Wins, padan muka AI noob");
            }
            else if (playerChoice == "paper" && AIchoice == "rock")
            {
                playerScore += 1;
                rounds -= 1;
                MessageBox.Show("Player Wins, padan muka AI noob");
            }
            else if (playerChoice == "scissor" && AIchoice == "paper")
            {
                playerScore += 1;
                rounds -= 1;
                MessageBox.Show("Player Wins, padan muka AI noob");
            }
            else if(playerChoice == "none")
            {
                MessageBox.Show("Please make a choice!!!");
            }
            else
            {
                MessageBox.Show("Draw!!!");
            }
            startNextRound();
        }

        private void startNextRound()
        {
            if(gameOver == true)
            {
                return;
            }

            txtScore.Text = "Player " + playerScore + ":" + AIScore + " AI";
            playerChoice = "none";
            counDownTimer.Enabled = true;
            picPlayer.Image = Properties.Resources.qq;
            picAI.Image = Properties.Resources.qq;



        }



    }
}
