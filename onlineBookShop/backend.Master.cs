using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineBookShop
{
	public partial class backend : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["user"] == null ) {
				Response.Redirect("home.aspx");
			}
			else
			{
				ldlUname.Text = "(Login as: " + Session["user"] + ")";
			}

		}

		protected void lblLogout_Click(object sender, EventArgs e)
		{
			//Session["user"] = null;
			//Response.Redirect("home.aspx");
		}
	}
}