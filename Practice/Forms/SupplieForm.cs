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
    public partial class SupplieForm : Form
    {
        public SupplieForm()
        {
            InitializeComponent();
            RefreshDataSupplie();
        }
        public void RefreshDataSupplie()
        {
            using (var context = new Practicebase())
            {
                var supplies = from supplie in context.Supplies
                               select new
                               {
                                   Id = supplie.Id,
                                   Supplier_Id = supplie.SupplierId,
                                   Quantity = supplie.Quantity,
                                   DateOfSupplie = supplie.DateOfSupplie,
                               };
                dataGridView3.DataSource = supplies.ToList();
            }
        }
    }
}
