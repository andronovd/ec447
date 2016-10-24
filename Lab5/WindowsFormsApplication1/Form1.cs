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

        //Draw_GroupBox controls
        RadioButton line = new RadioButton();
        RadioButton rect = new RadioButton();
        RadioButton elip = new RadioButton();
        RadioButton text = new RadioButton();
        TextBox tb = new TextBox();

        //create the 3 labels for each selection
        Label pen_color = new Label();
        Label fill_color = new Label();
        Label pen_width = new Label();

        //create the 3 listboxes for each label
        ListBox pen_colors = new ListBox();
        ListBox fill_colors = new ListBox();
        ListBox pen_widths = new ListBox();

        //data arrrays for the listboxes
        private String[] pc_data = { "Black", "Red", "Blue", "Green" };
        private String[] fl_data = { "White", "Black", "Red", "Blue", "Green" };
        private int[] pw_data = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };




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

        //graphics object class inheirited from the Graphic Class
        public class graphic
        {
            public Point loc1; //location of the 1st corner
            public Point loc2; //location of the 2nd corner
            public Pen pen; //its color

            public graphic()
            {
                loc1 = new Point(0, 0);
                loc2 = new Point(0, 0);
                pen = new Pen(Color.Black, 1);
            }

            public graphic( Point loc1, Point loc2, Pen p )
            {
                this.loc1 = loc1;
                this.loc2 = loc2;
                this.pen = p;
            }

            public virtual void Draw(Graphics g)
            { }
        }

        public class Line : graphic
        {
            //this is the line object
            public Line() { }
            public Line( Point loc1, Point loc2, Pen p )
            {
                this.loc1 = loc1;
                this.loc2 = loc2;
                this.pen = p;
            }

            override public void Draw( Graphics g )
            {
                g.DrawLine(pen, loc1, loc2);
            }
        }

        public class Rect : graphic
        {
            //this is the Rect object
            public int width;
            public int height;
            public Point loc; //location of the upper left corner

            public Rect() { }
            public Rect(Point loc1, Point loc2, Pen p)
            {
                this.loc1 = loc1;
                this.loc2 = loc2;
                this.pen = p;
            }

            override public void Draw(Graphics g)
            {
                width = Math.Abs(loc1.X - loc2.X);
                height = Math.Abs(loc1.Y - loc2.Y);
                if( (loc1.X >= loc2.X) && (loc1.Y <= loc2.Y ) )
                {
                    loc = loc1;
                }
                else
                {
                    loc = loc2;
                }

                g.DrawRectangle( pen, new Rectangle( loc.X, loc.Y, width, height) );
            }
        }
    }
}
