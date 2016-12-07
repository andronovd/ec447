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
        public ArrayList bms = new ArrayList(); //holds the bit maps

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
                    //check if a valid filetype

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
    }
}
