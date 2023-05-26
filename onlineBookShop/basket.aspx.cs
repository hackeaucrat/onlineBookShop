using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Collections.Generic;

namespace onlineBookShop
{
    public partial class basket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBasketItems();
                DisplayLoggedInUser();
            }
        }

        protected void DisplayLoggedInUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                string username = User.Identity.Name;
                lblLoggedInUser.Text = "Logged in as: " + username;
                lblLoggedInUser.Visible = true;
            }
            else
            {
                lblLoggedInUser.Visible = false;
            }
        }

        protected string GetImageUrl(object bookImg)
        {
            string fileName = bookImg.ToString();
            string imageUrl = ResolveUrl("~/Images/" + fileName);
            return imageUrl;
        }



        protected void LoadBasketItems()
        {
            List<BasketItem> basketItems;

            if (User.Identity.IsAuthenticated)
            {
                string username = User.Identity.Name;
                basketItems = GetBasketItemsFromDatabase(username);
            }
            else
            {
                basketItems = Session["BasketItems"] as List<BasketItem>;
            }

            if (basketItems != null)
            {
                rptBasketItems.DataSource = basketItems;
                rptBasketItems.DataBind();
                decimal totalPrice = CalculateTotalPrice(basketItems);
                litTotalPrice.Text = totalPrice.ToString("0.00");
            }
        }

        protected List<BasketItem> GetBasketItemsFromDatabase(string username)
        {
            return new List<BasketItem>();
        }

        protected decimal CalculateTotalPrice(List<BasketItem> basketItems)
        {
            decimal totalPrice = 0;
            foreach (BasketItem item in basketItems)
            {
                totalPrice += item.BookPrice;
            }

            return totalPrice;
        }

        protected void btnRemoveFromCart_Command(object sender, CommandEventArgs e)
        {
            int bookID = Convert.ToInt32(e.CommandArgument);
            RemoveFromBasket(bookID);
            LoadBasketItems();
        }

        protected void RemoveFromBasket(int bookID)
        {
            List<BasketItem> basketItems = Session["BasketItems"] as List<BasketItem>;
            if (basketItems != null)
            {
                BasketItem itemToRemove = basketItems.Find(item => item.BookID == bookID);
                if (itemToRemove != null)
                {
                    basketItems.Remove(itemToRemove);
                    Session["BasketItems"] = basketItems;
                }
            }
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            ClearBasket();
            Response.Redirect("login.aspx");
        }

        protected void ClearBasket()
        {
            Session.Remove("BasketItems");
        }
    }
}

