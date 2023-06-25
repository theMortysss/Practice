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
                               join supllier in context.Suppliers on supplie.SupplierId equals supllier.Id
                               select new
                               {
                                   Поставщик = supllier.Name,
                                   Количество = supplie.Quantity,
                                   ДатаПоставки = supplie.DateOfSupplie,
                               };
                dataGridView3.DataSource = supplies.ToList();
            }
        }
    }
}
