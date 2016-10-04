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
        private ArrayList remove_rbc = new ArrayList(); //holds the indicies of which circles to eliminate
        public static int diameter = 20;
        public static int radius = 10;
        public int delete_i; //holds index of which cirlce to delete

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

            if (e.Button == MouseButtons.Right)
            {
                //checks if the circle is black or red and takes the appropriate action
                //black->red
                //red->delete
                int new_count = circ_num;
                for (int i = 0; i < circ_num; i++)
                {
                    if ((circles[i] as rbCircle).is_clicked(e.X, e.Y))
                    {
                        (circles[i] as rbCircle).mod_circle();
                    }

                }
            }
            Invalidate();
            

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //remove off circles and paint
            Graphics g = e.Graphics;
            delete_i = 0;
            foreach( rbCircle C in circles )
            {
                if( C.color == 0 && C.on )
                {
                    g.FillEllipse(Brushes.Black, C.position.X , C.position.Y , diameter, diameter);
                }
                else if( C.on )
                {
                    g.FillEllipse(Brushes.Red, C.position.X , C.position.Y , diameter, diameter );
                }
                else
                {
                    remove_rbc.Add(delete_i);
                }
                delete_i++;
       
            }

            foreach( int x in remove_rbc )
            {
                circles.Remove(x);
            }

        }

        public class rbCircle
        {
            public int color; // 0 is black and 1 is red
            public bool on; // if true -- paint the circle, else don't
            public Point position; 

            public rbCircle( Point p )
            {
                color = 0; //when a circle is first drawn, it is always black
                position = new Point(p.X - radius, p.Y - radius);
                on = true;
            }

            public void change_color()
            {
                color = 1;
            }

            public bool is_clicked( int x, int y )
            {
                double dx = (double)(position.X + radius - x);
                double dy = (double)(position.Y + radius - y);
                double d = Math.Pow(dx, 2) + Math.Pow(dy, 2);
                d = Math.Sqrt(d);
                if( radius > d )
                {
                    return true;
                }
                return false;
            }

            public void mod_circle( )
            {
                if (color == 0)
                {
                    color = 1;
                }
                else
                {
                    on = false;
                }
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            circles.Clear();
            Invalidate();
        }
    }
}
