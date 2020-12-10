using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class updateTask : System.Web.UI.Page
    {
        DAL dal = new DAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            Hidden1.Value = Request.QueryString["taskid"];
            TextBox1.Text = dal.selectTask(Hidden1.Value);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            dal.updateTask(TextBox1.Text, Hidden1.Value);
            Response.Write(TextBox1.Text + " " + Hidden1.Value);
            Response.Redirect("Default.aspx");
        }
    }
}