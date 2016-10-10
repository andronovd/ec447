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
            for (; i < total; i++)
            {
                Square s = new Square();
                squares.Add(s);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //draw the board
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 2);
            pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Outset;
            for( short i = 0; i < 8; i++ )
            {
                for( short j = 0; j < size; j++ )
                {
                    Rectangle r = new Rectangle(100 + 50 * j, 100 + 50 * i, 50, 50);
                    g.DrawRectangle(pen, r);
                    Square s = (Square)squares[size * i + j];
                    if (s.color == 0)
                    {
                        g.FillRectangle(Brushes.Black, r);
                    }
                    else if (s.color == 1)
                    {
                        g.FillRectangle(Brushes.White, r);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.Red, r);
                    }
                }
            }

        }

        public class Square
        {
            //this is a square tile on the chess board.
            //it can be either black or white
            //it will only turn red when Hints are on and it is in range of a queen

            public short color;  // 0 = black, 1 = white, 2 = red
            public bool queen;   //is there a queen on it?
            public bool inRange; //is in range of a queen
            private static short numSquares = 0;
            private static short row = 0;    //false = even row, true = odd row

            public Square( )
            {
                if( (numSquares % 8 == 0 ) )
                {
                    row++;
                }

                this.color = (short)((row&1) ^ (numSquares & 1));
                this.queen = false;
                numSquares++;
            }

            public void changeColor( short color )
            {
                this.color = color;
            }

            public void swapQueen()
            {
                this.queen = !this.queen;
            }          
        }
    }
}
