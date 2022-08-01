using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuongTrungNguyen
{
    class Products

    {
        private int productID;
        private string productname;
        private int categoryID;
        private int supplierID;
        private double unitPrice;
        private string quantity;

        public int ProductID
        {
            get
            {
                return productID;
            }

            set
            {
                productID = value;
            }
        }

        public string Productname
        {
            get
            {
                return productname;
            }

            set
            {
                productname = value;
            }
        }

        public int CategoryID
        {
            get
            {
                return categoryID;
            }

            set
            {
                categoryID = value;
            }
        }

        public int SupplierID
        {
            get
            {
                return supplierID;
            }

            set
            {
                supplierID = value;
            }
        }

        public double UnitPrice
        {
            get
            {
                return unitPrice;
            }

            set
            {
                unitPrice = value;
            }
        }

        public string Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }
    }
}
