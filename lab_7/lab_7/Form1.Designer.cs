namespace lab_7
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.filename_label = new System.Windows.Forms.Label();
            this.key_label = new System.Windows.Forms.Label();
            this.filename_tb = new System.Windows.Forms.TextBox();
            this.key_tb = new System.Windows.Forms.TextBox();
            this.Browse = new System.Windows.Forms.Button();
            this.ec = new System.Windows.Forms.Button();
            this.dc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "All Files|*.*|Encrypted Files|*.des";
            // 
            // filename_label
            // 
            this.filename_label.AutoSize = true;
            this.filename_label.Location = new System.Drawing.Point(42, 28);
            this.filename_label.Name = "filename_label";
            this.filename_label.Size = new System.Drawing.Size(52, 13);
            this.filename_label.TabIndex = 0;
            this.filename_label.Text = "Filename:";
            // 
            // key_label
            // 
            this.key_label.AutoSize = true;
            this.key_label.Location = new System.Drawing.Point(42, 87);
            this.key_label.Name = "key_label";
            this.key_label.Size = new System.Drawing.Size(28, 13);
            this.key_label.TabIndex = 1;
            this.key_label.Text = "Key:";
            // 
            // filename_tb
            // 
            this.filename_tb.Location = new System.Drawing.Point(45, 53);
            this.filename_tb.Name = "filename_tb";
            this.filename_tb.Size = new System.Drawing.Size(175, 20);
            this.filename_tb.TabIndex = 2;
            this.filename_tb.TextChanged += new System.EventHandler(this.filename_tb_TextChanged);
            // 
            // key_tb
            // 
            this.key_tb.Location = new System.Drawing.Point(45, 122);
            this.key_tb.Name = "key_tb";
            this.key_tb.Size = new System.Drawing.Size(175, 20);
            this.key_tb.TabIndex = 3;
            this.key_tb.TextChanged += new System.EventHandler(this.key_tb_TextChanged);
            // 
            // Browse
            // 
            this.Browse.Image = ((System.Drawing.Image)(resources.GetObject("Browse.Image")));
            this.Browse.Location = new System.Drawing.Point(316, 45);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(38, 35);
            this.Browse.TabIndex = 4;
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // ec
            // 
            this.ec.Location = new System.Drawing.Point(45, 168);
            this.ec.Name = "ec";
            this.ec.Size = new System.Drawing.Size(75, 23);
            this.ec.TabIndex = 5;
            this.ec.Text = "Encrypt";
            this.ec.UseVisualStyleBackColor = true;
            this.ec.Click += new System.EventHandler(this.ec_Click);
            // 
            // dc
            // 
            this.dc.Location = new System.Drawing.Point(145, 168);
            this.dc.Name = "dc";
            this.dc.Size = new System.Drawing.Size(75, 23);
            this.dc.TabIndex = 6;
            this.dc.Text = "Decrypt";
            this.dc.UseVisualStyleBackColor = true;
            this.dc.Click += new System.EventHandler(this.dc_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 261);
            this.Controls.Add(this.dc);
            this.Controls.Add(this.ec);
            this.Controls.Add(this.Browse);
            this.Controls.Add(this.key_tb);
            this.Controls.Add(this.filename_tb);
            this.Controls.Add(this.key_label);
            this.Controls.Add(this.filename_label);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label filename_label;
        private System.Windows.Forms.Label key_label;
        private System.Windows.Forms.TextBox filename_tb;
        private System.Windows.Forms.TextBox key_tb;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.Button ec;
        private System.Windows.Forms.Button dc;
    }
}

