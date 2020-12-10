using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace t1
{
    public partial class Default : System.Web.UI.Page
    {
        DAL dal = new DAL();

        public void lbView()
        {
            ListBox1.Items.Clear();
            List<List<string>> Mas = dal.GetcatalogLB();
            for (int i = 0; i < Mas[0].Count(); i++)
            {
                ListBox1.Items.Add(Mas[0][i].ToString());
            }
        }

        public void table2(string cat, bool all)
        {
            List<List<string>> Mas = dal.GetTovar(cat, all);
            Div1.InnerHtml = "";
            Div1.InnerHtml += "<table border='1' width='100%'>";
            Div1.InnerHtml += "<th>";
            Div1.InnerHtml += "Товар";
            Div1.InnerHtml += "</th>";
            Div1.InnerHtml += "<th>";
            Div1.InnerHtml += "Цена";
            Div1.InnerHtml += "</th>";
            Div1.InnerHtml += "<th>";
            Div1.InnerHtml += "Количество";
            Div1.InnerHtml += "</th>";
            Div1.InnerHtml += "<th>";
            Div1.InnerHtml += "Дата привоза";
            Div1.InnerHtml += "</th>";
            for (int i = 0; i < Mas[0].Count(); i++)
            {
                Div1.InnerHtml += "<tr>";
                Div1.InnerHtml += "<td>";
                Div1.InnerHtml += Mas[0][i].ToString();
                Div1.InnerHtml += "</td>";

                Div1.InnerHtml += "<td>";
                Div1.InnerHtml += Mas[1][i].ToString();
                Div1.InnerHtml += "</td>";

                Div1.InnerHtml += "<td>";
                Div1.InnerHtml += Mas[2][i].ToString();
                Div1.InnerHtml += "</td>";

                Div1.InnerHtml += "<td>";
                Div1.InnerHtml += Mas[3][i].ToString();
                Div1.InnerHtml += "</td>";

                Div1.InnerHtml += "<td>";
                Div1.InnerHtml += "<a href='deleteTask.aspx?tovarid=" + Mas[4][i].ToString() + "'>Открыть товар</a>";
                Div1.InnerHtml += "</td>";

                Div1.InnerHtml += "<td>";
                Div1.InnerHtml += "<a href='deleteTask.aspx?tovarid=" + Mas[4][i].ToString() + "'>Удалить</a>";
                Div1.InnerHtml += "</td>";

                Div1.InnerHtml += "</tr>";
            }
            Div1.InnerHtml += "</table>";
        }



        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            lbView();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void ListBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string m=dal.GetCatalogByCB(ListBox1.SelectedValue);
            table2(m, false);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("addNew.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("prihod.aspx");
        }
    }
}