using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedBlok
{
    public partial class naznacheniyaadd : Form
    {
        dal dal = new dal();

        public naznacheniyaadd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dal.saveNewNazn(textBox1.Text, richTextBox1.Text);
            this.Close();
        }
    }
}
