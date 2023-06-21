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
    public partial class SupplierForm : Form
    {
        public SupplierForm()
        {
            InitializeComponent();
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            using (var context = new Practicebase())
            {
                var supplier = from sup in context.Suppliers
                               select new
                               {
                                   ID = sup.Id,
                                   Product = sup.ProductId,
                                   Price = sup.Price,
                                   Quantity = sup.Quantity,
                                   Distance = sup.DistanceKm,
                                   Shipping = sup.ShippingCoast,
                                   Preference = sup.Preference
                               };
                dataGridView5.DataSource = supplier.ToList();
            }
        }
    }
}
