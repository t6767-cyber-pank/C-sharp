using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace t1
{
    public partial class addNew : System.Web.UI.Page
    {
        DAL dal = new DAL();

        public void table()
        {
            List<List<string>> Mas = dal.GetcatalogLB();
            Response.Write("<div align='Center'>");
            Response.Write("<table border='1'>");
            Response.Write("<th>");
            Response.Write("Категории продуктов");
            Response.Write("</th>");
            for (int i = 0; i < Mas[0].Count(); i++ )
            {
                Response.Write("<tr>");
                Response.Write("<td>");
                Response.Write(Mas[0][i].ToString());
                Response.Write("</td>");
                Response.Write("<td>");
                Response.Write("<a href='deleteCategory.aspx?catid=" + Mas[1][i].ToString() + "'>Удалить</a>");
                //Response.Write(Mas[1][i].ToString());
                Response.Write("</td>");
                Response.Write("</tr>");
            }
            Response.Write("</table>");
            Response.Write("</div>");
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            if (TextBox1.Text != "")
            {
                dal.saveNewCategory(TextBox1.Text);
                TextBox1.Text = "";
                Label1.Text = "Данные введены успешно";
            }
            else 
            {
                Label1.Text = "Поле не должно быть пустым";
            }
        }
    }
}