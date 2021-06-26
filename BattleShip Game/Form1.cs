using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;

namespace BattleShip_Game
{
    public partial class Form1 : Form


        

    {
       List<Button>  playerPositionButtons;
       List<Button> EnemyPositionButtons;


        Random rand = new Random();

        int totalShip = 10;
        int round = 20;
        int playerScore;
        int enemyScore;

        public Form1()
        {
            InitializeComponent();
            RestartGame();
        }


        private void EnemyPlayTimerEvent(object sender, EventArgs e)
        {
            if (playerPositionButtons.Count > 0 && round > 0)
            {
                round -= 1;
                txtRounds.Text = "Round : " + round;
                int index = rand.Next(playerPositionButtons.Count);

                if ((string)playerPositionButtons[index].Tag == "playerShip")
                {
                    playerPositionButtons[index].BackgroundImage = Properties.Resources.nuclear_explosion;
                    enemyMoves.Text = playerPositionButtons[index].Text;
                    playerPositionButtons[index].Enabled = false;
                    playerPositionButtons[index].BackColor = Color.LightBlue;
                    playerPositionButtons.RemoveAt(index);
                    enemyScore += 1;
                    txtEnemy.Text = enemyScore.ToString();
                    EnemyPlayTimer.Stop();
                }
                else
                {
                    playerPositionButtons[index].BackgroundImage = Properties.Resources.cancel_mark;
                    enemyMoves.Text = playerPositionButtons[index].Text;
                    playerPositionButtons[index].Enabled = false;
                    playerPositionButtons[index].BackColor = Color.LightBlue;
                    playerPositionButtons.RemoveAt(index);
                    EnemyPlayTimer.Stop();

                }

            }
            if (round < 1 || enemyScore > 2 || playerScore > 2)
            {

                if (playerScore > enemyScore)
                {
                    MessageBox.Show("You win !!", "Winning");                
                }
                else if (playerScore < enemyScore)
                {
                    MessageBox.Show("I sunk your battleship", "Lost");
                    RestartGame();
                }
               else if (playerScore == enemyScore)
                {
                    MessageBox.Show("No one wins this game", "Drow");
                    RestartGame();
                }
            }

           



        }

        private void AttackButtonEvent(object sender, EventArgs e)
        {
            if (EnemyLocationListBox.Text != "")
            {

                var attackPosition = EnemyLocationListBox.Text.ToUpper();

                int index = EnemyPositionButtons.FindIndex(a => a.Name == attackPosition);


               

                    if (EnemyPositionButtons[index].Enabled && round > 0)
                    {
                        round -= 1;
                        txtRounds.Text = "Round :" + round;

                        if ((String)EnemyPositionButtons[index].Tag == "enemyShip")
                        {
                            EnemyPositionButtons[index].Enabled = false;
                            EnemyPositionButtons[index].BackgroundImage = Properties.Resources.nuclear_explosion;
                            EnemyPositionButtons[index].BackColor = Color.LightBlue;
                            playerScore += 1;
                            txtPlayer.Text = playerScore.ToString();
                            EnemyPlayTimer.Start();
                        }

                        else
                        {
                            EnemyPositionButtons[index].Enabled = false;
                            EnemyPositionButtons[index].BackgroundImage = Properties.Resources.cancel_mark;
                            EnemyPositionButtons[index].BackColor = Color.LightBlue;
                            EnemyPlayTimer.Start();
                        }

                    }
               

            }
            else
            {
                MessageBox.Show("Choose a location from the drop down first", "Information");
            }

        }

        private void PlayerPositionButtonEvent(object sender, EventArgs e)
        {
            if (totalShip > 0)
            {
                var button = (Button)sender;

                button.Enabled = false;
                button.Tag = "PlayerShip";
                totalShip -= 1;
            }

            if (totalShip == 0)
            {
                btnAttack.Enabled = true;
                btnAttack.BackColor = Color.Red;
                btnAttack.ForeColor = Color.White;

                TxtHelp.Text = "2) now pick the attack position from the drop down list";
            }
        }

        

        private void RestartGame()
        {
            playerPositionButtons = new List<Button> { K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, L1, L2, L3, L4, L5, L6, L7, L8, L9, L10, M1, M2, M3, M4, M5, M6, M7, M8, M9, M10, N1, N2, N3, N4, N5, N6, N7, N8, N9, N10, O1, O2, O3, O4, O5, O6, O7, O8, O9, O10,
             P1, P2, P3, P4, P5, P6, P7, P8, P9, P10,  Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9, Q10,  R1, R2, R3, R4, R5, R6, R7, R8, R9, R10, S1, S2, S3, S4, S5, S6, S7, S8, S9, S10, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10 };


            EnemyPositionButtons = new List<Button> {A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, D1, D2, D3, D4, D5, D6, D7, D8, D9, D10, E1, E2, E3, E4, E5, E6, E7, E8, E9, E10,
            F1, F2, F3, F4, F5, F6, F7, F8, F9, F10, G1, G2, G3, G4, G5, G6, G7, G8, G9, G10, H1, H2, H3, H4, H5, H6, H7, H8, H9, H10, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, J1, J2, J3, J4, J5, J6, J7, J8, J9, J10 };

            EnemyLocationListBox.Items.Clear();

            EnemyLocationListBox.Text = null;



            TxtHelp.Text = "1) Click on the ten different location from above to start!";

            for (int i = 0; i < EnemyPositionButtons.Count; i++)
            {
                EnemyPositionButtons[i].Enabled = true;
                EnemyPositionButtons[i].Tag = null;
                EnemyPositionButtons[i].BackColor = Color.LightBlue;
                EnemyLocationListBox.Items.Add(EnemyPositionButtons[i].Text);
            }

            for (int i = 0; i < playerPositionButtons.Count; i++)
            {
                playerPositionButtons[i].Enabled = true;
                playerPositionButtons[i].Tag = null;
                playerPositionButtons[i].BackColor = Color.LightBlue;
                playerPositionButtons[i].BackgroundImage = null;

            }

            playerScore = 0;
            enemyScore = 0;
            round = 20;
            totalShip = 10;

            txtPlayer.Text = playerScore.ToString();
            txtEnemy.Text = enemyScore.ToString();
            enemyMoves.Text = "A1";

            btnAttack.Enabled = false;

            EnemyLocationPicker();

            
        } 

        private void EnemyLocationPicker()
        {
            for (int i = 0; i < 3; i++)
            {
                int index = rand.Next(EnemyPositionButtons.Count);

                if (EnemyPositionButtons[index].Enabled == true && (string)EnemyPositionButtons[index].Tag == null)
                {
                    EnemyPositionButtons[index].Tag = "enemyShip";

                    Debug.WriteLine("Enemy Position: " + EnemyPositionButtons[index].Text);
                }
                else
                {
                    index = rand.Next(EnemyPositionButtons.Count);
                }

            
            }
        
        }

    }
}
