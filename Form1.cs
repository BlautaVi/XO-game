using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LittleGame_XO_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResetGame();
            button10.Text = "🔄️";
            this.Width = 550;
            this.Height = 550;
        }
        bool Turn = true;
        int turnCount = 0;

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (Turn)
                b.Text = "X";
            else
                b.Text = "O";

            Turn = !Turn;
            b.Enabled = false;
            turnCount++;
            CheckForWinner();
        }
        private void CheckForWinner()
        {
            bool isWinner = false;
            if ((button1.Text == button2.Text) && (button2.Text == button3.Text) && (!button1.Enabled))
                isWinner = true;
            else if ((button4.Text == button5.Text) && (button5.Text == button6.Text) && (!button4.Enabled))
                isWinner = true;
            else if ((button7.Text == button8.Text) && (button8.Text == button9.Text) && (!button7.Enabled))
                isWinner = true;
            if ((button1.Text == button4.Text) && (button4.Text == button7.Text) && (!button1.Enabled))
                isWinner = true;
            else if ((button2.Text == button5.Text) && (button5.Text == button8.Text) && (!button2.Enabled))
                isWinner = true;
            else if ((button3.Text == button6.Text) && (button6.Text == button9.Text) && (!button3.Enabled))
                isWinner = true;
            if ((button1.Text == button5.Text) && (button5.Text == button9.Text) && (!button1.Enabled))
                isWinner = true;
            else if ((button3.Text == button5.Text) && (button5.Text == button7.Text) && (!button3.Enabled))
                isWinner = true;

            if (isWinner)
            {
                DisableButtons();
                string winner = Turn ? "O" : "X";
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false; 
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                label1.Text = winner + " переміг!";
            }
            else if (turnCount == 9)
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                label1.Text = "Нічия!";
            }
        }
        private void DisableButtons()
        {
            foreach (Control c in Controls)
            {
                if (c is Button && c.Name != "button10")
                {
                    c.Enabled = false;
                }
            }
        }
        private void ResetGame()
        {
            Turn = true;
            turnCount = 0;
            label1.Text = "";

            foreach (Control c in Controls)
            {
                if (c is Button && c.Name != "resetButton")
                {
                    c.Enabled = true;
                    c.Text = "";
                }
            }
            button10.Text = "🔄️";
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
        }
       
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ResetGame();
        }
    }
}
