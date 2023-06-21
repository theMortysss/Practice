using Practice.Entitys;
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
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            using (var context = new Practicebase())
            {
                var order = from product in context.Products
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
                dataGridView2.DataSource = order.ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MakeOrder();
        }

        private List<Product> MakeOrder()
        {
            return null;
        }

        
    }
}
