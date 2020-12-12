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
    public partial class naznacheniya : Form
    {
        dal dal = new dal();

        public naznacheniya()
        {
            InitializeComponent();
        }

        private void naznacheniya_Load(object sender, EventArgs e)
        {

        }

        public void settingsDGV_sotr()
        {
            try
            {
                dataGridView1.Columns["id_nazn"].Visible = false;
                dataGridView1.Columns["opisn"].Visible = false;
                dataGridView1.TopLeftHeaderCell.Value = "#";
                dataGridView1.Columns["nazvn"].HeaderText = "Назначение";
            }
            catch
            { }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["nazvn"].Value.ToString().Trim();
            richTextBox1.Text = dataGridView1.CurrentRow.Cells["opisn"].Value.ToString().Trim();

            textBox3.Text = dataGridView1.CurrentRow.Cells["nazvn"].Value.ToString().Trim();
            richTextBox3.Text = dataGridView1.CurrentRow.Cells["opisn"].Value.ToString().Trim();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dal.saveNewNazn(textBox2.Text, richTextBox2.Text); 
            textBox2.Text = "";
            richTextBox2.Text = "";
            dataGridView1.DataSource = dal.GetNazn();
            settingsDGV_sotr();
            tabControl1.SelectedIndex = tabControl1.TabCount - 3;
            try {
            diagnoz parent = (diagnoz)this.Owner;
            parent.dataGridView4.DataSource = dal.GetNazn();
            parent.settingsDGV_sotr3();
            } catch{}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dal.updateNazn(textBox3.Text, richTextBox3.Text, dataGridView1.CurrentRow.Cells["id_nazn"].Value.ToString().Trim());
            dataGridView1.DataSource = dal.GetNazn();
            settingsDGV_sotr();
            tabControl1.SelectedIndex = tabControl1.TabCount - 3;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы действительно хотите удалить?",
                     "Удаление", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    dal.deleteNazn(dataGridView1.CurrentRow.Cells["id_nazn"].Value.ToString().Trim());
                    dataGridView1.DataSource = dal.GetNazn();
                    settingsDGV_sotr();
                    tabControl1.SelectedIndex = tabControl1.TabCount - 3;
            break;
                case DialogResult.No: break;
            }
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
