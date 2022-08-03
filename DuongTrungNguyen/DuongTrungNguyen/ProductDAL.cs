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

        public bool AddProduct(Products p)
        {
            bool result = false;
            SqlCommand sqlCom;
            string query = String.Format("insert into Products ( ProductName,CategoryID," +
                "SupplierID,UnitPrice,QuantityPerUnit ) values (N'{0}', {1}, {2}, {3}, {4})"
                      , p.Productname, p.CategoryID, p.SupplierID, p.UnitPrice, p.Quantity);
            sqlCom = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                sqlCom.ExecuteNonQuery();
                result = true;

            }
            catch (SqlException ex)
            {
                throw ex;
                result = false;
            }
            finally {conn.Close(); }
            return result;
        }

        public bool UpdateProduct(Products p)
        {
            bool result = false;
            SqlCommand sqlCom;
            string query = String.Format("update Products set ProductName=N'{0}',CategoryID={1}," +
                "SupplierID={2},UnitPrice={3},QuantityPerUnit={4} where ProductID={5}"
                      , p.Productname, p.CategoryID, p.SupplierID, p.UnitPrice, p.Quantity,p.ProductID);
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

        public bool DeleteProduct(Products p)
        {
            bool result = false;
            SqlCommand sqlCom;
            string query = String.Format("delete Products where ProductID={0}"
                      , p.ProductID);
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
    }
}
