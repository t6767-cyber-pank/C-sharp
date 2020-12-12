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
    public partial class poseshenie : Form
    {
        dal dal = new dal();

        public void settingsDGV_poser()
        {
            try
            {
                dataGridView3.Columns["id_poseshenie"].Visible = false;
                dataGridView3.Columns["id_packartx"].Visible = false;
                dataGridView3.Columns["dadasled"].Visible = false;
                dataGridView3.Columns["firstpos"].Visible = false;
                dataGridView3.TopLeftHeaderCell.Value = "#";
                dataGridView3.Columns["datapos"].HeaderText = "Дата посещения";
                dataGridView3.Columns["ves"].HeaderText = "Текущий вес";
            }
            catch
            { }
        }

        public poseshenie()
        {
            InitializeComponent();
        }

        private void poseshenie_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 parent = (Form1)this.Owner;
            dal.saveNewposeshenie(parent.dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim(), dateTimePicker2.Value.ToShortDateString(), textBox2.Text);
            dataGridView3.DataSource = dal.GetzPos(parent.dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim());
            settingsDGV_poser();
            dateTimePicker2.Value = DateTime.Now;
            textBox2.Text = "0";
        }

        private void poseshenie_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 parent = (Form1)this.Owner;
            parent.dataGridView8.DataSource = dal.GetzPos(parent.dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim());
            parent.settingsDGV_poser();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы действительно хотите удалить?",
                      "Удаление", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    Form1 parent = (Form1)this.Owner;
                    dal.deleteposeshenie(dataGridView3.CurrentRow.Cells["id_poseshenie"].Value.ToString().Trim());
                    dataGridView3.DataSource = dal.GetzPos(parent.dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim());
                    settingsDGV_poser();
                    break;
                case DialogResult.No: break;
            }
            
        }

        private void dataGridView3_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dateTimePicker1.Value = DateTime.Parse(dataGridView3.CurrentRow.Cells["dadasled"].Value.ToString());
            textBox1.Text = dataGridView3.CurrentRow.Cells["ves"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 parent = (Form1)this.Owner;
            dal.updateposeshenie(dateTimePicker1.Value.ToString(), textBox1.Text, dataGridView3.CurrentRow.Cells["id_poseshenie"].Value.ToString().Trim());
            dataGridView3.DataSource = dal.GetzPos(parent.dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim());
            settingsDGV_poser();
        }
    }
}
