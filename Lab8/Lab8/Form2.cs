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
using System.Threading;

namespace Lab8
{
    public partial class ss : Form
    {
        public int time;
        public System.Windows.Forms.ListBox.ObjectCollection fileList;
        public Bitmap slide;
        public string curr;
        public bool init = false;
        public Font f;

        public ss()
        {
            InitializeComponent();
        }

        private void ss_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            slide = new Bitmap(curr);
            try
            {
                Console.WriteLine("trying to draw image: <{0}>", curr);
                g.DrawImage(slide, 0, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                g.DrawString("Not an Image", Font, Brushes.Red, 0, 0);
            }
            slide.Dispose();
        }

        private void ss_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        public void start_slideshow()
        {
            init = true;
            //check if there are any files to show
            if (this.fileList.Count == 0)
            {
                Console.WriteLine("No images to show ");
                MessageBox.Show("No files to show", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (string s in this.fileList)
            {
                Console.WriteLine("Opening {0}", s);
                curr = s;
                this.ShowDialog();
                Console.WriteLine("Starting timer for {0} sec.", time);
                Thread.Sleep(time * 1000);
                this.Hide();
            }
            
            //start the slide show
            //open the form in modal mode


        }
        public void transferInfo ( int time, System.Windows.Forms.ListBox.ObjectCollection fileList )
        {
            this.time = time;
            this.fileList = fileList;
            return;
        }
    }
}
