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
                
                if (busProduct.AddProduct(p)>0)
                {
                    MessageBox.Show("Thêm Thành Công", "Thông Báo");
                    busProduct.LoadListProduct(gvSanPham);
                }
                else
                {
                    MessageBox.Show("Thêm Thất Bại. Tên Sản Phẩm Đã Tồn Tại", "Thông báo");
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message , "Lỗi Thêm Sản Phẩm");
            } 
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            
                Products p = new Products();
                try
                {
                    p.Productname = txtTenSP.Text;
                    p.CategoryID = int.Parse(cbLoaiSP.SelectedValue.ToString());
                    p.SupplierID = int.Parse(cbNCC.SelectedValue.ToString());
                    p.UnitPrice = double.Parse(txtDonGia.Text);
                    p.Quantity = txtSoLuong.Text;
                    p.ProductID = int.Parse(txtMaSP.Text);
                if (busProduct.UpdateProduct(p) > 0)
                {
                    MessageBox.Show("Cập Nhập Thành Công", "Thông Báo");
                    busProduct.LoadListProduct(gvSanPham);

                }
                else
                {
                    MessageBox.Show("Cập Nhập Thất Bại. Mã Sản Phẩm Không Tồn Tại", "Thông Báo");
                }
            }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

               
              
            
           
      
        }
        private void btXoa_Click(object sender, EventArgs e)
        {
            
            try
            {
                Products p = new Products();
                p.ProductID = int.Parse(txtMaSP.Text);

                if (busProduct.DeleteProduct(p) > 0)
                {
                    MessageBox.Show("Xóa Thành Công", "Thông Báo");
                    busProduct.LoadListProduct(gvSanPham);
                }
                else
                {
                    MessageBox.Show("Xóa Thất Bại. Mã Sản Phẩm Không Tồn Tại", "Thông Báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message , "Lỗi Delete Sản Phẩm");
                
            }
        }

        private void gvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < gvSanPham.Rows.Count)
                {
                    txtMaSP.Text = gvSanPham.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtTenSP.Text = gvSanPham.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtDonGia.Text = gvSanPham.Rows[e.RowIndex].Cells["UnitPrice"].Value.ToString();
                    txtSoLuong.Text = gvSanPham.Rows[e.RowIndex].Cells["UnitsInStock"].Value.ToString();
                    cbLoaiSP.SelectedValue = int.Parse(gvSanPham.Rows[e.RowIndex].Cells["CategoryID"].Value.ToString());
                    cbNCC.SelectedValue = int.Parse(gvSanPham.Rows[e.RowIndex].Cells["SupplierID"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btThoat_Click(object sender, EventArgs e) { this.Close();}
    }

}

