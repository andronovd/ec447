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
            this.pen_widths = new System.Windows.Forms.ListBox();
            this.FillColor = new System.Windows.Forms.Panel();
            this.fill_colors = new System.Windows.Forms.ListBox();
            this.PenColor = new System.Windows.Forms.Panel();
            this.pen_colors = new System.Windows.Forms.ListBox();
            this.draw_box = new System.Windows.Forms.GroupBox();
            this.tb = new System.Windows.Forms.TextBox();
            this.text = new System.Windows.Forms.RadioButton();
            this.elip = new System.Windows.Forms.RadioButton();
            this.rect = new System.Windows.Forms.RadioButton();
            this.line = new System.Windows.Forms.RadioButton();
            this.draw_panel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.options_panel.SuspendLayout();
            this.PenWidth.SuspendLayout();
            this.FillColor.SuspendLayout();
            this.PenColor.SuspendLayout();
            this.draw_box.SuspendLayout();
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
            this.Outline.CheckStateChanged += new System.EventHandler(this.Outline_CheckStateChanged);
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
            this.Fill.CheckedChanged += new System.EventHandler(this.Fill_CheckedChanged);
            // 
            // PenWidth
            // 
            this.PenWidth.Controls.Add(this.pen_widths);
            this.PenWidth.Location = new System.Drawing.Point(480, 35);
            this.PenWidth.Name = "PenWidth";
            this.PenWidth.Size = new System.Drawing.Size(96, 165);
            this.PenWidth.TabIndex = 0;
            // 
            // pen_widths
            // 
            this.pen_widths.FormattingEnabled = true;
            this.pen_widths.Location = new System.Drawing.Point(17, 109);
            this.pen_widths.Name = "pen_widths";
            this.pen_widths.Size = new System.Drawing.Size(76, 56);
            this.pen_widths.TabIndex = 5;
            this.pen_widths.SelectedIndexChanged += new System.EventHandler(this.pen_widths_SelectedIndexChanged);
            // 
            // FillColor
            // 
            this.FillColor.Controls.Add(this.fill_colors);
            this.FillColor.Location = new System.Drawing.Point(375, 35);
            this.FillColor.Name = "FillColor";
            this.FillColor.Size = new System.Drawing.Size(80, 100);
            this.FillColor.TabIndex = 0;
            // 
            // fill_colors
            // 
            this.fill_colors.FormattingEnabled = true;
            this.fill_colors.Location = new System.Drawing.Point(23, 44);
            this.fill_colors.Name = "fill_colors";
            this.fill_colors.Size = new System.Drawing.Size(57, 56);
            this.fill_colors.TabIndex = 4;
            this.fill_colors.SelectedIndexChanged += new System.EventHandler(this.fill_colors_SelectedIndexChanged);
            // 
            // PenColor
            // 
            this.PenColor.Controls.Add(this.pen_colors);
            this.PenColor.Location = new System.Drawing.Point(270, 35);
            this.PenColor.Name = "PenColor";
            this.PenColor.Size = new System.Drawing.Size(80, 100);
            this.PenColor.TabIndex = 0;
            // 
            // pen_colors
            // 
            this.pen_colors.FormattingEnabled = true;
            this.pen_colors.Location = new System.Drawing.Point(28, 42);
            this.pen_colors.Name = "pen_colors";
            this.pen_colors.Size = new System.Drawing.Size(49, 56);
            this.pen_colors.TabIndex = 3;
            this.pen_colors.SelectedIndexChanged += new System.EventHandler(this.pen_colors_SelectedIndexChanged);
            // 
            // draw_box
            // 
            this.draw_box.Controls.Add(this.tb);
            this.draw_box.Controls.Add(this.text);
            this.draw_box.Controls.Add(this.elip);
            this.draw_box.Controls.Add(this.rect);
            this.draw_box.Controls.Add(this.line);
            this.draw_box.Location = new System.Drawing.Point(35, 35);
            this.draw_box.Name = "draw_box";
            this.draw_box.Size = new System.Drawing.Size(210, 185);
            this.draw_box.TabIndex = 0;
            this.draw_box.TabStop = false;
            this.draw_box.Text = "Draw";
            // 
            // tb
            // 
            this.tb.Location = new System.Drawing.Point(20, 111);
            this.tb.Multiline = true;
            this.tb.Name = "tb";
            this.tb.Size = new System.Drawing.Size(190, 74);
            this.tb.TabIndex = 7;
            this.tb.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // text
            // 
            this.text.AutoSize = true;
            this.text.Location = new System.Drawing.Point(20, 88);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(46, 17);
            this.text.TabIndex = 6;
            this.text.TabStop = true;
            this.text.Text = "Text";
            this.text.UseVisualStyleBackColor = true;
            this.text.MouseClick += new System.Windows.Forms.MouseEventHandler(this.text_MouseClick);
            // 
            // elip
            // 
            this.elip.AutoSize = true;
            this.elip.Location = new System.Drawing.Point(20, 65);
            this.elip.Name = "elip";
            this.elip.Size = new System.Drawing.Size(55, 17);
            this.elip.TabIndex = 5;
            this.elip.TabStop = true;
            this.elip.Text = "Ellipse";
            this.elip.UseVisualStyleBackColor = true;
            this.elip.MouseClick += new System.Windows.Forms.MouseEventHandler(this.elip_MouseClick);
            // 
            // rect
            // 
            this.rect.AutoSize = true;
            this.rect.Location = new System.Drawing.Point(20, 42);
            this.rect.Name = "rect";
            this.rect.Size = new System.Drawing.Size(74, 17);
            this.rect.TabIndex = 4;
            this.rect.TabStop = true;
            this.rect.Text = "Rectangle";
            this.rect.UseVisualStyleBackColor = true;
            this.rect.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rect_MouseClick);
            // 
            // line
            // 
            this.line.AutoSize = true;
            this.line.Location = new System.Drawing.Point(20, 19);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(45, 17);
            this.line.TabIndex = 3;
            this.line.TabStop = true;
            this.line.Text = "Line";
            this.line.UseVisualStyleBackColor = true;
            this.line.MouseClick += new System.Windows.Forms.MouseEventHandler(this.line_MouseClick);
            // 
            // draw_panel
            // 
            this.draw_panel.BackColor = System.Drawing.SystemColors.Control;
            this.draw_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.draw_panel.Location = new System.Drawing.Point(0, 264);
            this.draw_panel.Name = "draw_panel";
            this.draw_panel.Size = new System.Drawing.Size(601, 235);
            this.draw_panel.TabIndex = 1;
            this.draw_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.draw_panel_Paint);
            this.draw_panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.draw_panel_MouseClick);
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
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.Clear);
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
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
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
            this.PenWidth.ResumeLayout(false);
            this.FillColor.ResumeLayout(false);
            this.PenColor.ResumeLayout(false);
            this.draw_box.ResumeLayout(false);
            this.draw_box.PerformLayout();
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
        private System.Windows.Forms.RadioButton elip;
        private System.Windows.Forms.RadioButton rect;
        private System.Windows.Forms.RadioButton line;
        private System.Windows.Forms.RadioButton text;
        private System.Windows.Forms.TextBox tb;
        private System.Windows.Forms.ListBox pen_colors;
        private System.Windows.Forms.ListBox pen_widths;
        private System.Windows.Forms.ListBox fill_colors;
    }
}

