namespace WindowsFormsApplication1
{
    partial class Lab5
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
            this.options_panel = new System.Windows.Forms.Panel();
            this.Outline = new System.Windows.Forms.CheckBox();
            this.Fill = new System.Windows.Forms.CheckBox();
            this.PenWidth = new System.Windows.Forms.Panel();
            this.FillColor = new System.Windows.Forms.Panel();
            this.PenColor = new System.Windows.Forms.Panel();
            this.draw_box = new System.Windows.Forms.GroupBox();
            this.draw_panel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.options_panel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // options_panel
            // 
            this.options_panel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.options_panel.Controls.Add(this.Outline);
            this.options_panel.Controls.Add(this.Fill);
            this.options_panel.Controls.Add(this.PenWidth);
            this.options_panel.Controls.Add(this.FillColor);
            this.options_panel.Controls.Add(this.PenColor);
            this.options_panel.Controls.Add(this.draw_box);
            this.options_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.options_panel.Location = new System.Drawing.Point(0, 24);
            this.options_panel.Name = "options_panel";
            this.options_panel.Size = new System.Drawing.Size(601, 240);
            this.options_panel.TabIndex = 0;
            // 
            // Outline
            // 
            this.Outline.AutoSize = true;
            this.Outline.Location = new System.Drawing.Point(350, 190);
            this.Outline.Name = "Outline";
            this.Outline.Size = new System.Drawing.Size(59, 17);
            this.Outline.TabIndex = 1;
            this.Outline.Text = "Outline";
            this.Outline.UseVisualStyleBackColor = true;
            // 
            // Fill
            // 
            this.Fill.AutoSize = true;
            this.Fill.Location = new System.Drawing.Point(350, 160);
            this.Fill.Name = "Fill";
            this.Fill.Size = new System.Drawing.Size(38, 17);
            this.Fill.TabIndex = 0;
            this.Fill.Text = "Fill";
            this.Fill.UseVisualStyleBackColor = true;
            // 
            // PenWidth
            // 
            this.PenWidth.Location = new System.Drawing.Point(480, 35);
            this.PenWidth.Name = "PenWidth";
            this.PenWidth.Size = new System.Drawing.Size(96, 165);
            this.PenWidth.TabIndex = 0;
            // 
            // FillColor
            // 
            this.FillColor.Location = new System.Drawing.Point(375, 35);
            this.FillColor.Name = "FillColor";
            this.FillColor.Size = new System.Drawing.Size(80, 100);
            this.FillColor.TabIndex = 0;
            // 
            // PenColor
            // 
            this.PenColor.Location = new System.Drawing.Point(270, 35);
            this.PenColor.Name = "PenColor";
            this.PenColor.Size = new System.Drawing.Size(80, 100);
            this.PenColor.TabIndex = 0;
            // 
            // draw_box
            // 
            this.draw_box.Location = new System.Drawing.Point(35, 35);
            this.draw_box.Name = "draw_box";
            this.draw_box.Size = new System.Drawing.Size(210, 185);
            this.draw_box.TabIndex = 0;
            this.draw_box.TabStop = false;
            this.draw_box.Text = "Draw";
            // 
            // draw_panel
            // 
            this.draw_panel.BackColor = System.Drawing.SystemColors.Control;
            this.draw_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.draw_panel.Location = new System.Drawing.Point(0, 264);
            this.draw_panel.Name = "draw_panel";
            this.draw_panel.Size = new System.Drawing.Size(601, 235);
            this.draw_panel.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(601, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // Lab5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 499);
            this.Controls.Add(this.draw_panel);
            this.Controls.Add(this.options_panel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Lab5";
            this.Text = "andronov_Lab5";
            this.options_panel.ResumeLayout(false);
            this.options_panel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel options_panel;
        private System.Windows.Forms.Panel draw_panel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.GroupBox draw_box;
        private System.Windows.Forms.Panel PenColor;
        private System.Windows.Forms.Panel FillColor;
        private System.Windows.Forms.Panel PenWidth;
        private System.Windows.Forms.CheckBox Fill;
        private System.Windows.Forms.CheckBox Outline;
    }
}

