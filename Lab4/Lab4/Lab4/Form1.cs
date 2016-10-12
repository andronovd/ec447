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
            bool border;
            for (; i < total; i++)
            {
                border = false;
                if( ((i % 8) == 0) || ( i < 7 ) || i > 55 || (i%8 == 7))
                {
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
            
            for( short i = 0; i < 7; i++ )
            {
                for( short j = 0; j < size; j++ )
                {
                    Rectangle r = new Rectangle(100 + 50 * j, 100 + 50 * i, 50, 50);
                    g.DrawRectangle(pen, r);
                    Square s = (Square)squares[size * i + j];

                    //if color is 0
                    SolidBrush fill = new SolidBrush( Color.White );
                    SolidBrush Q = new SolidBrush(Color.Black);

                    if (s.inRange == true)
                    {
                        fill.Color = Color.Red;
                        s.color = 2;
                    }
                    else if (s.color == 1)
                    {
                        fill.Color = Color.Black;
                        Q.Color = Color.White;
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
            if (isSquare(e.X, e.Y))
            {
                elem = whichSquare(e.X, e.Y);
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

        public bool isSquare( double x, double y)
        {
            //checks if the button clicked on a square
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

        public short whichSquare( double x, double y)
        {
            //returns the element of the square tile on the board that was clicked in the squares arraylist
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

            //unpack elem
            short j = (short)(elem % 8);
            short i= (short)((elem - j)/8);
            short ti = i;
            short tj = j;
            short sum;

            Console.WriteLine("elem selected is at " + i.ToString() + ", " + j.ToString());

            //check up & left
            Console.WriteLine("Checking diagonals");
            while( ti > 0 && tj > 0 )
            {
                ti--;
                tj--;
                sum = (short)(8 * ti + tj);
                Console.WriteLine("8 * " + ti.ToString() + " + " + tj.ToString() + " = " + sum.ToString());
                elems.Add(sum);
                
            }

            ti = i;
            tj = j;
            //check up & right
            while(ti > 0 && tj < 7)
            {
                ti--;
                tj++;
                sum = (short)(8 * ti + tj);
                Console.WriteLine("8 * " + ti.ToString() + " + " + tj.ToString() + " = " + sum.ToString());
                elems.Add(sum);
                
            }

            ti = i;
            tj = j;
            //check down & left
            while (ti < 7 && tj > 0 )
            {
                ti++;
                tj--;
                sum = (short)(8 * ti + tj);
                Console.WriteLine("8 * " + ti.ToString() + " + " + tj.ToString() + " = " + sum.ToString());
                elems.Add(sum);
                
            }

            ti = i;
            tj = j;
            //check down & right
            while (ti < 7 && tj < 7)
            {
                ti++;
                tj++;
                sum = (short)(8 * ti + tj);
                Console.WriteLine("8 * " + ti.ToString() + " + " + tj.ToString() + " = " + sum.ToString());
                elems.Add(sum);
                
            }

            ti = i;
            tj = j;
            Console.WriteLine("Checking axes");
            //check up
            while (tj > 0)
            {
                tj--;
                sum = (short)(8 * ti + tj);
                Console.WriteLine("8 * " + ti.ToString() + " + " + tj.ToString() + " = " + sum.ToString());
                elems.Add(sum);
                
            }

            ti = i;
            tj = j;
            //check down
            while (tj < 7)
            {
                tj++;
                sum = (short)(8 * ti + tj);
                Console.WriteLine("8 * " + ti.ToString() + " + " + tj.ToString() + " = " + sum.ToString());
                elems.Add(sum);
                
            }

            ti = i;
            tj = j;
            //check left
            while ( ti > 0 )
            {
                ti--;
                sum = (short)(8 * ti + tj);
                Console.WriteLine("8 * " + ti.ToString() + " + " + tj.ToString() + " = " + sum.ToString());
                elems.Add(sum);
                
            }

            ti = i;
            tj = j;
            //check right
            while (ti < 7)
            {
                ti++;
                sum = (short)(8 * ti + tj);
                Console.WriteLine("8 * " + ti.ToString() + " + " + tj.ToString() + " = " + sum.ToString());
                elems.Add(sum);
                
            }


            //now elems should contain all the elements of those square that are in the queen's range.
            Console.WriteLine("found " + elems.Capacity.ToString() + " elements in range.");
            foreach( short s in elems)
            {
                Console.Write(s);
                Console.Write(" ");
            }
            Console.WriteLine();
            
            foreach( short s in elems )
            {
                ((Square)squares[s]).inRange = true;
            }
            elems.Clear();
            Invalidate();
        }
    }
}
