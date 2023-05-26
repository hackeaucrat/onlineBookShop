using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineBookShop
{
	public partial class manage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				booksDSTableAdapters.booksTableAdapter booksTable = new booksDSTableAdapters.booksTableAdapter();
				ddlbookID.DataSource = booksTable.GetAllBookIDs();
				ddlbookID.DataTextField = "bookID";
				ddlbookID.DataValueField = "bookID";
				ddlbookID.DataBind();
			}

		}

		

		protected void btnRetrieve_Click(object sender, EventArgs e)
		{
			booksDSTableAdapters.booksTableAdapter booksTable = new booksDSTableAdapters.booksTableAdapter();
			DataTable resultBook = new DataTable();
			resultBook = booksTable.GetBookByID(int.Parse(ddlbookID.SelectedValue.ToString()));

			txtbookTitle.Text = resultBook.Rows[0]["bookTitle"].ToString();
			txtbookAuthor.Text = resultBook.Rows[0]["bookAuthor"].ToString();
			txtbookPrice.Text = resultBook.Rows[0]["bookPrice"].ToString();

			txtbookImg.Text = resultBook.Rows[0]["bookImg"].ToString();
			imgPreview.ImageUrl = "images/" + resultBook.Rows[0]["bookImg"].ToString();
		}

		protected void btnUpdate_Click(object sender, EventArgs e)
		{
			booksDSTableAdapters.booksTableAdapter booksTable = new booksDSTableAdapters.booksTableAdapter();
			booksTable.UpdateQuery(txtbookTitle.Text, decimal.Parse(txtbookPrice.Text), txtbookAuthor.Text, txtbookImg.Text, int.Parse(ddlbookID.SelectedValue.ToString()));
			Response.Redirect(Request.RawUrl);
		}

		protected void btnDelete_Click(object sender, EventArgs e)
		{
			booksDSTableAdapters.booksTableAdapter booksTable = new booksDSTableAdapters.booksTableAdapter();
			booksTable.DeleteBook(int.Parse(ddlbookID.SelectedValue.ToString()));
			Response.Redirect(Request.RawUrl);
		}

		protected void btnCreate_Click1(object sender, EventArgs e)
		{
			booksDSTableAdapters.booksTableAdapter booksTable = new booksDSTableAdapters.booksTableAdapter();
			booksTable.InsertBook(txtbookTitle.Text, txtbookAuthor.Text, decimal.Parse(txtbookPrice.Text),  txtbookImg.Text);

			Response.Redirect(Request.RawUrl);
		}
	}
}