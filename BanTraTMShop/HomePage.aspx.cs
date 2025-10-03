using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanTraTMShop
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var master = (SitePage)this.Master;
            if (master != null)
            {
                master.SearchButtonClick += Master_SearchButtonClick;
            }
            if (!IsPostBack)
            {
                DatabaseHelper dbHelper = new DatabaseHelper();
                List<Tra> books = dbHelper.GetTeas();
                Repeater.DataSource = books;
                Repeater.DataBind();
                TimkiemSP(null);
            }
        }
        private void Master_SearchButtonClick(object sender, EventArgs e)
        {
            var master = (SitePage)this.Master;
            string searchTerm = master.GetSearchTerm();
            TimkiemSP(searchTerm);
        }
        private void TimkiemSP(string searchTerm)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = @"CHUTHIHONG\SQLEXPRESS",
                InitialCatalog = "QLBANHANG_FINAL1",
                IntegratedSecurity = true,
                Encrypt = true,
                TrustServerCertificate = true
            };
            using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
            {
                string query = "SELECT maTra, tenTra, giaBan, anh FROM TRA";
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query += " WHERE tenTra LIKE @SearchTerm";
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Repeater.DataSource = dt;
                Repeater.DataBind();
            }
        }
    }
}