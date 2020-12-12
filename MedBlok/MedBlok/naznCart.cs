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
    public partial class naznCart : Form
    {
        dal dal = new dal();
        public naznCart()
        {
            InitializeComponent();
        }

        private void naznCart_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 parent = (Form1)this.Owner;
            dal.saveNaznKart(parent.dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim(), parent.dataGridView2.CurrentRow.Cells["id_diag"].Value.ToString().Trim(), textBox1.Text, richTextBox1.Text, comboBox1.Text, comboBox2.Text, comboBox3.Text, numericUpDown1.Value.ToString(), dateTimePicker3.Value.ToShortDateString());

            string iddiag = parent.dataGridView2.CurrentRow.Cells["id_diag"].Value.ToString().Trim();
            string idkart = parent.dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim();
            try
            {
                parent.dataGridView3.DataSource = dal.GetNaznKart(idkart, iddiag);
                parent.settingsDGV_nazn();
            }
            catch { }
            numericUpDown1.Value = 0;
            textBox1.Text = "";
            richTextBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            this.Close();
        }
    }
}
