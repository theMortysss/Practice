using Microsoft.EntityFrameworkCore;
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
    public partial class SaleForm : Form
    {
        private int? amount { get; set; }
        private List<Product> products { get; set; }
        public SaleForm()
        {
            InitializeComponent();
            using (var db = new Practicebase())
            {
                comboBox1.DataSource = db.Products.ToList();
                comboBox1.ValueMember = "Id";
                comboBox1.DisplayMember = "Name";
            }
        }

        private void SaleForm_Load(object sender, EventArgs e)
        {
            using (var db = new Practicebase())
            {
                dataGridView4.DataSource = db.Sales.ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var db = new Practicebase())
            {
                var q = int.Parse(textBox1.Text);
                var product = db.Products.Find((int)comboBox1.SelectedValue);
                if (q > amount)
                {
                    MessageBox.Show("На складе не хватает товара");
                }
                else
                {
                    product.Quantity -= q;
                    Sale sale = new Sale
                    {
                        ProductId = product.Id,
                        Quantity = q,
                        DateOfSale = dateTimePicker1.Value
                    };
                    db.Sales.Add(sale);
                    db.SaveChanges();
                    dataGridView4.DataSource = db.Sales.ToList();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var db = new Practicebase())
            {
                var product = db.Products.Find((int)comboBox1.SelectedValue);
                amount = product.Quantity;
                label1.Visible = true;
                label1.Text = $"Доступно: {amount}";
            }
        }
    }
}
