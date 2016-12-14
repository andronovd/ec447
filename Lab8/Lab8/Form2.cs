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
        public bool isLast = false;
        public Font f;
        public short counter = 0;
        public int[] irm = new int[4]; //image resize metrics, contains the cacluclated arguments for drawimage( image, int, int , int , int );

        public ss()
        {
            InitializeComponent();
        }

        private async void ss_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            try
            {
                slide = new Bitmap((string)fileList[counter]);
                calcScale(slide);
                Console.WriteLine("trying to draw image: <{0}>", curr);
                g.DrawImage(slide, irm[0], irm[1], irm[2], irm[3]);
                slide.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Font f = new Font( "Arial", 24, FontStyle.Bold | FontStyle.Italic );
                g.DrawString("Not an Image!", f, Brushes.Red, 0, 0);
                f.Dispose();
            }


            counter++;
            //wait 1 sec
            await Task.Delay(time * 1000);

            //see if at the end
            if( counter == fileList.Count )
            {
                counter = 0;
                this.Close();
            }
            Invalidate();
        }

        private void ss_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        public void transferInfo ( int time, System.Windows.Forms.ListBox.ObjectCollection fileList )
        {
            this.time = time;
            this.fileList = fileList;
            return;
        }

        public void calcScale(Bitmap b)
        {

            double R = (double)b.Width / b.Height;
            Console.WriteLine("Calculating scale for bitmap");
            Console.WriteLine("H:<{0}, W:{1}, R:" + R.ToString(), b.Height, b.Width);
            Console.WriteLine("Form hxw: {0}x{1}", this.Height, this.Width);

            //calculate scale to fit 
            //calculate proper position
            if (b.Width > b.Height)
            {
                this.irm[3] = (int)(this.Height / R);
                this.irm[2] =  this.Width;
                this.irm[1] =  (this.Height - irm[3] )>> 1;
                this.irm[0] = 0;
            }
            else
            {
                this.irm[3] = this.Height;
                this.irm[2] = (int)(this.Width * R);
                this.irm[1] = 0;
                this.irm[0] = (this.Width - irm[2]) >> 1;
            }
            Console.WriteLine("New size: {0}x{1}", irm[3], irm[2]);
            Console.WriteLine("New position {0}x{1}", irm[0], irm[1]);
        }
    }
}
