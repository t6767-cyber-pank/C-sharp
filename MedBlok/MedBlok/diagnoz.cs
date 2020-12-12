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
    public partial class diagnoz : Form
    {
        dal dal = new dal();

        public void settingsDGV_sotr()
        {
            try
            {
                dataGridView1.Columns["id_diag"].Visible = false;
                dataGridView1.Columns["opis"].Visible = false;
                dataGridView1.TopLeftHeaderCell.Value = "#";
                dataGridView1.Columns["nazv"].HeaderText = "Диагноз";
            }
            catch
            { }
        }

        public void settingsDGV_sotr2()
        {
            try
            {
                dataGridView2.Columns["id_bufer"].Visible = false;
                dataGridView2.Columns["id_diagnoz"].Visible = false;
                dataGridView2.Columns["id_napravlenie"].Visible = false;
                dataGridView2.Columns["id_diag"].Visible = false;
                dataGridView2.Columns["opis"].Visible = false;
                dataGridView2.Columns["nazv"].Visible = false;
                dataGridView2.Columns["id_nazn"].Visible = false;
                dataGridView2.Columns["opisn"].Visible = false;
                dataGridView2.TopLeftHeaderCell.Value = "#";
                dataGridView2.Columns["nazvn"].HeaderText = "Назначения для текущего диагноза";
                dataGridView2.Columns["ocherednost"].HeaderText = "Очередность применения назначения";
                dataGridView2.AutoResizeColumns();

                dataGridView3.Columns["id_bufer"].Visible = false;
                dataGridView3.Columns["id_diagnoz"].Visible = false;
                dataGridView3.Columns["id_napravlenie"].Visible = false;
                dataGridView3.Columns["id_diag"].Visible = false;
                dataGridView3.Columns["opis"].Visible = false;
                dataGridView3.Columns["nazv"].Visible = false;
                dataGridView3.Columns["id_nazn"].Visible = false;
                dataGridView3.Columns["opisn"].Visible = false;
                dataGridView3.TopLeftHeaderCell.Value = "#";
                dataGridView3.Columns["nazvn"].HeaderText = "Назначения для текущего диагноза";
                dataGridView3.Columns["ocherednost"].HeaderText = "Очередность применения назначения";
                dataGridView3.AutoResizeColumns();
            }
            catch
            { }
        }

        public void settingsDGV_sotr3()
        {
            try
            {
                dataGridView4.Columns["id_nazn"].Visible = false;
                dataGridView4.Columns["opisn"].Visible = false;
                dataGridView4.TopLeftHeaderCell.Value = "#";
                dataGridView4.Columns["nazvn"].HeaderText = "Назначение";
            }
            catch
            { }
        }

        public diagnoz()
        {
            InitializeComponent();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dal.saveNewDiag(textBox2.Text, textBox5.Text);
            textBox2.Text = "";
            textBox5.Text = "";
            dataGridView1.DataSource = dal.GetDiag();
            settingsDGV_sotr();
            tabControl1.SelectedIndex = tabControl1.TabCount - 4;
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["nazv"].Value.ToString().Trim();
            textBox4.Text = dataGridView1.CurrentRow.Cells["opis"].Value.ToString().Trim();
            textBox3.Text = dataGridView1.CurrentRow.Cells["nazv"].Value.ToString().Trim();
            textBox6.Text = dataGridView1.CurrentRow.Cells["opis"].Value.ToString().Trim();
            dataGridView2.DataSource = dal.GetBufer(dataGridView1.CurrentRow.Cells["id_diag"].Value.ToString().Trim());
            dataGridView3.DataSource = dal.GetBufer(dataGridView1.CurrentRow.Cells["id_diag"].Value.ToString().Trim());
            settingsDGV_sotr2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dal.updateDiag(textBox3.Text, textBox6.Text, dataGridView1.CurrentRow.Cells["id_diag"].Value.ToString().Trim());
            dataGridView1.DataSource = dal.GetDiag();
            settingsDGV_sotr();
            tabControl1.SelectedIndex = tabControl1.TabCount - 4;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы действительно хотите удалить?",
                     "Удаление", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    dal.deleteDiag(dataGridView1.CurrentRow.Cells["id_diag"].Value.ToString().Trim());
                    dataGridView1.DataSource = dal.GetDiag();
                    settingsDGV_sotr();
                    tabControl1.SelectedIndex = tabControl1.TabCount - 4;
                    break;
                case DialogResult.No: break;
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            naznacheniya nz = new naznacheniya();
            nz.dataGridView1.DataSource = dal.GetNazn();
            nz.settingsDGV_sotr();
            if (nz.ShowDialog(this) == DialogResult.OK)
            {
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dal.saveNewBufer(dataGridView1.CurrentRow.Cells["id_diag"].Value.ToString().Trim(), dataGridView4.CurrentRow.Cells["id_nazn"].Value.ToString().Trim(), numericUpDown1.Value.ToString());
            dataGridView2.DataSource = dal.GetBufer(dataGridView1.CurrentRow.Cells["id_diag"].Value.ToString().Trim());
            dataGridView3.DataSource = dal.GetBufer(dataGridView1.CurrentRow.Cells["id_diag"].Value.ToString().Trim());
            settingsDGV_sotr2();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы действительно хотите удалить?",
                     "Удаление", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    dal.deleteBufer(dataGridView3.CurrentRow.Cells["id_bufer"].Value.ToString().Trim());
                    dataGridView2.DataSource = dal.GetBufer(dataGridView1.CurrentRow.Cells["id_diag"].Value.ToString().Trim());
                    dataGridView3.DataSource = dal.GetBufer(dataGridView1.CurrentRow.Cells["id_diag"].Value.ToString().Trim());
                    settingsDGV_sotr2();
                    break;
                case DialogResult.No: break;
            }
            
        }
    }
}
