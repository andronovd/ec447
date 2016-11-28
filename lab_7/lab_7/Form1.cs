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
        public string filename;
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

            /*
            Console.Write("key: ");
            foreach( byte b in key )
            {
                Console.Write("{0}, ", b);
            }
            Console.WriteLine();
            */
        }

        private void decrypt()
        {
            //set up file streams an des encrypter
            //try to open the file
            FileStream encf = null;
            try
            {
                encf = new FileStream(filename, FileMode.Open, FileAccess.Read);
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to open file");
            }

            //open file for writing
            //check if overwriting file
            FileStream dest = new FileStream( filename + ".dec", FileMode.Create, FileAccess.Write);
            DES des = new DESCryptoServiceProvider();
            CryptoStream dencF = new CryptoStream(encf, des.CreateDecryptor(key, key), CryptoStreamMode.Read);


            int fLen = (int)encf.Length;
            if (fLen == 0)
            {
                Console.WriteLine("File is empty");
                return;
            }
            byte[] b = new byte[1];
            int offset = 0;
            do
            {
                dencF.Read(b, 0, 1);
                dest.Write(b, 0, 1);
                offset++;
                fLen--;
                Console.WriteLine("{0} bytes decrypted", offset);
            }
            while (fLen > 0);

            //close the file streams
            encf.Close();
            dencF.Close();
            dest.Close();
        }

        private void encrypt()
        {
            //set up file streams an des encrypter
            //try to open the file
            FileStream f = null;
            try
            {
                f = new FileStream(filename, FileMode.Open, FileAccess.Read);
            }
            catch( Exception e )
            {
                MessageBox.Show("Unable to open file");
            }
            
            //open file for writing
            //check if overwriting file
            FileStream dest = new FileStream(filename + ".des", FileMode.Create, FileAccess.Write);
            DES des = new DESCryptoServiceProvider();
            CryptoStream encF = new CryptoStream(dest, des.CreateEncryptor(key, key), CryptoStreamMode.Write);
            

            int fLen = (int)f.Length;
            if( fLen == 0 )
            {
                Console.WriteLine("File is empty");
                return;
            }
            byte[] b = new byte[1];
            int offset = 0;
            int n;
            do
            {
                n = f.Read(b, 0, 1);
                encF.Write(b, 0, 1);
                offset++;
                fLen--;
                Console.WriteLine("{0} bytes encrypted", offset);
            }
            while (fLen > 0);

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
    }
}
