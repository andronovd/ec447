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

namespace Lab8
{
    public partial class Form1 : Form
    {
        public Bitmap slide;
        public bool isImg = false;
        public string str_int;
        public int time = 0;
        public ss f = new ss();

        public Form1()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {
            if( openF.ShowDialog() == DialogResult.OK )
            {
                foreach( string s in openF.FileNames )
                {
                    Console.WriteLine("Adding {0}.", s);
                    fileList.Items.Add(s);
                }
            }
        }

        private void del_Click(object sender, EventArgs e)
        {
            //remove the file or set of file selected by the user
            //If no files selected, report error
            if( fileList.SelectedIndex == - 1 )
            {
                MessageBox.Show("No files selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //If no files to delete, report error
            else if( fileList.Items.Count == 0 )
            {
                MessageBox.Show("No files to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //remove from the listbox
            while(fileList.SelectedIndex != -1)
            {
                fileList.Items.RemoveAt(fileList.SelectedIndex);
            }
            fileList.Invalidate();
        }

        private void interval_TextChanged(object sender, EventArgs e)
        {
            str_int = interval.Text;
            Console.WriteLine("User entered interval value: <{0}>", str_int);
            if( str_int == "")
            {
                return;
            }

            try
            {
                time = Convert.ToInt32(str_int);
            }
            catch( Exception ex )
            {
                Console.WriteLine("Caught Exception: {0}", ex.Message);
                MessageBox.Show("Please enter an integer greater than 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if( time < 1 )
            {
                Console.WriteLine("Interval must be greater than 0");
                MessageBox.Show("Interval must be greater than 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                interval.Text = "";
                str_int = "";
                time = 0;
            }

            Console.WriteLine("time set to {0}", time);
            return;            
        }

        private void show_Click(object sender, EventArgs e)
        {
            if( time == 0 )
            {
                Console.WriteLine("Error: No interval given");
                MessageBox.Show("No interval given", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            f.transferInfo(time, fileList.Items);
            f.start_slideshow();
            f.Hide();
        }
    }
}
