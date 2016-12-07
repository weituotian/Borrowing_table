using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Borrowing_table
{
    public partial class OutPut : MetroForm
    {
        public OutPut()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void setText(string text)
        {
            this.metroTextBox1.Text = text;
        }
    }
}
