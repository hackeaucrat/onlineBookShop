using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineBookShop
{
	public partial class view : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			booksDSTableAdapters.booksTableAdapter booksTable = new booksDSTableAdapters.booksTableAdapter();
			gvView.DataSource = booksTable.GetAllBooks();
			gvView.DataBind();
		}

		protected void btnRefresh_Click(object sender, EventArgs e)
		{
			booksDSTableAdapters.booksTableAdapter booksTable = new booksDSTableAdapters.booksTableAdapter();

			if (ddlSort.SelectedValue.ToString() == "Ascending")
			{
				gvView.DataSource = booksTable.GetBookSortPriceAscCat();
			}
			else
			{
				gvView.DataSource = booksTable.GetBookSortPriceDescCat();
			}
			gvView.DataBind();
		}
	}
}