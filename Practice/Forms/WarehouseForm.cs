using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice
{
    public partial class WarehouseForm : Form
    {
        public WarehouseForm()
        {
            InitializeComponent();
            RefreshDataProduct();
        }
        private void RefreshDataProduct()
        {
            using (Practicebase decanContext = new Practicebase())
            {
                var products = from product in decanContext.Products
                               select new
                               {
                                   Id = product.Id,
                                   Name = product.Name,
                                   Price = product.Price,
                                   SupplierId = product.SupplierId,
                                   PackingG = product.PackingG,
                                   Quantity = product.Quantity,
                                   ExpirationDate = product.ExpirationDate,
                               };
                dataGridView1.DataSource = products.ToList();
            }
        }
    }
}
