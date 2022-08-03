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
        ProductBUS busProduct = new ProductBUS();


        //private DataTable LoadListProduct()
        //{
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter da;
        //    String query = "Select * from Products";
        //    da = new SqlDataAdapter(query, dal.conn);
        //    da.Fill(dt);
        //    return dt;
        //}

        //private DataTable LoadListCatagories()
        //{
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter da;
        //    String query = "Select CategoryID,CategoryName from Categories";
        //    da = new SqlDataAdapter(query, dal.conn);
        //    da.Fill(dt);
        //    return dt;
        //}

        //private DataTable LoadListSupplier()
        //{
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter da;
        //    String query = "Select SupplierID,CompanyName from Suppliers";
        //    da = new SqlDataAdapter(query, dal.conn);
        //    da.Fill(dt);
        //    return dt;
        //}
        private void Form1_Load(object sender, EventArgs e)
        {
            busProduct.LoadListProduct(gvSanPham);
            busProduct.LoadListSupplier(cbNCC);
            busProduct.LoadListCategories(cbLoaiSP);
            //dal.ConnetData();
            //gvSanPham.DataSource = LoadListProduct();
            //cbLoaiSP.DataSource = LoadListCatagories();
            //cbLoaiSP.DisplayMember = "CategoryName";
            //cbLoaiSP.ValueMember = "CategoryID";

            //cbNCC.DataSource = LoadListSupplier();
            //cbNCC.DisplayMember = "CompanyName";
            //cbNCC.ValueMember = "SupplierID";



        }
        //private bool AddProduct(Products p)
        //{
        //    bool result = false;
        //    SqlCommand sqlCom;
        //    string query = String.Format("insert into Products ( ProductName,CategoryID," +
        //        "SupplierID,UnitPrice,QuantityPerUnit ) values (N'{0}', {1}, {2}, {3}, {4})"
        //              ,p.Productname,p.CategoryID,p.SupplierID,p.UnitPrice,p.Quantity);
        //    sqlCom = new SqlCommand(query, dal.conn);
        //    try
        //    {
        //        dal.conn.Open();
        //        sqlCom.ExecuteNonQuery();
        //        result = true;

        //    }
        //    catch (SqlException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        result = false;
        //    }
        //    finally { dal.conn.Close(); }
        //    return result;
        //}
        private void btThem_Click(object sender, EventArgs e)
        {

            try
            {

                Products p = new Products();
                p.Productname = txtTenSP.Text;
                p.CategoryID = int.Parse(cbLoaiSP.SelectedValue.ToString());
                p.SupplierID = int.Parse(cbNCC.SelectedValue.ToString());
                p.UnitPrice = double.Parse(txtDonGia.Text);
                p.Quantity = txtSoLuong.Text;
                busProduct.AddProduct(p);
                MessageBox.Show("Thêm Thành Công", "Thông Báo");
                busProduct.LoadListProduct(gvSanPham);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message , "Lỗi Thêm Sản Phẩm");
            }

             
            
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            try
            {
                Products p = new Products();
                p.Productname = txtTenSP.Text;
                p.CategoryID = int.Parse(cbLoaiSP.SelectedValue.ToString());
                p.SupplierID = int.Parse(cbNCC.SelectedValue.ToString());
                p.UnitPrice = double.Parse(txtDonGia.Text);
                p.Quantity = txtSoLuong.Text;
                p.ProductID = int.Parse(txtMaSP.Text);
                busProduct.UpdateProduct(p);
                busProduct.LoadListProduct(gvSanPham);
                MessageBox.Show("Update Thành Công !!", "Thông Báo",MessageBoxButtons.OK);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Lỗi Update Sản Phẩm");
            }
      
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                Products p = new Products();
                p.ProductID = int.Parse(txtMaSP.Text);
                busProduct.DeleteProduct(p);
                busProduct.LoadListProduct(gvSanPham);
                MessageBox.Show("Delete Thành Công !!", "Thông Báo", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message , "Lỗi Delete Sản Phẩm");
                
            }
        }

        //click row cell in Gridview
        //private void gvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        //{

        //    try
        //    {
        //        if (gvSanPham.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)/*(e.RowIndex >= 0 && e.RowIndex < gvSanPham.Rows.Count)*/
        //        {
        //            gvSanPham.CurrentRow.Selected = true;
        //            DataGridViewRow row = gvSanPham.Rows[e.RowIndex];
        //            txtMaSP.Text = row.Cells["ProductID"].FormattedValue.ToString();
        //            txtTenSP.Text = row.Cells["prodcutname"].FormattedValue.ToString();
        //            txtDonGia.Text = row.Cells["UniPrice"].FormattedValue.ToString();
        //            txtSoLuong.Text = row.Cells["QuantityPerunit"].FormattedValue.ToString();
        //            cbLoaiSP.SelectedValue = int.Parse(row.Cells["CategoryID"].FormattedValue.ToString());
        //            cbNCC.SelectedValue = int.Parse(row.Cells["SupplierID"].FormattedValue.ToString());
        //        }
        //        else
        //        {

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private void gvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < gvSanPham.Rows.Count)
                {
                    txtMaSP.Text = gvSanPham.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtTenSP.Text = gvSanPham.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtDonGia.Text = gvSanPham.Rows[e.RowIndex].Cells["UnitPrice"].Value.ToString();
                    txtSoLuong.Text = gvSanPham.Rows[e.RowIndex].Cells["QuantityPerUnit"].Value.ToString();
                    cbLoaiSP.SelectedValue = int.Parse(gvSanPham.Rows[e.RowIndex].Cells["CategoryID"].Value.ToString());
                    cbNCC.SelectedValue = int.Parse(gvSanPham.Rows[e.RowIndex].Cells["SupplierID"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}

