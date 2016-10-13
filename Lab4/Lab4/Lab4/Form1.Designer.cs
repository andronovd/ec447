namespace Lab4
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
            this.Clear = new System.Windows.Forms.Button();
            this.Hints = new System.Windows.Forms.CheckBox();
            this.DispNumQueens = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(100, 20);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(75, 23);
            this.Clear.TabIndex = 0;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Clear_MouseClick);
            // 
            // Hints
            // 
            this.Hints.AutoSize = true;
            this.Hints.Location = new System.Drawing.Point(10, 23);
            this.Hints.Name = "Hints";
            this.Hints.Size = new System.Drawing.Size(50, 17);
            this.Hints.TabIndex = 1;
            this.Hints.Text = "Hints";
            this.Hints.UseVisualStyleBackColor = true;
            this.Hints.CheckedChanged += new System.EventHandler(this.Hints_CheckedChanged);
            // 
            // DispNumQueens
            // 
            this.DispNumQueens.AutoSize = true;
            this.DispNumQueens.Location = new System.Drawing.Point(250, 23);
            this.DispNumQueens.Name = "DispNumQueens";
            this.DispNumQueens.Size = new System.Drawing.Size(166, 13);
            this.DispNumQueens.TabIndex = 2;
            this.DispNumQueens.Text = "You have 0 queens on the board.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 472);
            this.Controls.Add(this.DispNumQueens);
            this.Controls.Add(this.Hints);
            this.Controls.Add(this.Clear);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.CheckBox Hints;
        private System.Windows.Forms.Label DispNumQueens;
    }
}

