using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiceApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Jogador 1";
            label2.Text = "Jogador 2";
            button1.Text = "Jogar";
            button2.Text = button1.Text;
            button1.Enabled = true;
            button2.Enabled = false;
            clean();
        }

        int amountFirstPlayer = 0; 
        int amountSecondPlayer = 0;
        Label result1, result2 = null;
        int partida = 0;
        
        private void cleanText(Label lbl) { lbl.Text = "";}

        private List<Label> createFirstPlayerScores()
        {
            List<Label> lstLabel = new List<Label>();
            lstLabel.Add(label3);
            lstLabel.Add(label6);
            lstLabel.Add(label9);
            return lstLabel;
        }

        private List<Label> createsecondPlayerScores()
        {
            List<Label> lstLabel = new List<Label>();
            lstLabel.Add(label5);
            lstLabel.Add(label8);
            lstLabel.Add(label11);
            return lstLabel;
        }

        private void clean()
        {
            foreach (Label lbl in createFirstPlayerScores()){ cleanText(lbl); }
            foreach (Label lbl in createsecondPlayerScores()){ cleanText(lbl); }
            label14.Text = "0";
            label12.Text = "";
            result1 = null;
            result2 = null;
            partida = 0;
            amountFirstPlayer = 0; 
            amountSecondPlayer = 0;  
        }

        private void updatePartida()
        {
            partida++;
            label14.Text = partida + "";
        }

        private void switchEnable()
        {
            if (button2.Enabled != button1.Enabled)
            {
                button1.Enabled = !button1.Enabled;
                button2.Enabled = !button1.Enabled;
            }
        }

        private void block_buttons() 
        {
            button2.Enabled = button1.Enabled;
        }

        private int randomize() 
        {
            Random rnd = new Random();
            return rnd.Next(1, 7);
        }

        private Label fill(List<Label> list)
        {
            foreach (Label lbl in list)
            {
                if (lbl.Text.Equals(""))
                {
                    lbl.Text = randomize() + "";
                    return lbl;
                }
            }
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result1 = fill(createFirstPlayerScores());
            switchEnable();            
        }


        private void endGame(int winner) 
        {
            DialogResult result = MessageBox.Show(this, "O jogador " + winner + " ganhou o jogo. Deseja jogar novamente?",
                                            "Fim de jogo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                clean();
            else
                block_buttons();
        }

        private void VerifyMatch(int amountP1, int amountP2) 
        {

            if (amountP1 == 2 || amountP2 == 2)
                endGame(amountP1 == 2 ? 1 : 2);
        }
        
        private void setColors(Label winner, Label loser)
        {
            winner.ForeColor = Color.Green;
            loser.ForeColor = Color.Red;
        }

        private void setWinnerLabel(int playerWinner)
        {
            label12.Text = playerWinner == 0 ? "EMPATE" : "Jogador " + playerWinner + " ganhou!";
        }

        private void partialResult(Label player1, Label player2)
        {
            int p1 = Convert.ToInt32(player1.Text);
            int p2 = Convert.ToInt32(player2.Text);
            if (p1 == p2)
            {
                cleanText(player1);
                cleanText(player2);
                setWinnerLabel(0);
            }
            else
            {
                if(p1 > p2)
                {
                    setColors(player1, player2);
                    amountFirstPlayer++;
                    setWinnerLabel(1);
                }
                else
                {
                    setColors(player2, player1);
                    amountSecondPlayer++;
                    setWinnerLabel(2);
                }
                VerifyMatch(amountFirstPlayer, amountSecondPlayer);
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updatePartida();
            result2 = fill(createsecondPlayerScores());
            partialResult(result1, result2);
            switchEnable();
        }
        
    }
}
