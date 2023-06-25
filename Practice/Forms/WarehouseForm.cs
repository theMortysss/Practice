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
                               join supplier in decanContext.Suppliers on product.SupplierId equals supplier.Id
                               select new
                               {
                                   Название = product.Name,
                                   Цена = product.Price,
                                   Поставщик = supplier.Name,
                                   Фасовка = product.PackingG,
                                   Количество = product.Quantity,
                                   Годность = product.ExpirationDate,
                               };
                dataGridView1.DataSource = products.ToList();
            }
        }
    }
}
