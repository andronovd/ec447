using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        private ArrayList squares = new ArrayList();
        private short size = 8;     //squares to a side
        private short total = 64;   //total squares

        public Form1()
        {
            InitializeComponent();
            //change the initialize size of the window
            this.Size = new Size(600, 600);
            //populate the squares array with squares
            short i = 0;
            bool border = false;
            for (; i < total; i++)
            {
                if( ((i % 8) == 0) || ( i < 8 ) || i > 55 || (i%8 == 7))
                {
                    Console.WriteLine("Square No." + i.ToString() + " is a border square.");
                    border = true;
                }
                Square s = new Square( border);
                squares.Add(s);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //draw the board
            //First, some settings
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 2); //pen for drawing the border
            pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Outset; //alignment of the border
            Font f = new Font("Arial", 30, FontStyle.Bold);
            
            for( short i = 0; i < 8; i++ )
            {
                for( short j = 0; j < size; j++ )
                {
                    Rectangle r = new Rectangle(100 + 50 * j, 100 + 50 * i, 50, 50);
                    g.DrawRectangle(pen, r);
                    Square s = (Square)squares[size * i + j];

                    //if color is 0
                    SolidBrush fill = new SolidBrush( Color.White );
                    SolidBrush Q = new SolidBrush(Color.Black);
                    if (s.color == 1)
                    {
                        fill.Color = Color.Black;
                        Q.Color = Color.White;
                    }
                    else if( s.color == 2 & s.inRange)
                    {
                        fill.Color = Color.Red;
                    }
                    g.FillRectangle(fill, r);

                    //Draw in the Queens
                    if (s.queen)
                    {
                        g.DrawString("Q", f, Q, r);
                    }

                    fill.Dispose();
                    Q.Dispose();
                }
            }
            f.Dispose();
            pen.Dispose();
        }

        public class Square
        {
            //this is a square tile on the chess board.
            //it can be either black or white
            //it will only turn red when Hints are on and it is in range of a queen

            //--public vars
            public short color;  // 0 = black, 1 = white, 2 = red
            public bool queen;   //is there a queen on it?
            public bool inRange; //is in range of a queen
            public bool isBorder;

            //--static vars
            private static short numSquares = 0;
            private static short row = 0;    //false = even row, true = odd row

            public Square( bool b)
            {
                if( (numSquares % 8 == 0 ) )
                {
                    row++;
                }

                this.color = (short)((row&1) ^ (numSquares & 1));
                this.queen = false;
                this.isBorder = b;
                numSquares++;
            }

            public void changeColor( short color )
            {
                this.color = color;
            }

            public void placeQueen()
            {
                this.queen = true;
            }     
            
            public void removeQueen()
            {
                this.queen = false;
            }     
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            short elem;
            if (isSquare(e))
            {
                elem = whichSquare(e);
                Square s = (Square)squares[elem];
                if (e.Button == MouseButtons.Left)
                {
                    //get the element location of the square that was clicked
                    s.placeQueen();
                }
                else if (e.Button == MouseButtons.Right)
                {
                    s.removeQueen();
                }
                CheckQueens(elem);
                Invalidate();
            }
        }

        public bool isSquare(MouseEventArgs e)
        {
            //checks if the button clicked on a square
            //get the coord. of where the mouse clicked
            double x = e.X;
            double y = e.Y;
            //Console.WriteLine("You clicked at (" + x.ToString() + ", " + y.ToString() + ").");
            //see if mouse clicked on the board
            bool xValid = (x > 99) & (x < 501);
            bool yValid = (y > 99) & (y < 501);

            if (xValid & yValid)
            {
                //mouse clicked on the board
                return true;
            }
            return false;
        }

        public short whichSquare( MouseEventArgs e)
        {
            //returns the element of the square tile on the board that was clicked in the squares arraylist
            double x = e.X;
            double y = e.Y;
            x = Math.Floor((x - 100) / 50);
            y = Math.Floor((y - 100) / 50);
            short elem = (short)(size * y + x);
            return elem;
        }

        public void CheckQueens(short elem)
        {
            //After each time a queen is placed, each sqare is checked if it
            //is within striking range of a queen
            //need to check 8 directions
            //up,down -> +/- 8
            //left,right -> +/- 1
            //diagonal 1 -> +/- 9
            //diagonal 2 -> +/- 7
            ArrayList elems = new ArrayList();
            short temp = elem;

            //check up
            while( true )
            {
                if( ((Square)squares[temp]).isBorder )
                {
                    break;
                }
                temp += 5;
                elems.Add(temp);
            }

            //check down
            temp = elem;
            while( true )
            {
                if (((Square)squares[temp]).isBorder)
                {
                    break;
                }
                temp -= 5;
                elems.Add(temp);
            }

            //check left
            temp = elem;
            while( true )
            {
                if (((Square)squares[temp]).isBorder)
                {
                    break;
                }
                temp -= 1;
                elems.Add(temp);
            }

            //check right
            temp = elem;
            while( true )
            {
                if (((Square)squares[temp]).isBorder)
                {
                    break;
                }
                temp += 1;
                elems.Add(temp);
            }

            //check up & right
            temp = elem;
            while( true )
            {
                if (((Square)squares[temp]).isBorder)
                {
                    break;
                }
                temp -=7;
                elems.Add(temp);
            }

            //check down & left
            temp = elem;
            while( true )
            {
                if (((Square)squares[temp]).isBorder)
                {
                    break;
                }
                temp += 7;
                elems.Add(temp);
            }

            //check up & left
            temp = elem;
            while( true )
            {
                if (((Square)squares[temp]).isBorder)
                {
                    break;
                }
                temp -= 9;
                elems.Add(temp);
            }

            //check down & right
            temp = elem;
            while( true )
            {
                if (((Square)squares[temp]).isBorder)
                {
                    break;
                }
                temp += 7;
                elems.Add(temp);
            }

            //now elems should contain all the elements of those square that are in the queen's range.
            Console.WriteLine("found " + elems.Capacity.ToString() + " elements in range.");
            foreach( short s in elems )
            {
                ((Square)squares[s]).inRange = true;
            }
        }
    }
}
