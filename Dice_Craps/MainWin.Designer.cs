namespace Dice_Craps
{
    partial class MainWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.DoneLbl = new System.Windows.Forms.Label();
            this.die2 = new Dice.Die();
            this.die1 = new Dice.Die();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblWins = new System.Windows.Forms.Label();
            this.lblLosses = new System.Windows.Forms.Label();
            this.btnRoll = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbDiceColor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbRotate = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OliveDrab;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.DoneLbl);
            this.panel1.Controls.Add(this.die2);
            this.panel1.Controls.Add(this.die1);
            this.panel1.Location = new System.Drawing.Point(24, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(172, 93);
            this.panel1.TabIndex = 0;
            // 
            // DoneLbl
            // 
            this.DoneLbl.AutoSize = true;
            this.DoneLbl.BackColor = System.Drawing.Color.Transparent;
            this.DoneLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoneLbl.ForeColor = System.Drawing.Color.LightBlue;
            this.DoneLbl.Location = new System.Drawing.Point(52, 37);
            this.DoneLbl.Name = "DoneLbl";
            this.DoneLbl.Size = new System.Drawing.Size(11, 13);
            this.DoneLbl.TabIndex = 2;
            this.DoneLbl.Text = "!";
            this.DoneLbl.Visible = false;
            // 
            // die2
            // 
            this.die2.BackColor = System.Drawing.Color.Purple;
            this.die2.BorderColor = System.Drawing.Color.Gold;
            this.die2.CornerRadius = 6;
            this.die2.Face = Dice.DieFace.dfn0;
            this.die2.ForeColor = System.Drawing.Color.Gold;
            this.die2.Location = new System.Drawing.Point(92, 13);
            this.die2.MaxFaces = Dice.DieFace.dfn6;
            this.die2.Name = "die2";
            this.die2.Rotation = Dice.DieRotation.Default;
            this.die2.RoundedCorners = true;
            this.die2.Size = new System.Drawing.Size(60, 60);
            this.die2.TabIndex = 1;
            // 
            // die1
            // 
            this.die1.BackColor = System.Drawing.Color.Purple;
            this.die1.BorderColor = System.Drawing.Color.Gold;
            this.die1.CornerRadius = 6;
            this.die1.Face = Dice.DieFace.dfn0;
            this.die1.ForeColor = System.Drawing.Color.Gold;
            this.die1.Location = new System.Drawing.Point(13, 13);
            this.die1.MaxFaces = Dice.DieFace.dfn6;
            this.die1.Name = "die1";
            this.die1.Rotation = Dice.DieRotation.Default;
            this.die1.RoundedCorners = true;
            this.die1.Size = new System.Drawing.Size(60, 60);
            this.die1.TabIndex = 0;
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(12, 117);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(199, 13);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "<>";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of wins:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Number of losses:";
            // 
            // lblWins
            // 
            this.lblWins.AutoSize = true;
            this.lblWins.Location = new System.Drawing.Point(109, 139);
            this.lblWins.Name = "lblWins";
            this.lblWins.Size = new System.Drawing.Size(13, 13);
            this.lblWins.TabIndex = 3;
            this.lblWins.Text = "0";
            // 
            // lblLosses
            // 
            this.lblLosses.AutoSize = true;
            this.lblLosses.Location = new System.Drawing.Point(109, 152);
            this.lblLosses.Name = "lblLosses";
            this.lblLosses.Size = new System.Drawing.Size(13, 13);
            this.lblLosses.TabIndex = 5;
            this.lblLosses.Text = "0";
            // 
            // btnRoll
            // 
            this.btnRoll.Location = new System.Drawing.Point(12, 215);
            this.btnRoll.Name = "btnRoll";
            this.btnRoll.Size = new System.Drawing.Size(75, 23);
            this.btnRoll.TabIndex = 6;
            this.btnRoll.Text = "&Roll";
            this.btnRoll.UseVisualStyleBackColor = true;
            this.btnRoll.Click += new System.EventHandler(this.btnRoll_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(136, 215);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "&Dice Color:";
            // 
            // cbDiceColor
            // 
            this.cbDiceColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDiceColor.FormattingEnabled = true;
            this.cbDiceColor.Location = new System.Drawing.Point(24, 186);
            this.cbDiceColor.Name = "cbDiceColor";
            this.cbDiceColor.Size = new System.Drawing.Size(60, 21);
            this.cbDiceColor.TabIndex = 9;
            this.cbDiceColor.SelectedIndexChanged += new System.EventHandler(this.cbDiceColor_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ro&tation:";
            // 
            // cbRotate
            // 
            this.cbRotate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRotate.FormattingEnabled = true;
            this.cbRotate.Location = new System.Drawing.Point(103, 186);
            this.cbRotate.Name = "cbRotate";
            this.cbRotate.Size = new System.Drawing.Size(98, 21);
            this.cbRotate.TabIndex = 11;
            this.cbRotate.SelectedIndexChanged += new System.EventHandler(this.cbRotate_SelectedIndexChanged);
            // 
            // MainWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 247);
            this.Controls.Add(this.cbRotate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbDiceColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRoll);
            this.Controls.Add(this.lblLosses);
            this.Controls.Add(this.lblWins);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Craps";
            this.Load += new System.EventHandler(this.MainWin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Dice.Die die2;
        private Dice.Die die1;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblWins;
        private System.Windows.Forms.Label lblLosses;
        private System.Windows.Forms.Button btnRoll;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbDiceColor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbRotate;
        private System.Windows.Forms.Label DoneLbl;
    }
}

