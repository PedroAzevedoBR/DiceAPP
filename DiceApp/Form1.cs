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
        
    }
}
