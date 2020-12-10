using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace t1
{
    public partial class deleteCategory : System.Web.UI.Page
    {
        string catid = "";
        DAL dal = new DAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            catid = Request.QueryString["catid"];
            dal.deleteCatalog(catid);
            Response.Write("id="+catid);
            Response.Redirect("addNew.aspx");

        }

    }
}