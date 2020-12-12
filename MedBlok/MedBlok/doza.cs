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
    public partial class doza : Form
    {
        dal dal = new dal();
       
        public doza()
        {
            InitializeComponent();
        }

        
        public void settingsDGV_sotr()
        {
            try
            {
                dataGridView1.Columns["id_doza"].Visible = false;
                dataGridView1.TopLeftHeaderCell.Value = "#";
                dataGridView1.Columns["doza"].HeaderText = "Дозировка";
            }
            catch
            { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dal.saveNewDoza(textBox1.Text);
            textBox1.Text = "";
            dataGridView1.DataSource = dal.GetDoza();
            settingsDGV_sotr();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dal.deletedoza(dataGridView1.CurrentRow.Cells["id_doza"].Value.ToString().Trim());
            dataGridView1.DataSource = dal.GetDoza();
            settingsDGV_sotr();
        }
    }
}
