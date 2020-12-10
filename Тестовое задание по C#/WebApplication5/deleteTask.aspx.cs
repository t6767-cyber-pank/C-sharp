using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class deleteTask : System.Web.UI.Page
    {
        string taskId = "";
        DAL dal = new DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            taskId = Request.QueryString["taskid"];
            dal.deleteTask(taskId);
            Response.Write("id=" + taskId);
            Response.Redirect("Default.aspx");
        }
    }
}