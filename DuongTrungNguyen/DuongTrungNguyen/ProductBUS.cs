using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuongTrungNguyen
{
     class ProductBUS
    {
        ProductDAL dal=new ProductDAL();


        public void LoadListProduct(DataGridView gv)
        {
            gv.DataSource = dal.LoadListProduct();
        }

        public void LoadListCategories(ComboBox cb)
        {
            cb.DataSource = dal.LoadListCatagories();
            cb.DisplayMember = "CategoryName";
            cb.ValueMember = "CategoryID";
        }

        public void LoadListSupplier(ComboBox cb)
        {
            cb.DataSource = dal.LoadListSupplier();
            cb.DisplayMember = "CompanyName";
            cb.ValueMember = "SupplierID";
        }


        public int AddProduct(Products p)
        {
            int result = 0;
            if (dal.CheckProductName(p)) //Neu San Pham Ton Tai
            {
                result = -1;
            }
            else // San Pham Chua Ton Tai Thi Them Goi ADDPRODUCT DAL
            {
                result = dal.AddProduct(p); //tra ve 0 ADD that bai,1 ADD thanh cong
            }
            return result;
        }

        public int UpdateProduct(Products p)
        {
            int result = 0;
            if (dal.CheckProductID(p)) //Neu Ma San Pham Ton Tai
            {
                dal.UpdateProduct(p);
                result = 1;
            }
            
            return result;
        }

        public int DeleteProduct(Products p)
        {
            int result = 0;
            if (dal.CheckProductID(p)) //Neu Ma San Pham Ton Tai
            {
                dal.DeleteProduct(p);
                result = 1;
            }
            return result;
        }
    }
}
