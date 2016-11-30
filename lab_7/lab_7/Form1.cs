using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace lab_7
{
    public partial class Form1 : Form
    {
        public string filename = "";
        public string key_str;
        public byte[] key = new byte[8];
        public short key_ptr = 0;
        public int key_len = 0;

        public Form1()
        {
            InitializeComponent();
        }

        //getting the text from the text boxes into local variables
        private void filename_tb_TextChanged(object sender, EventArgs e)
        {
            filename = filename_tb.Text;
            Console.WriteLine("filename: {0}", filename);
            bool b = isDes();
        }

        private void key_tb_TextChanged(object sender, EventArgs e)
        {
            key_str = key_tb.Text;
            Console.WriteLine("key_str: {0}", key_str);
            process_key();
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            if( openFileDialog1.ShowDialog()  == DialogResult.OK )
            {
                filename_tb.Text = openFileDialog1.FileName;
                filename = openFileDialog1.FileName;
            }
        }

        private void process_key()
        {
            //process the key_string and put it in the byte array
            int i = 0;
            for(; i < 8; i++ )
            {
                key[i] = 0;
            }

            i = 0;
            foreach( byte b in key_str )
            {
                key[i] += b;
                i = (short)((i + 1) & 7);
            }

            
            Console.Write("key: ");
            foreach( byte b in key )
            {
                Console.Write("{0}, ", b);
            }
            Console.WriteLine();
        }

        private void decrypt()
        {
            //check if a file has been selected
            if (filename == "")
            {
                MessageBox.Show("Please select a file to decrypt.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //check if there is a key
            if ( key_check() )
            {
                MessageBox.Show("Please enter a key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //open file for writing
            //make the new file name
            int last = filename.LastIndexOf(".");
            string decrypt_name = filename.Substring(0, last);
            Console.WriteLine("dcname: {0}", decrypt_name);
            //check if overwriting file
            if (File.Exists(decrypt_name))
            {
               
                if(MessageBox.Show("Output file exists. Overwrite?", "File Exists", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel )
                {
                    //no overwriting today
                    return;
                }
                
            }
            FileStream encf = null;
            try
            {
                encf = new FileStream(filename, FileMode.Open, FileAccess.Read);
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to open source or destination file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //check the file extension
            if( isDes() )
            {
                MessageBox.Show("Please select a .des file to decrypt","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                encf.Close();
                return;
            }
            
            DES des = new DESCryptoServiceProvider();
            //des.Padding = PaddingMode.Zeros;
            CryptoStream dencF = new CryptoStream(encf, des.CreateDecryptor(key, key), CryptoStreamMode.Read);

            int n;
            int fLen = (int)encf.Length;
            int offset = 0;
            if (fLen == 0)
            {
                Console.WriteLine("File is empty");
                return;
            }
            byte[] b = new byte[fLen];
            try
            {
                while (fLen > 0)
                {
                    n = dencF.Read(b, offset, 1);
                    offset++;
                    fLen--;
                    Console.WriteLine("{0} bytes decrypted", offset);
                }
                Console.WriteLine("Data decrypted");
                dencF.Close();
            }
            catch( Exception e )
            {
                //bad data error, wrong key
                Console.WriteLine(e.Message);
                MessageBox.Show("Bad data: wrong key");
                encf.Close();
                return;
            }

            FileStream dest = new FileStream(decrypt_name, FileMode.Create, FileAccess.Write);
            dest.Write(b, 0, b.Length);
            //close the file streams
            encf.Close();
            dest.Close();
            return;
        }

        private void encrypt()
        {
            //check if a file has been selected
            if( filename == "" )
            {
                MessageBox.Show("Please select a file to encrypt.");
                return;
            }
            //check if the any key has been entered
            if( key_check () )
            {
                MessageBox.Show("Please Enter a Key.");
                return;
            }
            //set up file streams an des encrypter
            //try to open the file
            FileStream f = null;
            try
            {
                f = new FileStream(filename, FileMode.Open, FileAccess.Read);
            }
            catch( Exception e )
            {
                
                MessageBox.Show("Unable to open source or destination file");
                return;
            }
            
            //open file for writing
            //check if overwriting file
            FileStream dest = new FileStream(filename + ".des", FileMode.Create, FileAccess.Write);
            DES des = new DESCryptoServiceProvider();
            //des.Padding = PaddingMode.Zeros;
            CryptoStream encF = new CryptoStream(dest, des.CreateEncryptor(key, key), CryptoStreamMode.Write);
           
            

            int fLen = (int)f.Length;
            if( fLen == 0 )
            {
                Console.WriteLine("File is empty");
                return;
            }
            byte[] b = new byte[fLen];
            int n;
            int offset = 0;
            do
            {
                n = f.Read(b, offset, 1);
                offset++;
                fLen--;
                Console.WriteLine("{0} bytes encrypted", offset);
            }
            while (fLen > 0);

            encF.Write(b, 0, b.Length);
            //close the file streams
            encF.Close();
            f.Close();
            dest.Close();
        }

        private void ec_Click(object sender, EventArgs e)
        {
            encrypt();
        }

        private void dc_Click(object sender, EventArgs e)
        {
            decrypt();
        }

        private bool key_check()
        {
            //checks to see if the key is valid
            foreach( byte b in key )
            {
                //Console.WriteLine( "{0}", b);
                if( b != 0 )
                {
                    return false;
                }
            }
            return true;
        }

        private bool isDes( )
        {
            string[] split = filename.Split('.');
            string extension = split[split.Length - 1];
            Console.WriteLine(extension);
            if (extension == "des")
            {
                return false;
            }
            return true;
        }
    }
}
