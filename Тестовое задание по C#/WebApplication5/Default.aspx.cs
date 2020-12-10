using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class Default : System.Web.UI.Page
    {
        DAL dal = new DAL();
        bool bmw = true;
        /*
        public void table()
        {
            List<List<string>> Mas = dal.GetTask();
            Response.Write("<div align='Center'>");
            Response.Write("<table border='1'>");
            Response.Write("<th>");
            Response.Write("Задания");
            Response.Write("</th>");
            Response.Write("<th>");
            Response.Write("Статус выполнения");
            Response.Write("</th>");
            for (int i = 0; i < Mas[0].Count(); i++)
            {
                Response.Write("<tr>");
                Response.Write("<td>");
                Response.Write(Mas[0][i].ToString());
                Response.Write("</td>");

                Response.Write("<td>");
                string process = "";
                if (Mas[2][i].ToString() == "0")
                {
                    process = "В процессе";
                }
                else {
                    process = "Выполнено";
                }

                    Response.Write(process);
                Response.Write("</td>");

                Response.Write("<td>");
                Response.Write("<a href='updateStatus.aspx?taskid=" + Mas[1][i].ToString() + "'>Считать выполненной</a>");
                Response.Write("</td>");
                Response.Write("<td>");
                Response.Write("<a href='updateTask.aspx?taskid=" + Mas[1][i].ToString() + "'>Изменить</a>");
                Response.Write("</td>");
                Response.Write("<td>");
                Response.Write("<a href='deleteTask.aspx?taskid=" + Mas[1][i].ToString() + "'>Удалить</a>");
                Response.Write("</td>");
                Response.Write("</tr>");
            }
            Response.Write("</table>");
            Response.Write("</div>");
        }
        */
        public void table2(bool b, bool all)
        {
            List<List<string>> Mas = dal.GetTask(b, all);
            Div1.InnerHtml = "";
            Div1.InnerHtml += "<div align='Center'>";
            Div1.InnerHtml += "<table border='1'>";
            Div1.InnerHtml += "<th>";
            Div1.InnerHtml += "Задания";
            Div1.InnerHtml += "</th>";
            Div1.InnerHtml += "<th>";
            Div1.InnerHtml += "Статус выполнения";
            Div1.InnerHtml += "</th>";
            for (int i = 0; i < Mas[0].Count(); i++)
            {
                Div1.InnerHtml += "<tr>";
                Div1.InnerHtml += "<td>";
                Div1.InnerHtml += Mas[0][i].ToString();
                Div1.InnerHtml += "</td>";

                Div1.InnerHtml += "<td>";
                string process = "";
                if (Mas[2][i].ToString() == "0")
                {
                    process = "В процессе";
                }
                else
                {
                    process = "Выполнено";
                }

                Div1.InnerHtml += process;
                Div1.InnerHtml += "</td>";

                Div1.InnerHtml += "<td>";
                Div1.InnerHtml += "<a href='updateStatus.aspx?taskid=" + Mas[1][i].ToString() + "'>Считать выполненной</a>";
                Div1.InnerHtml += "</td>";
                Div1.InnerHtml += "<td>";
                Div1.InnerHtml += "<a href='updateTask.aspx?taskid=" + Mas[1][i].ToString() + "'>Изменить</a>";
                Div1.InnerHtml += "</td>";
                Div1.InnerHtml += "<td>";
                Div1.InnerHtml += "<a href='deleteTask.aspx?taskid=" + Mas[1][i].ToString() + "'>Удалить</a>";
                Div1.InnerHtml += "</td>";
                Div1.InnerHtml += "</tr>";
            }
            Div1.InnerHtml += "</table>";
            Div1.InnerHtml += "</div>";
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {
                dal.saveNewTask(TextBox1.Text);
                TextBox1.Text = "";
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            TextBox1.Text = "7777777";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            table2(false, false);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            table2(true, false);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            table2(true, true);
        }
    }
}