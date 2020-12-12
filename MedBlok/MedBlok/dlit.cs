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
    public partial class dlit : Form
    {
        dal dal = new dal();
        public dlit()
        {
            InitializeComponent();
        }

        private void dlit_Load(object sender, EventArgs e)
        {

        }

        public void settingsDGV_sotr()
        {
            try
            {
                dataGridView1.Columns["id_dlit"].Visible = false;
                dataGridView1.TopLeftHeaderCell.Value = "#";
                dataGridView1.Columns["dlit"].HeaderText = "Длительность";
            }
            catch
            { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dal.deleteDlit(dataGridView1.CurrentRow.Cells["id_dlit"].Value.ToString().Trim());
            dataGridView1.DataSource = dal.Getdlit();
            settingsDGV_sotr();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dal.saveNewDlit(textBox1.Text);
            textBox1.Text = "";
            dataGridView1.DataSource = dal.Getdlit();
            settingsDGV_sotr();
        }
    }
}
