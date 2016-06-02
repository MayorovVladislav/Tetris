using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetrisLib
{
    class Board
    {
        int rows, columns;
        Figure figure;
        Label[,] block;
        public int Score { set; get; }
        Color colorBackground = Color.Gray;

        public Board(TableLayoutPanel table, Label[,] block)
        {
            rows = table.RowCount;
            columns = table.ColumnCount;
            this.block = block;
            figure = new Figure();
            FigureShow();
        }

        void FigureShow()
        {
            Point position = figure.CurrentPosition;
            Point[] shape = figure.CurrentShape;
            Color color = figure.Color;
            for (int i = 0; i < shape.GetLength(0); i++)
                block[shape[i].X + position.X - 1 + ((columns / 2)),
                    shape[i].Y + position.Y + 1].BackColor = color;
        }
        void FigureHide()
        {
            Point position = figure.CurrentPosition;
            Point[] shape = figure.CurrentShape;
            Color color = figure.Color;
            for (int i = 0; i < shape.GetLength(0); i++)
                block[shape[i].X + position.X + ((columns / 2) - 1),
                        shape[i].Y + position.Y + 1].BackColor = Color.Gray;
        }


        public bool MoveDown()
        {
            Point position = figure.CurrentPosition;
            Point[] shape = figure.CurrentShape;
            FigureHide();
            bool show = true, move = true;
            for (int i = 0; i < shape.GetLength(0); i++)
                if ((shape[i].Y + position.Y) + 2 >= rows)
                    move = false;
                else if (block[((shape[i].X + position.X) + ((columns / 2) - 1)), (shape[i].Y + position.Y) + 2].BackColor != colorBackground)
                    move = false;
            if (move)
            {
                figure.MoveDown();
                FigureShow();
                return show;
            }
            else
            {
                FigureShow();
                CheckRow();
                for (int i = 1; i < 3; i++)
                    for (int j = 2; j < 6; j++)
                        if (block[j, i].BackColor != colorBackground)
                            show = false;
                if (show)
                {
                    figure = new Figure();
                    return show;
                }
                else
                {
                    return show;
                }
            }
        }
        public void MoveLeft()
        {
            Point position = figure.CurrentPosition;
            Point[] shape = figure.CurrentShape;
            Color color = figure.Color;
            FigureHide();
            bool move = true;
            for (int i = 0; i < shape.GetLength(0); i++)
                if (((shape[i].X + position.X) + ((columns / 2) - 1) - 1) < 0)
                    move = false;
                else
                    if (block[((shape[i].X + position.X) + ((columns / 2) - 1) - 1),
                        (shape[i].Y + position.Y) + 1].BackColor != colorBackground)
                    move = false;
            if (move)
            {
                figure.MoveLeft();
                FigureShow();
            }
            else
            {
                FigureShow();
            }
        }
        public void MoveRight()
        {
            Point position = figure.CurrentPosition;
            Point[] shape = figure.CurrentShape;
            FigureHide();

            bool move = true;
            for (int i = 0; i < shape.GetLength(0); i++)
                if (((shape[i].X + position.X) + ((columns / 2) - 1) + 1) >= columns)
                    move = false;
                else
                    if (block[((shape[i].X + position.X) + ((columns / 2) - 1) + 1),
                        (shape[i].Y + position.Y) + 1].BackColor != colorBackground)
                    move = false;
            if (move)
            {
                figure.MoveRight();
                FigureShow();
            }
            else
            {
                FigureShow();
            }
        }
        public void MoveRotate()
        {
            Point position = figure.CurrentPosition;
            Point[] shape = figure.CurrentShape;
            FigureHide();
            Point[] p = new Point[4];
            shape.CopyTo(p, 0);
            bool move = true;

            for (int i = 0; i < p.Length; i++)
            {
                int x = p[i].X;
                p[i].X = p[i].Y * -1;
                p[i].Y = x;

                if ((p[i].Y + position.Y) + 2 >= rows)
                {
                    move = false;
                }
                else
                if (((p[i].X + position.X) + ((columns / 2) - 1)) < 0)
                {
                    move = false;
                }
                else
                if (((p[i].X + position.X) + ((columns / 2) - 1)) >= columns)
                {
                    move = false;
                }
                else
                     if (block[((p[i].X + position.X) + ((columns / 2) - 1)),
                        (p[i].Y + position.Y) + 2].BackColor != colorBackground)
                {
                    move = false;
                }
            }
            if (move)
            {
                figure.MoveRotate();
                FigureShow();
            }
            else
            {
                FigureShow();
            }


        }

        public void CheckRow()
        {
            bool full;
            for (int i = rows - 1; i > 0; i--)
            {
                full = true;
                for (int j = 0; j < columns; j++)
                {
                    if (block[j, i].BackColor == colorBackground)
                        full = false;
                }
                if (full)
                {
                    Score += 100;
                    RemoveRow(i);
                    i++;//повторный проход по строке
                }
            }
        }
        public void RemoveRow(int row)
        {
            for (int i = row; i > 1; i--)
                for (int j = 0; j < columns; j++)
                    block[j, i].BackColor = block[j, i - 1].BackColor;
        }
    }
}
