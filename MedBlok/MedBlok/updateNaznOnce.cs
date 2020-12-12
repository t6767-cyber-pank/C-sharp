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
    public partial class updateNaznOnce : Form
    {
        dal dal = new dal();
        public updateNaznOnce()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 parent = (Form1)this.Owner;
            string idnzn = parent.dataGridView3.CurrentRow.Cells["id_nazn"].Value.ToString().Trim();
            dal.updateNaznKart(textBox1.Text, richTextBox1.Text, comboBox1.Text, comboBox2.Text, comboBox3.Text, numericUpDown1.Value.ToString(), idnzn, "");
            try
            {
                string iddiag = parent.dataGridView2.CurrentRow.Cells["id_diag"].Value.ToString().Trim();
                string idkart = parent.dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim();
                parent.dataGridView3.DataSource = dal.GetNaznKart(idkart, iddiag);
                parent.settingsDGV_nazn();
            }
            catch { }
            this.Close();
        }
    }
}
