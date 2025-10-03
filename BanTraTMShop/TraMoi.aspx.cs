using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanTraTMShop
{
    public partial class TraMoi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DatabaseHelper dbHelper = new DatabaseHelper();
                List<Tra> ds = dbHelper.GetTraMoi();
                Repeater.DataSource = ds;
                Repeater.DataBind();
            }
        }
    }
}