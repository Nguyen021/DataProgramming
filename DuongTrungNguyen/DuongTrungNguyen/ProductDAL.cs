using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuongTrungNguyen
{
    class ProductDAL
    {
        public SqlConnection conn;

        public ProductDAL()
        {
            ConnetData();
        }

        public void ConnetData()
        {
            String connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            conn = new SqlConnection(connStr);
        }


        public DataTable LoadListProduct()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            String query = "Select * from Products";
            da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            return dt;
        }

        public DataTable LoadListCatagories()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            String query = "Select CategoryID,CategoryName from Categories";
            da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            return dt;
        }

        public DataTable LoadListSupplier()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            String query = "Select SupplierID,CompanyName from Suppliers";
            da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            return dt;
        }
        //Ham Them San Pham
        public int AddProduct(Products p)
        {
            int result=0;
            int n = 0;
            try
            {
               
            SqlCommand sqlCom;
            string query = String.Format("insert into Products ( ProductName,CategoryID," +
                "SupplierID,UnitPrice,UnitsInStock ) values (N'{0}', {1}, {2}, {3}, {4})"
                      , p.Productname, p.CategoryID, p.SupplierID, p.UnitPrice, p.Quantity);
            sqlCom = new SqlCommand(query, conn);
            conn.Open();
            n = int.Parse(sqlCom.ExecuteNonQuery().ToString());
            result =  n >0?  1:0;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                result = 0;
            }
            finally {conn.Close(); }
            return result;
        }
        //Ham Sua San Pham True Update Thanh Cong---False Update that bai
        public bool UpdateProduct(Products p)
        {
            bool result = false;
            SqlCommand sqlCom;
            try
            {
                string query = String.Format("update Products set ProductName=N'{0}',CategoryID={1}," +
                "SupplierID={2},UnitPrice={3},UnitsInStock={4} where ProductID={5}"
                      , p.Productname, p.CategoryID, p.SupplierID, p.UnitPrice, p.Quantity,p.ProductID);
                sqlCom = new SqlCommand(query, conn);
           
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
        //Ham Xoa San Pham
        public bool DeleteProduct(Products p)
        {
            bool result = false;
            SqlCommand sqlCom;
            try
            {
                string query = String.Format("delete Products where ProductID={0}", p.ProductID);
                sqlCom = new SqlCommand(query, conn);
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
        //Kiem Tra Ten San Pham Da Ton Tai True/da co False?Chua Co
        public bool CheckProductName(Products p)
        {
            bool result = true;
            int n = 0;

            try
            {
                string query = String.Format("select count(*) from Products Where ProductName=N'{0}'", p.Productname);
                SqlCommand sqlCom = new SqlCommand(query, conn);
                conn.Open();
                n = int.Parse(sqlCom.ExecuteScalar().ToString());
                result= n> 0?true :false;
            }
            catch (SqlException)
            {

                result=false;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        //Ham Kiem Tra ID San Pham Co Ton Tai--- true/neu ton tai,---false khong ton tai
        public bool CheckProductID(Products p)
        {
            bool result = true;
            int n = 0;

            try
            {
                string query = String.Format("select count(*) from Products Where ProductID=N'{0}'", p.ProductID);
                SqlCommand sqlCom = new SqlCommand(query, conn);
                conn.Open();
                n = int.Parse(sqlCom.ExecuteScalar().ToString());
                result = n > 0 ? true : false;
            }
            catch (SqlException)
            {
                result = false;
            }
            finally
            {conn.Close();}
            return result;
        }
    }
}
