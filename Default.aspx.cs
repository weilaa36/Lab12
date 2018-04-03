using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab12
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBox1.Text))
            {
                lblerror.Text = ("Please entetr a valid keyword");
                return;
            }

            else
            {
                lblerror.Text = " ";
                //Step 1 : Get Data
                var books = Books.GetBooks();

                // Step 2 Sort data via LINQ
                var bookTitles = from bookItem in books
                                 where bookItem.Title.Contains(txtBox1.Text)
                                 orderby bookItem.Price
                                 select bookItem;
                // Step 3: Bind the results to a data control 
                grdOne.DataSource = bookTitles;
                grdOne.DataBind(); // must always call this after setting data source 
            }
        }
    }
}