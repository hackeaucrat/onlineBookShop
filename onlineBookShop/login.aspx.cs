using System;
using System.Web.UI;
using System.Web.Security;
using System.Configuration;
using System.Data.SqlClient;


namespace onlineBookShop
{
    public partial class login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (ValidateLogin(username, password))
            {
                if (username == "admin1" || username == "admin2")
                {
                    FormsAuthentication.SetAuthCookie(username, false);
                    Session["user"] = username;
                    Response.Redirect("admin.aspx");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(username, false);
                    Session["user"] = username;
                    Response.Redirect("basket.aspx");
                }
            }
            else
            {
                lblErrorMessage.Text = "Invalid username or password.";
                lblErrorMessage.Visible = true;
            }
        }



        private bool ValidateLogin(string username, string password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["onlineBookShopConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }

    }
}
