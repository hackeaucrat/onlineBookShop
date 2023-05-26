using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using static onlineBookShop.basket;

namespace onlineBookShop

   
{
    public class BasketItem
    {
        public int BookID { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public decimal BookPrice { get; set; }
        public string BookImg { get; set; }
    }



    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBooks();
            }
        }

        public class Book
        {
            public int BookID { get; set; }
            public string BookTitle { get; set; }
            public string BookAuthor { get; set; }
            public decimal BookPrice { get; set; }
            public string BookImg { get; set; }
        }

        protected void LoadBooks()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["onlineBookShopConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT bookID, bookTitle, bookAuthor, bookPrice, bookImg FROM books";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                foreach (DataRow row in dataTable.Rows)
                {
                    string fileName = row["bookImg"].ToString();
                    string imageUrl = ResolveUrl("~/Images/" + fileName);
                    row["bookImg"] = imageUrl;
                }

                rptBooks.DataSource = dataTable;
                rptBooks.DataBind();

                reader.Close();
            }
        }

        protected void btnAddToCart_Command(object sender, CommandEventArgs e)
        {
            int bookID = Convert.ToInt32(e.CommandArgument);
            Book book = GetBookDetails(bookID);
            BasketItem basketItem = new BasketItem
            {
                BookID = book.BookID,
                BookTitle = book.BookTitle,
                BookAuthor = book.BookAuthor,
                BookPrice = book.BookPrice,
                BookImg = book.BookImg
            };
            AddToBasket(basketItem);
            Response.Redirect("basket.aspx");
        }

        protected Book GetBookDetails(int bookID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["onlineBookShopConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT bookID, bookTitle, bookAuthor, bookPrice, bookImg FROM books WHERE bookID = @BookID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookID", bookID);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Book book = new Book
                    {
                        BookID = Convert.ToInt32(reader["bookID"]),
                        BookTitle = reader["bookTitle"].ToString(),
                        BookAuthor = reader["bookAuthor"].ToString(),
                        BookPrice = Convert.ToDecimal(reader["bookPrice"]),
                        BookImg = reader["bookImg"].ToString()
                    };

                    reader.Close();
                    return book;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
        }


        protected void AddToBasket(BasketItem basketItem)
        {
            string imageUrl = ResolveUrl(basketItem.BookImg);
            basketItem.BookImg = imageUrl;
            List<BasketItem> basketItems = Session["BasketItems"] as List<BasketItem>;
            if (basketItems == null)
            {
                basketItems = new List<BasketItem>();
            }
            basketItems.Add(basketItem);
            Session["BasketItems"] = basketItems;
        }
    }
}

