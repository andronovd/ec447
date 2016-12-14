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
                Console.WriteLine("trying to draw image: <{0}>", curr);
                g.DrawImage(slide, 0, 0);
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
    }
}
