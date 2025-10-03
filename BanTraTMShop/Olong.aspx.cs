using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanTraTMShop
{
    public partial class Olong : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTraByDanhMuc(4);
            }
        }

        private void LoadTraByDanhMuc(int maLoaiTra)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            List<Tra> ds = dbHelper.GetTraByDanhMuc(maLoaiTra); // Truyền ID_DanhMuc vào
            Repeater.DataSource = ds;
            Repeater.DataBind();
        }
    }
}