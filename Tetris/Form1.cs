using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using TetrisLib;

namespace Tetris
{
    public partial class Form1 : Form
    {
        Board b;
        Label[,] block;
        int lvl = 1;
        public Form1()
        {
            InitializeComponent();
            block = new Label[tableLayoutPanel1.ColumnCount, tableLayoutPanel1.RowCount];
            for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
            {
                for (int j = 0; j < tableLayoutPanel1.RowCount; j++)
                {
                    block[i, j] = new Label();
                    block[i, j].AutoSize = false;
                    block[i, j].Height = 25;
                    block[i, j].BackColor = Color.Gray;
                    //block[i, j].Name = $"{i},{j}";
                    //block[i, j].Text = $"{block[i, j].Name}";
                    block[i, j].BorderStyle = BorderStyle.FixedSingle;
                    tableLayoutPanel1.Controls.Add(block[i, j], i, j);
                }
            }
            StartGame();
            label1.Text = b.Score.ToString();
            label2.Text = $"Уровень {lvl.ToString()}";
        }
        private void StartGame()
        {
            b = new Board(tableLayoutPanel1, block);

            timer1.Tick += Timer1_Tick;
            timer1.Start();
            timer1.Interval = 1000;
        }
        private void NewStartGame()
        {
            timer1.Stop();
            timer1.Tick -= Timer1_Tick;
            for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
                for (int j = 0; j < tableLayoutPanel1.RowCount; j++)
                    block[i, j].BackColor = Color.Gray;
            StartGame();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = b.Score.ToString();
            label2.Text = $"Уровень {lvl.ToString()}";
            if (b.MoveDown())
            {
                if (b.Score == 1000)
                {
                    lvl = 2;
                    timer1.Interval = 900;
                }
                else
                if (b.Score == 2000)
                {
                    lvl = 3;
                    timer1.Interval = 800;
                }
                else

                if (b.Score == 4000)
                {
                    lvl = 4;
                    timer1.Interval = 700;
                }
                else
                if (b.Score == 5000)
                {
                    lvl = 5;
                    timer1.Interval = 600;
                }
                else
                if (b.Score == 6000)
                {
                    lvl = 6;

                    timer1.Interval = 500;
                }
                if (b.Score == 7000)
                {
                    lvl = 7;

                    timer1.Interval = 400;
                }
                else

                if (b.Score == 8000)
                {
                    lvl = 8;

                    timer1.Interval = 300;
                }
                else

                if (b.Score == 9000)
                {
                    lvl = 9;
                    timer1.Interval = 200;
                }
            }
            else
            {
                timer1.Stop();
                DialogResult result = MessageBox.Show("Игра окончена\nХотите начать новую?", "", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    NewStartGame();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Left:
                    b.MoveLeft();
                    break;
                case Keys.Up:
                    b.MoveRotate();
                    break;
                case Keys.Right:
                    b.MoveRight();
                    break;
                case Keys.Down:
                    for (int i = 0; i < 5; i++)
                    {
                        b.MoveDown();
                    }
                    break;
                case Keys.F3:
                    NewStartGame();
                    break;
                case Keys.Escape:
                    if (timer1.Enabled)
                        timer1.Stop();
                    else timer1.Start();
                    break;

                default:
                    break;
            }
        }

    }
}
