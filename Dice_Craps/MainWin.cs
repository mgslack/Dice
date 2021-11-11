using System;
using System.Drawing;
using System.Windows.Forms;

/*
 * Example (test) program using the Dice (Die) component. Sets up and plays a
 * simple game of craps.
 * DieColor is specific to this example program, though could be used to
 * create color packages for other programs to use. Default color is the
 * color set in the designer for the dice. Normally default is black on white.
 *
 * Author:  M. G. Slack
 * Written: 2014-01-29
 * Version: 1.0.0.0
 *
 * ----------------------------------------------------------------------------
 * 
 * Updated: 2014-02-28 - Set win/lose (winner/craps) message in label across
 *                       Die faces. Reset INIT_MSG to message line label.
 *
 */
namespace Dice_Craps
{
    public enum DieColor { Default, White, Gray, Black, Red, Blue, Green, Yellow };

    public partial class MainWin : Form
    {
        private const string INIT_MSG = "7 or 11 win; 2, 3, or 12 crap out.";
        private const string PT_MSG = " wins and 7 craps out.";
        private const string WIN_MSG = "WINNER!";
        private const string LOSE_MSG = "CRAPS!";

        private int point = 0, wins = 0, losses = 0;
        private Color defFore, defBack;

        // --------------------------------------------------------------------

        private void CheckResults(int d1, int d2)
        {
            string msg = "";

            lblMessage.Text = INIT_MSG;

            if (point == 0) {
                point = d1 + d2;
                if ((point == 7) || (point == 11)) msg = WIN_MSG;
                if ((point < 4) || (point == 12)) msg = LOSE_MSG;
            }
            else {
                if (d1 + d2 == point) msg = WIN_MSG;
                if (d1 + d2 == 7) msg = LOSE_MSG;
            }

            if (msg == WIN_MSG) {
                wins++; lblWins.Text = Convert.ToString(wins);
                point = 0;
            }
            else if (msg == LOSE_MSG) {
                losses++; lblLosses.Text = Convert.ToString(losses);
                point = 0;
            }
            else {
                lblMessage.Text = Convert.ToString(point) + PT_MSG;
            }

            if (!String.IsNullOrEmpty(msg)) {
                DoneLbl.Visible = true;
                DoneLbl.Text = msg;
            }
        }

        // --------------------------------------------------------------------

        public MainWin()
        {
            InitializeComponent();
        }

        private void MainWin_Load(object sender, EventArgs e)
        {
            lblMessage.Text = INIT_MSG;
            defFore = die1.ForeColor;
            defBack = die1.BackColor;

            foreach (string name in Enum.GetNames(typeof(DieColor)))
                cbDiceColor.Items.Add(name);
            cbDiceColor.SelectedIndex = 0;

            foreach (string name in Enum.GetNames(typeof(Dice.DieRotation)))
                cbRotate.Items.Add(name);
            cbRotate.SelectedIndex = 0;
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            DoneLbl.Visible = false;
            die1.RollDie();
            die2.RollDie();
            CheckResults(die1.Value, die2.Value);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbDiceColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Color fore = defFore, back = defBack;

            switch (cbDiceColor.SelectedIndex) {
                case 0: back = defBack; fore = defFore; break;
                case 1: back = Color.White; fore = Color.Black; break;
                case 2: back = Color.Gray; fore = Color.Black; break;
                case 3: back = Color.Black; fore = Color.White; break;
                case 4: back = Color.Red; fore = Color.White; break;
                case 5: back = Color.Blue; fore = Color.White; break;
                case 6: back = Color.Green; fore = Color.White; break;
                case 7: back = Color.Yellow; fore = Color.Black; break;
            }

            die1.BackColor = back; die1.ForeColor = fore;
            die2.BackColor = back; die2.ForeColor = fore;
        }

        private void cbRotate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dice.DieRotation rotate = (Dice.DieRotation) cbRotate.SelectedIndex;
            die1.Rotation = rotate;
            die2.Rotation = rotate;
        }
    }
}
