using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Lab3
{
    public partial class Form1 : Form
    {
        private ArrayList circles = new ArrayList();
        public int radius = 20;
        private int circ_num = 0;
             
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if( e.Button == MouseButtons.Left )
            {
                circ_num++;
                Point p = new Point(e.X, e.Y);
                rbCircle c = new Lab3.Form1.rbCircle(p);
                this.circles.Add(c);
            }

            if( e.Button == MouseButtons.Right )
            {
                foreach (rbCircle C in this.circles)
                {
                    if (C.is_clicked(e.X, e.Y))
                    { 
                        if (C.color == 0)
                        {
                            C.color = 1;
                        }
                        else
                        {
                            circles.Remove(C);
                        }
                    }   
                }
            }

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach( rbCircle C in circles )
            {
                if( C.color == 0 )
                {
                    g.FillEllipse(Brushes.Black, C.position.X - radius / 2, C.position.Y - radius / 2);
                }
            }

        }

        public class rbCircle
        {
            public int color; // 0 is black and 1 is red
            public Point position; 

            public rbCircle( Point p )
            {
                color = 0; //when a circle is first drawn, it is always black
                position = new Point(p.X, p.Y);
            }

            public void change_color()
            {
                color = 1;
            }

            public bool is_clicked( int x, int y )
            {
                int d = (position.X - x) ^ 2 + (position.Y - y) ^ 2;
                if( d <= radius^2 )
                {
                    return true;
                }
                return false;
            }
        }
    }
}
