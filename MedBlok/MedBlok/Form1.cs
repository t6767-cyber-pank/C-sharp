using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.Sql;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Word = Microsoft.Office.Interop.Word;

namespace MedBlok
{
    public partial class Form1 : Form
    {

        bool whkart=false;
        bool nbxkart = true;
        string arhiv = "0";
   //     int axaxkart;
   //     int poaxkart;

        dal dal = new dal();

        [DllImport("winmm.dll")]
        private static extern int mciSendString(string MciComando, string MciRetorno, int MciRetornoLeng, int CallBack);
        string mus = "Record.wav";
        bool zap = false;

        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        bool plstp = false;
        string idcartsave;
        bool arh = false;

        public Form1()
        {
            InitializeComponent();
        }

        public void settingsDGV_kart()
        {
            try
            {
                dataGridView1.Columns["kontdan"].Visible = false;
                dataGridView1.Columns["datar"].Visible = false;
                dataGridView1.Columns["vozrastnapriem"].Visible = false;
                dataGridView1.Columns["rost"].Visible = false;
                dataGridView1.Columns["ves"].Visible = false;
                dataGridView1.Columns["vozrastnapriemmes"].Visible = false;
                dataGridView1.Columns["arhiv"].Visible = false;
                dataGridView1.Columns["id_kart"].Visible = false;
                dataGridView1.Columns["ochered"].Visible = false;
                dataGridView1.Columns["statuskart"].Visible = false;
                dataGridView1.TopLeftHeaderCell.Value = "#";

                //dataGridView1.Columns["id_kart"].HeaderText = "Персональный ID";
                //dataGridView1.Columns["statuskart"].HeaderText = "Статус карты";
                //dataGridView1.Columns["ochered"].HeaderText = "Порядок в очереди";
                dataGridView1.Columns["fiopac"].HeaderText = "Ф.И.О пациента";
                //dataGridView1.Columns["fiopac"].DefaultCellStyle.ForeColor = Color.Black;
                /*
                 * this.dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow;
                 * this.dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Black;
                 */
                dataGridView1.Columns["fiopac"].DefaultCellStyle = new DataGridViewCellStyle { ForeColor = Color.Black, BackColor = Color.FromArgb(235, 239, 67) };
                dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 10);
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10);
                if (dataGridView1.CurrentRow.Cells["arhiv"].Value.ToString().Trim() == "0")
                {
                    button17.Text = "Отправить карту в архив";
                }
                else
                {
                    button17.Text = "Вернуть карту из архива";
                }

                
            }
            catch
            { }
        }

        public void settingsDGV_nazn()
        {
            try
            {
                dataGridView3.Columns["id_nazn"].Visible = false;
                dataGridView3.Columns["id_kartnaz"].Visible = false;
                dataGridView3.Columns["id_diagnaz"].Visible = false;
                dataGridView3.Columns["opisn"].Visible = false;

                dataGridView3.TopLeftHeaderCell.Value = "#";
                dataGridView3.Columns["ochered"].HeaderText = "Очередность";
                dataGridView3.Columns["nazvn"].HeaderText = "Назначение";
                dataGridView3.Columns["dnaz"].HeaderText = "Дата";
                dataGridView3.Columns["dozirovka"].HeaderText = "Дозировка";
                dataGridView3.Columns["status"].HeaderText = "Статус";
                dataGridView3.Columns["dlitelnost"].HeaderText = "Длительность";
            }
            catch
            { }
        }

        public void settingsDGV_diag()
        {
            try
            {
                dataGridView5.Columns["id_diag"].Visible = false;
                dataGridView5.Columns["opis"].Visible = false;
                dataGridView5.TopLeftHeaderCell.Value = "#";
                dataGridView5.Columns["nazv"].HeaderText = "Все Диагнозы";
            }
            catch
            { }
        }

        public void settingsDGV_kom()
        {
            try
            {
                dataGridView6.Columns["id_koment"].Visible = false;
                dataGridView6.Columns["id_packart"].Visible = false;
                dataGridView6.Columns["text"].Visible = false;
                dataGridView6.TopLeftHeaderCell.Value = "#";
                dataGridView6.Columns["data"].HeaderText = "Дата";
                dataGridView6.Columns["tema"].HeaderText = "Тема";
            }
            catch
            { }
        }

        public void settingsDGV_poser()
        {
            try
            {
                dataGridView8.Columns["id_poseshenie"].Visible = false;
                dataGridView8.Columns["id_packartx"].Visible = false;
                dataGridView8.Columns["dadasled"].Visible = false;
                dataGridView8.Columns["firstpos"].Visible = false;
                dataGridView8.TopLeftHeaderCell.Value = "#";
                dataGridView8.Columns["datapos"].HeaderText = "Дата посещения";
                dataGridView8.Columns["ves"].HeaderText = "Текущий вес";
            }
            catch
            { }
        }

        public void settingsDGV_zkom()
        {
            try
            {
                dataGridView7.Columns["id_zvukkoment"].Visible = false;
                dataGridView7.Columns["id_packart"].Visible = false;
                dataGridView7.Columns["path"].Visible = false;
                dataGridView7.TopLeftHeaderCell.Value = "#";
                dataGridView7.Columns["data"].HeaderText = "Дата";
            }
            catch
            { }
        }

        public void settingsDGV_diag2()
        {
            try
            {
                dataGridView4.Columns["id_diag"].Visible = false;
                dataGridView4.Columns["opis"].Visible = false;
                dataGridView4.Columns["id_bufkarta"].Visible = false;
                dataGridView4.Columns["id_diagnozkart"].Visible = false;
                dataGridView4.Columns["id_kart"].Visible = false;
                dataGridView4.TopLeftHeaderCell.Value = "#";
                dataGridView4.Columns["nazv"].HeaderText = "Диагнозы текущего пациента";

                dataGridView2.Columns["id_diag"].Visible = false;
                dataGridView2.Columns["opis"].Visible = false;
                dataGridView2.Columns["id_bufkarta"].Visible = false;
                dataGridView2.Columns["id_diagnozkart"].Visible = false;
                dataGridView2.Columns["id_kart"].Visible = false;
                dataGridView2.TopLeftHeaderCell.Value = "#";
                dataGridView2.Columns["nazv"].HeaderText = "Диагнозы текущего пациента";
            }
            catch
            { }
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void назначенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            naznacheniya nz = new naznacheniya();
            nz.dataGridView1.DataSource = dal.GetNazn();
            nz.settingsDGV_sotr();
            if (nz.ShowDialog(this) == DialogResult.OK)
            {
            }

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void дозировкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doza dz = new doza();
            dz.dataGridView1.DataSource = dal.GetDoza();
            dz.settingsDGV_sotr();
            if (dz.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void длительностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dlit dz = new dlit();
            dz.dataGridView1.DataSource = dal.Getdlit();
            dz.settingsDGV_sotr();
            if (dz.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void пользователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            users us = new users();
            us.dataGridView1.DataSource = dal.GetUser();
            us.settingsDGV_sotr();
            if (us.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void диагнозыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            diagnoz us = new diagnoz();
            us.dataGridView1.DataSource = dal.GetDiag();
            us.dataGridView4.DataSource = dal.GetNazn();
            us.settingsDGV_sotr();
            us.settingsDGV_sotr3();
            if (us.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label57.Visible = false;
            menuStrip1.Visible = false;
            tabControl1.Visible = false;
            
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            label2.Text = dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim();
            label3.Text = dataGridView1.CurrentRow.Cells["ochered"].Value.ToString().Trim();
            label5.Text = dataGridView1.CurrentRow.Cells["statuskart"].Value.ToString().Trim();

            label11.Text = dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim();
            label9.Text = dataGridView1.CurrentRow.Cells["ochered"].Value.ToString().Trim();
            label7.Text = dataGridView1.CurrentRow.Cells["statuskart"].Value.ToString().Trim();
            label13.Text = dataGridView1.CurrentRow.Cells["fiopac"].Value.ToString().Trim();
            label23.Text = dataGridView1.CurrentRow.Cells["kontdan"].Value.ToString().Trim();
            label17.Text = dataGridView1.CurrentRow.Cells["datar"].Value.ToString().Trim();

            label21.Text = dataGridView1.CurrentRow.Cells["rost"].Value.ToString().Trim();
            label19.Text = dataGridView1.CurrentRow.Cells["ves"].Value.ToString().Trim();

            string sobr = dataGridView1.CurrentRow.Cells["vozrastnapriem"].Value.ToString().Trim();
            int bfg = Int32.Parse(sobr);
            int cifrus = bfg % 10;

            if ((bfg == 11) || (bfg == 12) || (bfg == 13) || (bfg == 14))
            {
                cifrus = bfg;
            }

            switch (cifrus)
            {
                case 1: sobr += " год "; break;
                case 2: sobr += " года "; break;
                case 3: sobr += " года "; break;
                case 4: sobr += " года "; break;
                default: sobr += " лет "; break;
            }
            sobr += dataGridView1.CurrentRow.Cells["vozrastnapriemmes"].Value.ToString().Trim();
            bfg = Int32.Parse(dataGridView1.CurrentRow.Cells["vozrastnapriemmes"].Value.ToString().Trim());
            cifrus = bfg % 10;

            if ((bfg == 11) || (bfg == 12) || (bfg == 13) || (bfg == 14))
            {
                cifrus = bfg;
            }

            switch (cifrus)
            {
                case 1: sobr += " месяц"; break;
                case 2: sobr += " месяца"; break;
                case 3: sobr += " месяца"; break;
                case 4: sobr += " месяца"; break;
                default: sobr += " месяцев"; break;
            }

            label15.Text = sobr;
            textBox6.Text = dataGridView1.CurrentRow.Cells["fiopac"].Value.ToString().Trim();
            numericUpDown2.Value = Int32.Parse(dataGridView1.CurrentRow.Cells["ochered"].Value.ToString());
            comboBox2.Text = dataGridView1.CurrentRow.Cells["statuskart"].Value.ToString().Trim();
            dateTimePicker2.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells["datar"].Value.ToString().Trim());
            textBox5.Text = dataGridView1.CurrentRow.Cells["rost"].Value.ToString().Trim();
            textBox4.Text = dataGridView1.CurrentRow.Cells["ves"].Value.ToString().Trim();
            richTextBox2.Text = dataGridView1.CurrentRow.Cells["kontdan"].Value.ToString().Trim();
            dataGridView4.DataSource=dal.Getbuferkart(dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim());
            dataGridView2.DataSource = dal.Getbuferkart(dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim());
            settingsDGV_diag2();
            dataGridView6.DataSource = dal.Getkoment(dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim());
            settingsDGV_kom();
            dataGridView7.DataSource = dal.Getzvukkoment(dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim());
            settingsDGV_zkom();
            dataGridView8.DataSource = dal.GetzPos(dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim());
            settingsDGV_poser();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            long xyear = DateTime.Today.Year;
            long dyear = xyear - dateTimePicker1.Value.Year; 
            
            long xmonth = DateTime.Today.Month;
            long dmonth = xmonth - dateTimePicker1.Value.Month;
            
            dal.saveNewKarta(textBox1.Text, richTextBox1.Text, dateTimePicker1.Value.ToString(), dyear.ToString(), dmonth.ToString(), textBox2.Text, textBox3.Text, comboBox1.Text, numericUpDown1.Value.ToString(), "0");
            dal.saveNewFirstPoseshenie();
            dataGridView1.DataSource = dal.GetKarta(textBox10.Text, textBox11.Text, numericUpDown4.Value.ToString(), numericUpDown5.Value.ToString(), comboBox6.Text, comboBox7.Text, arhiv);
            settingsDGV_kart();
            textBox1.Text="";
            richTextBox1.Text="";
            dateTimePicker1.Value=DateTime.Now;
            textBox2.Text="";
            textBox3.Text="";
            comboBox1.Text="Активный";
            numericUpDown1.Value = 10;

            tabControl1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dal.updateKarta(textBox6.Text, richTextBox2.Text, dateTimePicker2.Value.ToString(), textBox5.Text, textBox4.Text, comboBox2.Text, numericUpDown2.Value.ToString(), dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim());
            dataGridView1.DataSource = dal.GetKarta(textBox10.Text, textBox11.Text, numericUpDown4.Value.ToString(), numericUpDown5.Value.ToString(), comboBox6.Text, comboBox7.Text, arhiv);
            settingsDGV_kart();
            tabControl1.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы действительно хотите удалить?",
                     "Удаление", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
            dal.deletekarta(dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim());
            dataGridView1.DataSource = dal.GetKarta(textBox10.Text, textBox11.Text, numericUpDown4.Value.ToString(), numericUpDown5.Value.ToString(), comboBox6.Text, comboBox7.Text, arhiv);
            settingsDGV_kart();
            tabControl1.SelectedIndex = 0;
                    break;
                case DialogResult.No: break;
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы действительно хотите удалить?",
                     "Удаление", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    dal.deletebuferkart(dataGridView4.CurrentRow.Cells["id_bufkarta"].Value.ToString().Trim());
                    dataGridView4.DataSource = dal.Getbuferkart(dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim());
                    dataGridView2.DataSource = dal.Getbuferkart(dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim());
                    settingsDGV_diag2();
                    break;
                case DialogResult.No: break;
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dal.saveNewbuferkart(dataGridView5.CurrentRow.Cells["id_diag"].Value.ToString().Trim(), dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim());
            dal.GetBuferT(dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim(), dataGridView5.CurrentRow.Cells["id_diag"].Value.ToString().Trim());
            dataGridView4.DataSource = dal.Getbuferkart(dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim());
            dataGridView2.DataSource = dal.Getbuferkart(dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim());
            settingsDGV_diag2();
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            string iddiag = dataGridView2.CurrentRow.Cells["id_diag"].Value.ToString().Trim();
            string idkart = dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim();
            try
            {
                numericUpDown3.Value = 0;
                textBox7.Text = "";
                richTextBox3.Text = "";
                comboBox5.Text = "";
                comboBox4.Text = "";
                comboBox3.Text = "";
                dataGridView3.DataSource = dal.GetNaznKart(idkart, iddiag);
                settingsDGV_nazn();
            }
            catch { }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            naznCart nz = new naznCart();
            //nz.dataGridView1.DataSource = dal.GetNazn();
            //nz.settingsDGV_sotr();
            nz.comboBox2.Text = "Назначено";
            nz.comboBox1.Items.Clear();
            nz.comboBox3.Items.Clear();
            ArrayList al = dal.GetDozaCombo();
            foreach (string s in al)
            {
                nz.comboBox1.Items.Add(s);
            }
            
            ArrayList asb = dal.GetdlitCombo();
            foreach (string s in asb)
            {
                nz.comboBox3.Items.Add(s);
            }
            if (nz.ShowDialog(this) == DialogResult.OK)
            {
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы действительно хотите удалить?",
                     "Удаление", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
            dal.deleteNaznKart(dataGridView3.CurrentRow.Cells["id_nazn"].Value.ToString().Trim());
            string iddiag = dataGridView2.CurrentRow.Cells["id_diag"].Value.ToString().Trim();
            string idkart = dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim();
            try
            {
                dataGridView3.DataSource = dal.GetNaznKart(idkart, iddiag);
                settingsDGV_nazn();
            }
            catch { }
                    break;
                case DialogResult.No: break;
            }
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView3_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            numericUpDown3.Value = Decimal.Parse(dataGridView3.CurrentRow.Cells["ochered"].Value.ToString().Trim());
            textBox7.Text = dataGridView3.CurrentRow.Cells["nazvn"].Value.ToString().Trim();
            richTextBox3.Text = dataGridView3.CurrentRow.Cells["opisn"].Value.ToString().Trim();
            comboBox5.Text = dataGridView3.CurrentRow.Cells["dozirovka"].Value.ToString().Trim();
            comboBox4.Text = dataGridView3.CurrentRow.Cells["status"].Value.ToString().Trim();
            comboBox3.Text = dataGridView3.CurrentRow.Cells["dlitelnost"].Value.ToString().Trim();
            dateTimePicker3.Value =DateTime.Parse(dataGridView3.CurrentRow.Cells["dnaz"].Value.ToString().Trim());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string idnzn = dataGridView3.CurrentRow.Cells["id_nazn"].Value.ToString().Trim();
            dal.updateNaznKart(textBox7.Text, richTextBox3.Text, comboBox5.Text, comboBox4.Text, comboBox3.Text, numericUpDown3.Value.ToString(), idnzn, dateTimePicker3.Value.ToShortDateString());
            try
            {
                string iddiag = dataGridView2.CurrentRow.Cells["id_diag"].Value.ToString().Trim();
                string idkart = dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim();
                dataGridView3.DataSource = dal.GetNaznKart(idkart, iddiag);
                settingsDGV_nazn();
            }
            catch { }
        }

        private void dataGridView6_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox9.Text = dataGridView6.CurrentRow.Cells["tema"].Value.ToString().Trim();
            richTextBox5.Text = dataGridView6.CurrentRow.Cells["text"].Value.ToString().Trim();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            dal.saveNewkoment(richTextBox4.Text, DateTime.Now.ToString(), textBox8.Text, dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim());
            dataGridView6.DataSource = dal.Getkoment(dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim());
            settingsDGV_kom();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dal.updatekoment(richTextBox5.Text, textBox9.Text, dataGridView6.CurrentRow.Cells["id_koment"].Value.ToString().Trim());
            dataGridView6.DataSource = dal.Getkoment(dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim());
            settingsDGV_kom();
        
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы действительно хотите удалить?",
                     "Удаление", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
            dal.deletekoment(dataGridView6.CurrentRow.Cells["id_koment"].Value.ToString().Trim());
            dataGridView6.DataSource = dal.Getkoment(dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim());
            settingsDGV_kom();
                    break;
                case DialogResult.No: break;
            }
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (zap == false)
            {
                mciSendString("open new type waveaudio alias Som", null, 0, 0);
                mciSendString("record Som", null, 0, 0);
                zap = true;
                button13.Text = "Остановить и сохранить запись";
                button13.BackColor = Color.Red;
                idcartsave = dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim();
            }
            else 
            {
                string sobr = idcartsave + DateTime.Now.ToFileTimeUtc().ToString();
                mciSendString("pause Som", null, 0, 0);
                mus = "audio/"+sobr+".wav"; 
                mciSendString("save Som " + mus, null, 0, 0); 
                mciSendString("close Som", null, 0, 0);
                dal.saveNewzvukkoment(idcartsave, mus, DateTime.Now.ToString());
                dataGridView7.DataSource = dal.Getzvukkoment(dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim());
                settingsDGV_zkom();
                zap = false;
                button13.Text = "Начать запись";
                button13.BackColor = Color.DarkOrange;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            player.SoundLocation=dataGridView7.CurrentRow.Cells["path"].Value.ToString().Trim();
            if (plstp == false)
            {
                player.Load();
                player.Play();
                plstp = true;
                button12.Text = "Остановить";
            }
            else { 
                player.Stop();
                plstp = false;
                button12.Text = "Воспроизвести";
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы действительно хотите удалить?",
                     "Удаление", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
            File.Delete(dataGridView7.CurrentRow.Cells["path"].Value.ToString().Trim());
            dal.deletezvukkoment(dataGridView7.CurrentRow.Cells["id_zvukkoment"].Value.ToString().Trim());
            dataGridView7.DataSource = dal.Getzvukkoment(dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim());
            settingsDGV_zkom();
            break;
                case DialogResult.No: break;
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (zap == true)
            {
                string sobr = idcartsave + DateTime.Now.ToFileTimeUtc().ToString();
                mciSendString("pause Som", null, 0, 0);
                mus = "audio/" + sobr + ".wav";
                mciSendString("save Som " + mus, null, 0, 0);
                mciSendString("close Som", null, 0, 0);
                dal.saveNewzvukkoment(idcartsave, mus, DateTime.Now.ToString());
                dataGridView7.DataSource = dal.Getzvukkoment(dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim());
                settingsDGV_zkom();
                zap = false;
                button13.Text = "Начать запись";
                button13.BackColor = Color.DarkOrange;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            poseshenie pos = new poseshenie();
            pos.dataGridView3.DataSource = dal.GetzPos(dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim());
            pos.settingsDGV_poser();
            pos.dateTimePicker2.Value = DateTime.Now;
            pos.textBox2.Text = "0";
            if (pos.ShowDialog(this) == DialogResult.OK)
            {
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int itx = 1;
            string dsled = "";
            int fs = 10;
            try
            {
                Word.Application app = new Word.Application();
                Word.Document doc = app.Documents.Add();
                doc.Paragraphs.SpaceAfter = 1;
                doc.Paragraphs.SpaceBefore = 1;
                doc.Paragraphs.LineSpacing = 10;

                doc.Paragraphs[itx].Range.Text = dataGridView1.CurrentRow.Cells["fiopac"].Value.ToString().Trim() + " (ID: " + dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim()+")";
                doc.Paragraphs[itx].Range.Font.Size = 20;
                doc.Paragraphs[itx].Range.Font.Bold = 1;
                doc.Paragraphs[itx].Alignment = 0;
                doc.Paragraphs[itx].Range.Font.Size = fs;
                doc.Paragraphs[itx].Range.Font.Bold = 1;
                itx++;

                doc.Paragraphs.Add();
                itx++;

                doc.Paragraphs.Add();
                doc.Paragraphs[itx].Range.Text = "Дата первичного посещения: " + dataGridView8.Rows[0].Cells["datapos"].Value.ToString().Trim() + "           Вес: " + dataGridView8.Rows[0].Cells["ves"].Value.ToString().Trim() + " Рост " + dataGridView1.CurrentRow.Cells["rost"].Value.ToString().Trim() + "см.  " + label15.Text;
                doc.Paragraphs[itx].Range.Font.Size = 20;
                doc.Paragraphs[itx].Range.Font.Bold = 1;
                doc.Paragraphs[itx].Alignment = 0;
                doc.Paragraphs[itx].Range.Font.Size = fs;
                doc.Paragraphs[itx].Range.Font.Bold = 0;
                itx++;

                doc.Paragraphs.Add();
                doc.Paragraphs[itx].Range.Text = "Дата повторного посещения: ";
                doc.Paragraphs[itx].Range.Font.Size = 20;
                doc.Paragraphs[itx].Range.Font.Bold = 1;
                doc.Paragraphs[itx].Alignment = 0;
                doc.Paragraphs[itx].Range.Font.Size = fs;
                doc.Paragraphs[itx].Range.Font.Bold = 0;
                itx++;

                for (int x = 1; x < dataGridView8.RowCount; x++)
                {
                    doc.Paragraphs.Add();
                    doc.Paragraphs[itx].Range.Text = "                                                           " + dataGridView8.Rows[x].Cells["datapos"].Value.ToString().Trim() + "           Вес: " + dataGridView8.Rows[x].Cells["ves"].Value.ToString().Trim();
                    doc.Paragraphs[itx].Range.Font.Size = 20;
                    doc.Paragraphs[itx].Range.Font.Bold = 1;
                    doc.Paragraphs[itx].Alignment = 0;
                    doc.Paragraphs[itx].Range.Font.Size = fs;
                    doc.Paragraphs[itx].Range.Font.Bold = 0;
                    itx++;
                    dsled = dataGridView8.Rows[x].Cells["dadasled"].Value.ToString().Trim();
                }

                doc.Paragraphs.Add();
                doc.Paragraphs[itx].Range.Text = "Дата следующего посещения: "+dsled;
                doc.Paragraphs[itx].Range.Font.Size = 20;
                doc.Paragraphs[itx].Range.Font.Bold = 1;
                doc.Paragraphs[itx].Alignment = 0;
                doc.Paragraphs[itx].Range.Font.Size = fs;
                doc.Paragraphs[itx].Range.Font.Bold = 0;
                itx++;

                doc.Paragraphs.Add();
                itx++;


                for (int x = 0; x < dataGridView2.RowCount; x++)
                {
                    doc.Paragraphs.Add();
                    doc.Paragraphs[itx].Range.Text = dataGridView2.Rows[x].Cells["nazv"].Value.ToString().Trim() + "(" + dataGridView2.Rows[x].Cells["opis"].Value.ToString().Trim()+")";
                    doc.Paragraphs[itx].Range.Font.Size = 20;
                    doc.Paragraphs[itx].Range.Font.Bold = 1;
                    doc.Paragraphs[itx].Alignment = 0;
                    doc.Paragraphs[itx].Range.Font.Size = fs;
                    doc.Paragraphs[itx].Range.Font.Bold = 1;
                    itx++;

                    int ll = 1;
                    dataGridView9.DataSource = dal.GetNaznKart(dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim(), dataGridView2.Rows[x].Cells["id_diag"].Value.ToString().Trim());
                        for (int y = 0; y < dataGridView9.RowCount; y++)
                        {
                    doc.Paragraphs.Add();
                    doc.Paragraphs[itx].Range.Text = ll.ToString() + ". " + dataGridView9.Rows[y].Cells["nazvn"].Value.ToString().Trim() + " " + dataGridView9.Rows[y].Cells["dozirovka"].Value.ToString().Trim() + " в течение " + dataGridView9.Rows[y].Cells["dlitelnost"].Value.ToString().Trim() + " (" + dataGridView9.Rows[y].Cells["status"].Value.ToString().Trim() + " " + dataGridView9.Rows[y].Cells["dnaz"].Value.ToString().Trim() + ")";
                    doc.Paragraphs[itx].Range.Font.Size = 20;
                    doc.Paragraphs[itx].Range.Font.Bold = 1;
                    doc.Paragraphs[itx].Alignment = 0;
                    doc.Paragraphs[itx].Range.Font.Size = fs;
                    doc.Paragraphs[itx].Range.Font.Bold = 0;
                    itx++;
                    ll++;

                    itx=doc.Paragraphs.Count + 1;
                    doc.Paragraphs.Add();
                    doc.Paragraphs[itx].Range.Text = "Способ применения: "+dataGridView9.Rows[y].Cells["opisn"].Value.ToString().Trim();
                    doc.Paragraphs[itx].Range.Font.Size = 20;
                    doc.Paragraphs[itx].Range.Font.Bold = 1;
                    doc.Paragraphs[itx].Alignment = 0;
                    doc.Paragraphs[itx].Range.Font.Size = fs;
                    doc.Paragraphs[itx].Range.Font.Bold = 0;
                    itx = doc.Paragraphs.Count + 1;
                    ll++;

                        }    
                    doc.Paragraphs.Add();
                    itx++;
                    doc.Paragraphs.Add();
                    itx++;
                }

                
                app.Visible = true;
            }
            catch { }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void миииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (arhiv == "0")
            {
                миииToolStripMenuItem.Text = "Перейти в обычный режим";
                arhiv = "1";
                dataGridView1.DataSource = dal.GetKarta(textBox10.Text, textBox11.Text, numericUpDown4.Value.ToString(), numericUpDown5.Value.ToString(), comboBox6.Text, comboBox7.Text, arhiv);
                settingsDGV_kart();
                dataGridView5.DataSource = dal.GetDiag();
                settingsDGV_diag();
                dataGridView1.Select();
                миииToolStripMenuItem.BackColor = Color.Red;
            }
            else
            {
                    миииToolStripMenuItem.Text = "Перейти в архив";
                    arhiv = "0";    
                    dataGridView1.DataSource = dal.GetKarta(textBox10.Text, textBox11.Text, numericUpDown4.Value.ToString(), numericUpDown5.Value.ToString(), comboBox6.Text, comboBox7.Text, arhiv);
                    settingsDGV_kart();
                    dataGridView5.DataSource = dal.GetDiag();
                    settingsDGV_diag();
                    dataGridView1.Select();
                    миииToolStripMenuItem.BackColor = Color.White;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["arhiv"].Value.ToString().Trim() == "0")
            {
                dal.updateKartatoArh(dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim());
            }
            else
            {
                dal.updateKartatoNorm(dataGridView1.CurrentRow.Cells["id_kart"].Value.ToString().Trim());
            }
            if (arhiv == "0")
            {
                миииToolStripMenuItem.Text = "Перейти в обычный режим";
                arhiv = "1";
                dataGridView1.DataSource = dal.GetKarta(textBox10.Text, textBox11.Text, numericUpDown4.Value.ToString(), numericUpDown5.Value.ToString(), comboBox6.Text, comboBox7.Text, arhiv);
                settingsDGV_kart();
                dataGridView5.DataSource = dal.GetDiag();
                settingsDGV_diag();
                dataGridView1.Select();
                миииToolStripMenuItem.BackColor = Color.Red;
            }
            else
            {
                миииToolStripMenuItem.Text = "Перейти в архив";
                arhiv = "0";
                dataGridView1.DataSource = dal.GetKarta(textBox10.Text, textBox11.Text, numericUpDown4.Value.ToString(), numericUpDown5.Value.ToString(), comboBox6.Text, comboBox7.Text, arhiv);
                settingsDGV_kart();
                dataGridView5.DataSource = dal.GetDiag();
                settingsDGV_diag();
                dataGridView1.Select();
                миииToolStripMenuItem.BackColor = Color.White;
            }
            tabControl1.SelectedIndex = 0;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dal.GetKarta(textBox10.Text, textBox11.Text, numericUpDown4.Value.ToString(), numericUpDown5.Value.ToString(), comboBox6.Text, comboBox7.Text, arhiv);
            settingsDGV_kart();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dal.GetKarta(textBox10.Text, textBox11.Text, numericUpDown4.Value.ToString(), numericUpDown5.Value.ToString(), comboBox6.Text, comboBox7.Text, arhiv);
            settingsDGV_kart();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dal.GetKarta(textBox10.Text, textBox11.Text, numericUpDown4.Value.ToString(), numericUpDown5.Value.ToString(), comboBox6.Text, comboBox7.Text, arhiv);
            settingsDGV_kart();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dal.GetKarta(textBox10.Text, textBox11.Text, numericUpDown4.Value.ToString(), numericUpDown5.Value.ToString(), comboBox6.Text, comboBox7.Text, arhiv);
            settingsDGV_kart();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dal.GetKarta(textBox10.Text, textBox11.Text, numericUpDown4.Value.ToString(), numericUpDown5.Value.ToString(), comboBox6.Text, comboBox7.Text, arhiv);
            settingsDGV_kart();
            
        }

        private void comboBox6_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dal.GetKarta(textBox10.Text, textBox11.Text, numericUpDown4.Value.ToString(), numericUpDown5.Value.ToString(), comboBox6.Text, comboBox7.Text, arhiv);
            settingsDGV_kart();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dal.GetKarta(textBox10.Text, textBox11.Text, numericUpDown4.Value.ToString(), numericUpDown5.Value.ToString(), comboBox6.Text, comboBox7.Text, arhiv);
            settingsDGV_kart();
        }

        private void comboBox7_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dal.GetKarta(textBox10.Text, textBox11.Text, numericUpDown4.Value.ToString(), numericUpDown5.Value.ToString(), comboBox6.Text, comboBox7.Text, arhiv);
            settingsDGV_kart();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            string kl = textBox12.Text;
            string mn = textBox13.Text;
            int bmw = int.Parse(dal.CheckUser(kl, mn));

            if (bmw > 0)
            {
                dataGridView1.DataSource = dal.GetKarta(textBox10.Text, textBox11.Text, numericUpDown4.Value.ToString(), numericUpDown5.Value.ToString(), comboBox6.Text, comboBox7.Text, arhiv);
                settingsDGV_kart();
                dataGridView5.DataSource = dal.GetDiag();
                settingsDGV_diag();

                comboBox6.Items.Clear();
                comboBox5.Items.Clear();
                comboBox3.Items.Clear();
                ArrayList al = dal.GetDozaCombo();
                foreach (string s in al)
                {
                    comboBox5.Items.Add(s);
                }

                ArrayList asb = dal.GetdlitCombo();
                foreach (string s in asb)
                {
                    comboBox3.Items.Add(s);
                }

                ArrayList asb11 = dal.GetDiagCombo();
                foreach (string s in asb11)
                {
                    comboBox6.Items.Add(s);
                }

                ArrayList asb1143 = dal.GetNaznCombo();
                foreach (string s in asb1143)
                {
                    comboBox7.Items.Add(s);
                }


                dataGridView1.Select();
                menuStrip1.Visible = true;
                tabControl1.Visible = true;
                panel7.Visible = false;
            }
            else { label57.Visible = true; }

        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button18_Click(sender, e);
            }
        }
    }
}
