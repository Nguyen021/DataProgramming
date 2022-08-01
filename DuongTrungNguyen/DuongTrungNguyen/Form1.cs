using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuongTrungNguyen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn;

        private void ConnetData()
        {
            String connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            conn = new SqlConnection(connStr);
        }
        private DataTable LoadListProduct()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            String query = "Select * from Products";
            da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            return dt;
        }

        private DataTable LoadListCatagories()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            String query = "Select CategoryID,CategoryName from Categories";
            da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            return dt;
        }

        private DataTable LoadListSupplier()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            String query = "Select SupplierID,CompanyName from Suppliers";
            da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            return dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ConnetData();
            gvSanPham.DataSource = LoadListProduct();
            cbLoaiSP.DataSource = LoadListCatagories();
            cbLoaiSP.DisplayMember = "CategoryName";
            cbLoaiSP.ValueMember = "CategoryID";

            cbNCC.DataSource = LoadListSupplier();
            cbNCC.DisplayMember = "CompanyName";
            cbNCC.ValueMember = "SupplierID";
        }
        private bool AddProduct(Products p)
        {
            bool result = false;
            SqlCommand sqlCom;
            string query = String.Format("insert into Products ( ProductName,CategoryID," +
                "SupplierID,UnitPrice,QuantityPerUnit ) values (N'{0}', {1}, {2}, {3}, {4})"
                      ,p.Productname,p.CategoryID,p.SupplierID,p.UnitPrice,p.Quantity);
            sqlCom = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                sqlCom.ExecuteNonQuery();
                result = true;

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                result = false;
            }
            finally { conn.Close(); }
            return result;
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            Products p = new Products();
            p.Productname = txtTenSP.Text;
            p.CategoryID = int.Parse(cbLoaiSP.SelectedValue.ToString());
            p.SupplierID= int.Parse(cbNCC.SelectedValue.ToString());
            p.UnitPrice = double.Parse(txtDonGia.Text);
            p.Quantity = txtSoLuong.Text;
            if (AddProduct(p))
            {
                MessageBox.Show("Them Thanh Cong");
                gvSanPham.DataSource = LoadListProduct();

            }
            else
            {
                MessageBox.Show("Them that bai");
            }
        }
    }
}
