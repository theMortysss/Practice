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
                //var supplier = context.Suppliers;
                var supplier = from sup in context.Suppliers
                               join product in context.Products on sup.ProductId equals product.Id
                               select new
                               {
                                   Поставщик = sup.Name,
                                   Товар = product.Name,
                                   Цена = sup.Price,
                                   Количество = sup.Quantity,
                                   Расстояние = sup.DistanceKm,
                                   Доставка = sup.ShippingCoast,
                                   Предпочтение = sup.Preference
                               };
                dataGridView5.DataSource = supplier.ToList();
            }
        }
    }
}
