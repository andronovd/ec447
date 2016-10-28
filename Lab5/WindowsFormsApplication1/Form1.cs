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

namespace WindowsFormsApplication1
{
    public partial class Lab5 : Form
    {
        //ArrayList for container controls
        ArrayList draw_rbs = new ArrayList();
        
        //create the 3 labels for each selection
        Label pen_color = new Label();
        Label fill_color = new Label();
        Label pen_width = new Label();

        //create the 3 listboxes for each label

        //data arrrays for the listboxes
        private String[] pc_data = { "Black", "Red", "Blue", "Green" };
        private String[] fl_data = { "White", "Black", "Red", "Blue", "Green" };
        private int[] pw_data = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };


        //Variables
        //mouse state variable
        private bool mstate = true; //false -> first click, true ->second click
        //on right mouse click, the state var is flipped

        //graphics type state variable
        private short gtype = 0; //default -> 0, no type selected
        
        //graphics object arraylist
        ArrayList grry = new ArrayList();

        //corner points
        private Point c1 = new Point();
        private Point c2 = new Point();

        //pen used for drawing & brush for filling
        Pen pen = new Pen(Color.Black, 1);
        Brush brush = Brushes.White;

        //text box text;
        String tb_text;

        //drawing options
        short dopt = 0;





        public Lab5()
        {
            InitializeComponent();
            //change Form size
            Size s = new Size(600, 600);
            this.Size = s;

            //---The Draw GroupBox
            //generate the controls in the Draw GroupBox
            Point draw_startpoint = new Point(20, 20);
            
            //modify the radiobuttons & add them to the container
            line.Text = "Line";
            draw_rbs.Add(line);
            rect.Text = "Rectangle";
            draw_rbs.Add(rect);
            elip.Text = "Ellipse";
            draw_rbs.Add(elip);
            text.Text = "Text";
            draw_rbs.Add(text);

            //modify the textbox
            tb.Size = new Size(190, 65);
            tb.Multiline = true;
            tb.WordWrap = false;
            tb.ScrollBars = ScrollBars.Both;
            tb.AcceptsReturn = true;
            tb.Dock = DockStyle.Bottom & DockStyle.Right;
            draw_rbs.Add(tb);

            //add the radiobuttons to the groupbox
            foreach (Control c in draw_rbs)
            {
                draw_box.Controls.Add(c);
                c.Location = draw_startpoint;
                draw_startpoint.Y += 25;
            }
            
            Point panel_pos = new Point(260, 35);
            Point label_pt = new Point(0, 0);
            //--The PenColor Panel
            //add controls
            PenColor.Controls.Add(pen_color);
            PenColor.Controls.Add(pen_colors);
            //adjust controls for PenColor panel
            pen_color.Text = "Pen Color";
            pen_color.Location = label_pt;
            pen_colors.DataSource = pc_data;
            pen_colors.Height = 75;
            pen_colors.Dock = DockStyle.Bottom;

            //--The FillColor Panel
            //add controls
            FillColor.Controls.Add(fill_color);
            FillColor.Controls.Add(fill_colors);
            //adjust controls for FillColor Panel
            fill_color.Text = "Fill Color";
            fill_color.Location = label_pt;
            fill_colors.DataSource = fl_data;
            fill_colors.Height = 75;
            fill_colors.Dock = DockStyle.Bottom;

            //--The PenWidth Panel
            //add controls
            PenWidth.Controls.Add(pen_width);
            PenWidth.Controls.Add(pen_widths);
            //adjust controls for PenWidth
            pen_width.Text = "Pen Width";
            pen_width.Location = label_pt;
            pen_widths.DataSource = pw_data;
            pen_widths.Height = 140;
            pen_widths.Dock = DockStyle.Bottom;
        }

        //--CLASSES--//
        //graphics object class inheirited from the Graphic Class
        public class graphic
        {
            public Point loc1; //location of the 1st corner
            public Point loc2; //location of the 2nd corner
            public Pen gpen; //its color
            public Brushes gbrush;
            public short gdopt;

            public graphic()
            {
                loc1 = new Point(0, 0);
                loc2 = new Point(0, 0);
                gpen = new Pen(Color.Black, 1);
            }

            public graphic( Point loc1, Point loc2, Pen p )
            {
                this.loc1 = loc1;
                this.loc2 = loc2;
                this.gpen = p;
            }

            public virtual void Draw(Graphics g)
            { }

            protected bool isUpperCorner(Point p1, Point p2)
            {
                //returns which point in the the uper left corner, as we see it
                //false if p1
                //true if p2
                if ((p1.X <= p2.X) && (p1.Y <= p2.Y))
                {
                    Console.WriteLine(p1.ToString() + " is upper left of " + p2.ToString());
                    return true;
                }
                else
                {
                    Console.WriteLine(p2.ToString() + " is upper left of " + p1.ToString());
                    return false;
                }
            }
        }

        //line graphcis object class
        public class Line : graphic
        {
            //this is the line object
            public Line() { }
            public Line( Point loc1, Point loc2, Pen p )
            {
                this.loc1 = loc1;
                this.loc2 = loc2;
                this.gpen = (Pen)p.Clone();
            }

            override public void Draw( Graphics g )
            {
                g.DrawLine(this.gpen, loc1, loc2);
            }
        }

        //Rectangle graphics object class
        public class Rect : graphic
        {
            //this is the Rect object
            public int width;
            public int height;
            public Point loc; //location of the upper left corner

            public Rect() { }
            public Rect(Point loc1, Point loc2, Pen p, Brushes b, short options)
            {
                this.loc1 = loc1;
                this.loc2 = loc2;
                this.gpen = (Pen)p.Clone();
                this.gdopt = options;
                this.gbrush = b;
            }

            override public void Draw(Graphics g)
            {
                width = Math.Abs(loc1.X - loc2.X);
                height = Math.Abs(loc1.Y - loc2.Y);
                Rectangle r = new Rectangle(loc.X, loc.Y, width, height);
                if (isUpperCorner(loc1, loc2))
                {
                    loc = loc1;
                }
                else
                {
                    loc = loc2;
                }

                if (gdopt == 1)
                {
                    g.DrawRectangle(this.gpen, r);
                }
                else if (gdopt == 2)
                {
                    g.FillRectangle(this.gbrush, r);
                }
                else if (gdopt == 3)
                {
                    g.FillRectangle(this.gbrush, r);
                    g.DrawRectangle(this.gpen, r);
                }
                //else neither fill nor outline have been selected and nothing will be drawn

            }
        }
        

        public class Elip : graphic
        {
            //this is the Rect object
            public int width;
            public int height;
            public Point loc; //location of the upper left corner

            public Elip() { }
            public Elip(Point loc1, Point loc2, Pen p, short options)
            {
                this.loc1 = loc1;
                this.loc2 = loc2;
                this.gpen = (Pen)p.Clone();
                this.gdopt = options;
            }

            override public void Draw(Graphics g)
            {
                width = Math.Abs(loc1.X - loc2.X);
                height = Math.Abs(loc1.Y - loc2.Y);
                Rectangle r = new Rectangle(loc.X, loc.Y, width, height);
                if ( isUpperCorner( loc1, loc2 ) )
                {
                    loc = loc1;
                }
                else
                {
                    loc = loc2;
                }

                if( gdopt == 1 )
                {
                    g.DrawEllipse(this.gpen, r);
                }
                else if( gdopt == 2 )
                {
                    g.FillEllipse(this.gbrush, r);
                }
                else if( gdopt == 3 )
                {
                    g.FillEllipse(this.gbrush, r);
                    g.DrawEllipse(this.gpen, r);
                }
                //else neither fill nor outline have been selected and nothing will be drawn
                
            }
        }

        public class textString : graphic
        {
            //this is the line object
            public textString() { }
            public textString(Point loc1, Point loc2, Pen p)
            {
                this.loc1 = loc1;
                this.loc2 = loc2;
                this.gpen = (Pen)p.Clone();
            }

            override public void Draw(Graphics g)
            {
                //g.DrawString(this.gpen, loc1, loc2);
            }
        }

 //---FUNCTIONS--//
        //drawing panel mouse click event handler
        private void draw_panel_MouseClick(object sender, MouseEventArgs e)
        {
            if( e.Button == MouseButtons.Left )
            {
                mstate = !mstate;
                if (mstate)
                {
                    c2.X = e.X;
                    c2.Y = e.Y;
                    Console.WriteLine("The second corner is at " + c2.ToString());
                    //this is the second click, need to create the objects and add it to the list
                    createGrpc(); 
                    draw_panel.Invalidate();
                }
                else
                {
                    //else this is the first click
                    c1.X = e.X;
                    c1.Y = e.Y;
                    Console.WriteLine("The first corner is at " + c1.ToString());
                } 
            }
        }

        //Clear function
        private void Clear()
        {
            //this clears the canvas, the graphics object queue, and resets the mouse state variable
            Console.WriteLine("Clearing Canvas, reseting mouse and emptying arraylist");
            mstate = true;
            grry.Clear();
            draw_panel.Invalidate();
        }

        //Draw event handler
        public void draw_panel_Paint(object sender, PaintEventArgs e)
        {
            //draw the objects in the graphics object arraylist
            Graphics g = e.Graphics;
            foreach( graphic go in grry )
            {
                go.Draw( g );
            }
        }

        //radiobutton click event handlers
        private void line_MouseClick(object sender, MouseEventArgs e)
        {
            //type -> 1, draw lines
            Console.WriteLine("You have selected the line");
            gtype = 1;
        }

        private void rect_MouseClick(object sender, MouseEventArgs e)
        {
            //type -> 2, draw rectangles
            Console.WriteLine("You have selected the rectangle");
            gtype = 2;
        }

        private void elip_MouseClick(object sender, MouseEventArgs e)
        {
            //type -> 3, draw elipses
            Console.WriteLine("You have selected the elipse");
            gtype = 3;
        }

        private void text_MouseClick(object sender, MouseEventArgs e)
        {
            //type -> 4, draw text
            Console.WriteLine("You have selected the text");
            gtype = 4;
        }

        private void createGrpc()
        {
            //upon a second click, create a new graphics object and add it to the arraylist
            if( gtype == 1 )
            {
                //create a line
                Line l = new WindowsFormsApplication1.Lab5.Line(c1, c2, pen);
                grry.Add(l);

            }
            else if (gtype == 2)
            {
                //create a rectangle
                Rect r = new Rect(c1, c2, pen, brush, dopt);
                grry.Add(r);
            }
            else if (gtype == 3)
            {
                //create an ellipse
                Elip e = new Elip(c1, c2, pen, dopt);
                 
            }
            else if (gtype == 4)
            {
                //create some text
            }
        }

        private void pen_colors_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set the pen's color to the one the use selected
            //pen.Color
            int i = pen_colors.SelectedIndex;
            if (i == 0)
            {
                pen.Color = Color.Black;
            }
            else if (i == 1)
            {
                pen.Color = Color.Red;
            }
            else if (i == 2)
            {
                pen.Color = Color.Blue;
            }
            else if (i == 3)
            {
                pen.Color = Color.Green;
            }

            string s = pen_colors.SelectedValue.ToString();
        }

        private void fill_colors_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set the fill color
            /*
            int i = fill_colors.SelectedIndex;
            if (i == 0)
            {
                pen.Color = Color.White;
            }
            else if (i == 1)
            {
                pen.Color = Color.Black;
            }
            else if (i == 2)
            {
                pen.Color = Color.Red;
            }
            else if (i == 3)
            {
                pen.Color = Color.Blue;
            }
            else if (i == 4)
            {
                pen.Color = Color.Green;
            }
            */
            
            string s = fill_colors.SelectedValue.ToString();
        }

        private void pen_widths_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set the pen width
            int i = pen_widths.SelectedIndex + 1;
            pen.Width = i;
        }

        //menu item click event handler
        private void Clear(object sender, EventArgs e)
        {
            Clear();
        }

        private void Fill_CheckedChanged(object sender, EventArgs e)
        {
            if( Fill.Checked )
            {
                //it is checked
                dopt |= 1;
            }
            else
            {
                dopt &= 2;
            }
            Console.WriteLine("Dopt is now " + dopt.ToString());
        }

        private void Outline_CheckStateChanged(object sender, EventArgs e)
        {
            if( Outline.Checked )
            {
                dopt |= 2;
            }
            else
            {
                dopt &= 1;
            }
            Console.WriteLine("Dopt is now " + dopt.ToString());
        }
    }
}
