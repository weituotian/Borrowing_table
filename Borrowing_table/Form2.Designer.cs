namespace Borrowing_table
{
    partial class Form2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.Panel_list = new MetroFramework.Controls.MetroPanel();
            this.Button_search = new MetroFramework.Controls.MetroButton();
            this.TextBox_search = new MetroFramework.Controls.MetroTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroGrid1 = new MetroFramework.Controls.MetroGrid();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Button_close = new MetroFramework.Controls.MetroButton();
            this.Button_delete = new MetroFramework.Controls.MetroButton();
            this.Button_select = new MetroFramework.Controls.MetroButton();
            this.Button_add = new MetroFramework.Controls.MetroButton();
            this.Panel_list.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.AutoSize = true;
            this.metroCheckBox1.Location = new System.Drawing.Point(0, 0);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(104, 24);
            this.metroCheckBox1.TabIndex = 0;
            this.metroCheckBox1.UseSelectable = true;
            // 
            // Panel_list
            // 
            this.Panel_list.AutoSize = true;
            this.Panel_list.Controls.Add(this.Button_search);
            this.Panel_list.Controls.Add(this.TextBox_search);
            this.Panel_list.Controls.Add(this.metroButton1);
            this.Panel_list.Controls.Add(this.metroGrid1);
            this.Panel_list.Controls.Add(this.Button_close);
            this.Panel_list.Controls.Add(this.Button_delete);
            this.Panel_list.Controls.Add(this.Button_select);
            this.Panel_list.Controls.Add(this.Button_add);
            this.Panel_list.HorizontalScrollbarBarColor = true;
            this.Panel_list.HorizontalScrollbarHighlightOnWheel = false;
            this.Panel_list.HorizontalScrollbarSize = 14;
            this.Panel_list.Location = new System.Drawing.Point(27, 35);
            this.Panel_list.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel_list.Name = "Panel_list";
            this.Panel_list.Size = new System.Drawing.Size(726, 504);
            this.Panel_list.TabIndex = 7;
            this.Panel_list.VerticalScrollbarBarColor = true;
            this.Panel_list.VerticalScrollbarHighlightOnWheel = false;
            this.Panel_list.VerticalScrollbarSize = 12;
            // 
            // Button_search
            // 
            this.Button_search.Location = new System.Drawing.Point(597, 15);
            this.Button_search.Name = "Button_search";
            this.Button_search.Size = new System.Drawing.Size(101, 23);
            this.Button_search.TabIndex = 13;
            this.Button_search.Text = "搜索";
            this.Button_search.UseSelectable = true;
            this.Button_search.Click += new System.EventHandler(this.Button_search_Click);
            // 
            // TextBox_search
            // 
            // 
            // 
            // 
            this.TextBox_search.CustomButton.Image = null;
            this.TextBox_search.CustomButton.Location = new System.Drawing.Point(553, 1);
            this.TextBox_search.CustomButton.Name = "";
            this.TextBox_search.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TextBox_search.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBox_search.CustomButton.TabIndex = 1;
            this.TextBox_search.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBox_search.CustomButton.UseSelectable = true;
            this.TextBox_search.CustomButton.Visible = false;
            this.TextBox_search.Lines = new string[0];
            this.TextBox_search.Location = new System.Drawing.Point(13, 15);
            this.TextBox_search.MaxLength = 32767;
            this.TextBox_search.Name = "TextBox_search";
            this.TextBox_search.PasswordChar = '\0';
            this.TextBox_search.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBox_search.SelectedText = "";
            this.TextBox_search.SelectionLength = 0;
            this.TextBox_search.SelectionStart = 0;
            this.TextBox_search.ShortcutsEnabled = true;
            this.TextBox_search.Size = new System.Drawing.Size(575, 23);
            this.TextBox_search.TabIndex = 12;
            this.TextBox_search.UseSelectable = true;
            this.TextBox_search.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBox_search.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(13, 462);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(121, 33);
            this.metroButton1.TabIndex = 11;
            this.metroButton1.Text = "测试";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Visible = false;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click_1);
            // 
            // metroGrid1
            // 
            this.metroGrid1.AllowDrop = true;
            this.metroGrid1.AllowUserToAddRows = false;
            this.metroGrid1.AllowUserToOrderColumns = true;
            this.metroGrid1.AllowUserToResizeRows = false;
            this.metroGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.metroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.metroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.metroGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid1.DefaultCellStyle = dataGridViewCellStyle2;
            this.metroGrid1.EnableHeadersVisualStyles = false;
            this.metroGrid1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.Location = new System.Drawing.Point(3, 55);
            this.metroGrid1.Name = "metroGrid1";
            this.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGrid1.RowTemplate.Height = 23;
            this.metroGrid1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid1.ShowCellErrors = false;
            this.metroGrid1.Size = new System.Drawing.Size(695, 348);
            this.metroGrid1.TabIndex = 9;
            this.metroGrid1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.metroGrid1_CellMouseDown);
            this.metroGrid1.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.metroGrid1_CellMouseMove);
            this.metroGrid1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.metroGrid1_RowPostPaint);
            this.metroGrid1.DragDrop += new System.Windows.Forms.DragEventHandler(this.metroGrid1_DragDrop);
            this.metroGrid1.DragEnter += new System.Windows.Forms.DragEventHandler(this.metroGrid1_DragEnter);
            this.metroGrid1.DragOver += new System.Windows.Forms.DragEventHandler(this.metroGrid1_DragOver);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Button_close
            // 
            this.Button_close.Location = new System.Drawing.Point(467, 410);
            this.Button_close.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Button_close.Name = "Button_close";
            this.Button_close.Size = new System.Drawing.Size(203, 33);
            this.Button_close.TabIndex = 8;
            this.Button_close.Text = "保存并关闭";
            this.Button_close.UseSelectable = true;
            this.Button_close.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // Button_delete
            // 
            this.Button_delete.Location = new System.Drawing.Point(311, 410);
            this.Button_delete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Button_delete.Name = "Button_delete";
            this.Button_delete.Size = new System.Drawing.Size(121, 33);
            this.Button_delete.TabIndex = 7;
            this.Button_delete.Text = "删除";
            this.Button_delete.UseSelectable = true;
            this.Button_delete.Click += new System.EventHandler(this.Button_delete_Click);
            // 
            // Button_select
            // 
            this.Button_select.Location = new System.Drawing.Point(165, 410);
            this.Button_select.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Button_select.Name = "Button_select";
            this.Button_select.Size = new System.Drawing.Size(121, 33);
            this.Button_select.TabIndex = 6;
            this.Button_select.Text = "选中";
            this.Button_select.UseSelectable = true;
            this.Button_select.Click += new System.EventHandler(this.Button_select_Click);
            // 
            // Button_add
            // 
            this.Button_add.Location = new System.Drawing.Point(13, 410);
            this.Button_add.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Button_add.Name = "Button_add";
            this.Button_add.Size = new System.Drawing.Size(121, 33);
            this.Button_add.TabIndex = 5;
            this.Button_add.Text = "添加";
            this.Button_add.UseSelectable = true;
            this.Button_add.Click += new System.EventHandler(this.Button_add_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 542);
            this.ControlBox = false;
            this.Controls.Add(this.Panel_list);
            this.DisplayHeader = false;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.Opacity = 0.9D;
            this.Padding = new System.Windows.Forms.Padding(23, 55, 23, 28);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.SizeChanged += new System.EventHandler(this.Form2_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.Form2_VisibleChanged);
            this.Panel_list.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
        private MetroFramework.Controls.MetroPanel Panel_list;
        private MetroFramework.Controls.MetroButton Button_delete;
        private MetroFramework.Controls.MetroButton Button_select;
        private MetroFramework.Controls.MetroButton Button_add;
        private MetroFramework.Controls.MetroButton Button_close;
        private MetroFramework.Controls.MetroGrid metroGrid1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private MetroFramework.Controls.MetroButton Button_search;
        private MetroFramework.Controls.MetroTextBox TextBox_search;


    }
}