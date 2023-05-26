using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;


namespace onlineBookShop
{
	public partial class admin : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("login.aspx");
            }

        }

        protected void btnManage_Click(object sender, EventArgs e)
        {
			Response.Redirect("manage.aspx");
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Response.Redirect("view.aspx");
        }
    }
}