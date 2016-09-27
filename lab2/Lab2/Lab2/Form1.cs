using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        const int radius = 20;
        private ArrayList points = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach( Point p in this.points )
            {
                g.FillEllipse(Brushes.Black, p.X - radius / 2, p.Y - radius / 2, radius, radius);
                string s = "(" + p.X.ToString() + ", " + p.Y.ToString() + ")";
                g.DrawString(s, Font, Brushes.Black, p.X + radius/2, p.Y - 6);
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if( e.Button == MouseButtons.Left )
            {
                Point p = new Point(e.X, e.Y);
                this.points.Add(p);
                this.Invalidate();
            }

            if( e.Button == MouseButtons.Right )
            {
                points.Clear();
                this.Invalidate();
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            points.Clear();
            this.Invalidate();
        }
    }
}
