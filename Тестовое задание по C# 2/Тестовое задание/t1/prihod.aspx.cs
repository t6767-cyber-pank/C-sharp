using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace t1
{
    public partial class prihod : System.Web.UI.Page
    {
        DAL dal = new DAL();
        string ddlist;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            CheckBoxList1.Items.Clear();
            List<List<string>> Mas = dal.GetcatalogLB();
            for (int i = 0; i < Mas[0].Count(); i++)
            {
                CheckBoxList1.Items.Add(Mas[0][i].ToString());
            }
            try
            {
                ddlist = dal.GetCatalogByCB(CheckBoxList1.SelectedValue);
            }
            catch { }
            CheckBoxList1.DataBind();
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "")
            {
                try
                {
                    ddlist = dal.GetCatalogByCB(CheckBoxList1.SelectedValue);
                }
                catch { }
                Label5.Text = "Товар добавлен";
                dal.saveNewTovar("tovar", TextBox1.Text, TextBox2.Text, TextBox3.Text, Calendar1.SelectedDate.ToShortDateString(), ddlist);
                dal.saveNewTovar("tovarPrihod", TextBox1.Text, TextBox2.Text, TextBox3.Text, Calendar1.SelectedDate.ToShortDateString(), ddlist);
                TextBox1.Text = "";
                TextBox2.Text = "0";
                TextBox3.Text = "0";
            }
            else
            {
                Label5.Text = "Проверьте правильность заполнения";

            }
        }

        protected void DropDownList1_TextChanged(object sender, EventArgs e)
        {
          
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
  
        }

        protected void ListBox1_TextChanged(object sender, EventArgs e)
        {
 
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}