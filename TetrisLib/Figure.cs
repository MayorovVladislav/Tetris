using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisLib
{
    class Figure
    {
        Point currentPosition;
        Point[] currentShape;
        Color color;
        bool rotate;

        //свойства
        public Point CurrentPosition
        {
            get
            {
                return currentPosition;
            }

            private set
            {
                currentPosition = value;
            }
        }

        public Point[] CurrentShape
        {
            get
            {
                return currentShape;
            }

            private set
            {
                currentShape = value;
            }
        }

        public Color Color
        {
            get
            {
                return color;
            }

            private set
            {
                color = value;
            }
        }

        public bool Rotate
        {
            get
            {
                return rotate;
            }

            private set
            {
                rotate = value;
            }
        }




        public Figure()
        {
            currentPosition = new Point(0, 0);
            currentShape = RandomShape();
        }

        Point[] RandomShape()
        {
            Random rand = new Random();
            switch (rand.Next() % 7)
            {
                case 0: //I
                    Rotate = true;
                    Color = Color.Cyan;
                    return new Point[] {
                        new Point(0,-1),
                        new Point(-1,-1),
                        new Point(1,-1),
                        new Point(2,-1)
                    };
                case 1: //J
                    Rotate = true;
                    Color = Color.Blue;
                    return new Point[] {
                        new Point(1,-1),
                        new Point(-1,0),
                        new Point(0,0),
                        new Point(1,0)
                    };
                case 2: //L
                    Rotate = true;
                    Color = Color.Orange;
                    return new Point[] {
                        new Point(0,0),
                        new Point(-1,0),
                        new Point(1,0),
                        new Point(-1,-1)
                    };
                case 3: //Q
                    Rotate = false;
                    Color = Color.Yellow;
                    return new Point[] {
                        new Point(1,-1),
                        new Point(1,0),
                        new Point(0,-1),
                        new Point(0,0)
                    };
                case 4: //S
                    Rotate = true;
                    Color = Color.Green; ;
                    return new Point[] {
                        new Point(0,0),
                        new Point(1,0),
                        new Point(1,-1),
                        new Point(2,0)
                    };
                case 5: //T
                    Rotate = true;
                    Color = Color.Purple;
                    return new Point[] {
                        new Point(0,0),
                        new Point(-1,0),
                        new Point(0,-1),
                        new Point(1,-1)
                    };
                case 6: //Z
                    Rotate = true;
                    Color = Color.Red;
                    return new Point[] {
                        new Point(0,-1),
                        new Point(-1,-1),
                        new Point(0,0),
                        new Point(1,0)
                    };
                default:
                    return null;
            }
        }


        //сдвиги

        public void MoveRight()
        {
            currentPosition.X += 1;
        }
        public void MoveLeft()
        {
            currentPosition.X -= 1;
        }
        public void MoveDown()
        {
            currentPosition.Y += 1;
        }
        public void MoveRotate()
        {
            if (rotate)
                for (int i = 0; i < currentShape.Length; i++)
                {
                    int p = currentShape[i].X;
                    currentShape[i].X = currentShape[i].Y * -1;
                    currentShape[i].Y = p;
                }


        }
    }
}
