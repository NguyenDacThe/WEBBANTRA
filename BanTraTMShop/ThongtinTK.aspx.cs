using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanTraTMShop
{
    public partial class ThongtinTK : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["maTaiKhoan"] != null)
                {
                    LoadUserInfo();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
        private void LoadUserInfo()
        {
            string userId1 = Session["maTaiKhoan"]?.ToString();
            if (string.IsNullOrEmpty(userId1))
            {
                Response.Redirect("Login.aspx");
            }
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
                try
                {
                    conn.Open();
                    int userId = Convert.ToInt32(Session["maTaiKhoan"]);

                    string query = "SELECT hoTen, matKhau, email, soDT, ngaySinh FROM NGUOIDUNG WHERE maTaiKhoan = @maTaiKhoan";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maTaiKhoan", userId);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            lblhoTen.Text = reader["hoTen"].ToString();
                            lblemail.Text = reader["email"].ToString();
                            lblsoDT.Text = reader["soDT"].ToString();
                            lblngaySinh.Text = Convert.ToDateTime(reader["ngaySinh"]).ToString("yyyy-MM-dd");
                            lblmatKhau.Text = reader["matKhau"].ToString();

                            txthoTen.Text = reader["hoTen"].ToString();
                            txtemail.Text = reader["email"].ToString();
                            txtsoDT.Text = reader["soDT"].ToString();
                            txtngaySinh.Text = Convert.ToDateTime(reader["ngaySinh"]).ToString("yyyy-MM-dd");
                            txtmatKhau.Text = reader["matKhau"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Xảy ra lỗi: " + ex.Message;
                }
            }
        }
            protected void btnEdit_Click(object sender, EventArgs e)
            {
                ToggleEditMode(true);

                txthoTen.Visible = true;
                txtemail.Visible = true;
                txtsoDT.Visible = true;
                txtngaySinh.Visible = true;
                txtmatKhau.Visible = true;

                lblhoTen.Visible = false;
                lblemail.Visible = false;
                lblsoDT.Visible = false;
                lblngaySinh.Visible = false;
                lblmatKhau.Visible = false;

                btnSave.Visible = true;
                btnCancel.Visible = true;
                btnEdit.Visible = false;
            }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Hiển thị thông tin dạng label 
            lblhoTen.Text = txthoTen.Text;
            lblemail.Text = txtemail.Text;
            lblsoDT.Text = txtsoDT.Text;
            lblngaySinh.Text = txtngaySinh.Text;
            lblmatKhau.Text = txtmatKhau.Text;
            //Ẩn các text (không sửa đc)
            txthoTen.Visible = false;
            txtemail.Visible = false;
            txtsoDT.Visible = false;
            txtngaySinh.Visible = false;
            txtmatKhau.Visible = false;

            lblhoTen.Visible = true;
            lblemail.Visible = true;
            lblsoDT.Visible = true;
            lblngaySinh.Visible = true;
            lblmatKhau.Visible = true;

            btnEdit.Visible = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;

            string userId = Session["maTaiKhoan"]?.ToString();
            if (string.IsNullOrEmpty(userId))
            {
                lblMessage.Text = "Bạn cần đăng nhập để thực hiện thao tác này.";
                lblMessage.Visible = true;
                return;
            }
            if (!DateTime.TryParse(txtngaySinh.Text.Trim(), out DateTime parsedDate))
            {
                lblMessage.Text = "Ngày sinh không hợp lệ. Vui lòng nhập đúng định dạng (yyyy-MM-dd).";
                lblMessage.Visible = true;
                return;
            }
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
                try
                {
                    conn.Open();
                    string query = "UPDATE NGUOIDUNG SET hoTen = @hoTen, email = @email, soDT = @soDT, ngaySinh = @ngaySinh, matKhau = @matKhau WHERE maTaiKhoan = @maTaiKhoan";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@hoTen", txthoTen.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtemail.Text.Trim());
                        cmd.Parameters.AddWithValue("@soDT", txtsoDT.Text.Trim());
                        cmd.Parameters.AddWithValue("@ngaySinh", txtngaySinh.Text.Trim());
                        cmd.Parameters.AddWithValue("@matKhau", txtmatKhau.Text.Trim());
                        cmd.Parameters.AddWithValue("@maTaiKhoan", userId);
                        cmd.ExecuteNonQuery();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            //lblMessage.Text = "Thông tin đã được cập nhật.";
                            //lblMessage.Visible = true;
                            string script = "alert('Thông tin đã được cập nhật.');";
                            ClientScript.RegisterStartupScript(this.GetType(), "UpdateSuccess", script, true);
                            ToggleEditMode(false);
                            LoadUserInfo();
                        }
                        else
                        {
                            lblMessage.Text = "Không tìm thấy tài khoản để cập nhật.";
                            lblMessage.Visible = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Xảy ra lỗi khi cập nhật: " + ex.Message;
                }
            }
        }
            protected void btnCancel_Click(object sender, EventArgs e)
            {
                ToggleEditMode(false);

                txthoTen.Visible = false;
                txtemail.Visible = false;
                txtsoDT.Visible = false;
                txtngaySinh.Visible = false;
                txtmatKhau.Visible = false;

                lblhoTen.Visible = true;
                lblemail.Visible = true;
                lblsoDT.Visible = true;
                lblngaySinh.Visible = true;
                lblmatKhau.Visible = true;

                btnEdit.Visible = true;
                btnSave.Visible = false;
                btnCancel.Visible = false;
            }

            private void ToggleEditMode(bool isEditMode)
            {
                lblhoTen.Visible = !isEditMode;
                lblemail.Visible = !isEditMode;
                lblsoDT.Visible = !isEditMode;
                lblngaySinh.Visible = !isEditMode;
                lblmatKhau.Visible = !isEditMode;

                txthoTen.Visible = isEditMode;
                txtemail.Visible = isEditMode;
                txtsoDT.Visible = isEditMode;
                txtngaySinh.Visible = isEditMode;
                txtmatKhau.Visible = isEditMode;

                btnEdit.Visible = !isEditMode;
                btnSave.Visible = isEditMode;
                btnCancel.Visible = isEditMode;
            }
            protected void btnLogout_Click(object sender, EventArgs e)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }
    }
 }