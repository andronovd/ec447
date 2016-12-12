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
using System.IO;

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
        
        
        private void open_col(object sender, EventArgs e)
        {
            if (openCol.ShowDialog() == DialogResult.OK)
            {
                //open the file for reading
                ArrayList lines = new ArrayList();
                Console.WriteLine("trying to read file ");
                try
                {
                    StreamReader f = new StreamReader(openCol.FileName);
                    string line;
                    while ((line = f.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        lines.Add(line);
                    }
                    f.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Open colection failed: <{0}>", ex.Message);
                    MessageBox.Show("Unable to read collections file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    f.Close();
                    return;
                }

                Console.WriteLine("Clearing filelist and adding new pic list");
                fileList.Items.Clear();
                foreach( string s in lines )
                {
                    fileList.Items.Add(s);
                }
            }
        }


        private void save_col(object sender, EventArgs e)
        {
            //save the collection
            if (saveCol.ShowDialog() == DialogResult.OK)
            {
                //save the contents of the list box to the file
                try
                {
                    StreamWriter f = new StreamWriter(saveCol.FileName + ".pix");
                    Console.WriteLine("Opened file stream for writing to <{0}>", saveCol.FileName + ".pix" );
                    foreach (string s in fileList.Items)
                    {
                        Console.WriteLine("Writing line: <{0}>", s);
                        f.WriteLine(s);
                        f.Flush();
                    }
                    f.Close();
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to write to destination file: <{0}>", ex.Message);
                    MessageBox.Show("Unable to write to destinaiton file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    f.Close();
                    return;
                }
            }
        }
        
    }
}
