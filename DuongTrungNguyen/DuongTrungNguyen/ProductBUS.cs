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


        public bool AddProduct(Products p)
        {
            return dal.AddProduct(p);
        }

        public bool UpdateProduct(Products p)
        {
            return dal.UpdateProduct(p);
        }

        public bool DeleteProduct(Products p)
        {
            return dal.DeleteProduct(p);
        }
    }
}
