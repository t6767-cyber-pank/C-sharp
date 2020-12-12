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
    public partial class users : Form
    {
        dal dal = new dal();
        public users()
        {
            InitializeComponent();
        }

        public void settingsDGV_sotr()
        {
            try
            {
                dataGridView1.Columns["id_user"].Visible = false;
                dataGridView1.Columns["pass"].Visible = false;
                dataGridView1.Columns["login"].Visible = false;
                dataGridView1.Columns["status"].Visible = false;
                dataGridView1.TopLeftHeaderCell.Value = "#";
                dataGridView1.Columns["fio"].HeaderText = "Ф.И.О";
            }
            catch
            { }
        }

        private void users_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dal.updateUser(textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.Text, dataGridView1.CurrentRow.Cells["id_user"].Value.ToString().Trim());
            dataGridView1.DataSource = dal.GetUser();
            settingsDGV_sotr();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["fio"].Value.ToString().Trim();
            textBox2.Text = dataGridView1.CurrentRow.Cells["login"].Value.ToString().Trim();
            textBox3.Text = dataGridView1.CurrentRow.Cells["pass"].Value.ToString().Trim();
            comboBox1.Text = dataGridView1.CurrentRow.Cells["status"].Value.ToString().Trim();
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы действительно хотите удалить?",
                      "Удаление", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes: 
                    dal.deleteUser(dataGridView1.CurrentRow.Cells["id_user"].Value.ToString().Trim());
                    dataGridView1.DataSource = dal.GetUser();
                    settingsDGV_sotr();        
                    break;
                case DialogResult.No: break;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dal.saveNewUser(textBox8.Text, textBox7.Text, textBox6.Text, comboBox2.Text);
            textBox8.Text="";
            textBox7.Text="";
            textBox6.Text="";
            comboBox2.Text = "";
            dataGridView1.DataSource = dal.GetUser();
            settingsDGV_sotr();
            tabControl1.SelectedIndex = tabControl1.TabCount - 2;
        }
    }
}
