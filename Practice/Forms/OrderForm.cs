using Microsoft.EntityFrameworkCore;
using Practice.Entitys;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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
        private const int SaleDayCount = 7;
        private const double OrderAmountMargin = 0.3;

        public OrderForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new Practicebase())
            {
                var sales = db.Sales.ToList();
                var products = db.Products.ToList();
                var supplies = db.Supplies.ToList();
                var suppliers = db.Suppliers.ToList();

                List<int> tmp = products.Select(p => p.Quantity).ToList();

                var order = MakeOrder(products);


                var list = from product in order
                           join supplier in suppliers on product.SupplierId equals supplier.Id
                           select new
                           {
                               Название = product.Name,
                               Цена = product.Price,
                               Поставщик = supplier.Name,
                               Фасовка = product.PackingG,
                               Количество = product.Quantity,
                               Годность = product.ExpirationDate
                           };

                dataGridView2.DataSource = list.ToList();
                
                foreach (var item in order)
                {
                    var sup = new Supplie
                    {
                        SupplierId = item.SupplierId,
                        ProductId = item.Id,
                        Quantity = item.Quantity,
                        DateOfSupplie = DateTime.Now,
                    };
                    db.Supplies.Add(sup);
                    db.Products.Find(item.Id).Quantity += tmp[item.Id - 1];
                }
                
                db.SaveChanges();

            }
        }

        private static List<Product> MakeOrder(List<Product> productss)
        {
            using (var db = new Practicebase())
            {
                var goodsToRestock = new List<Product>();
                var suppliers = db.Suppliers.ToList();
                foreach (var sup in suppliers)
                {
                    db.Entry(sup).Reference(s => s.Product).Load();
                    if (sup.Preference == 1)
                    {
                        var products = productss.Where(p => p.SupplierId == sup.Id).ToList();
                        goodsToRestock.AddRange(GetProductsToRestock(products));
                    }
                    else if (sup.Preference == 2)
                    {
                        var products = productss.Where(p => p.SupplierId == sup.Id).ToList();
                        goodsToRestock.AddRange(GetProductsToRestock(products));
                    }
                    else
                    {
                        break;
                    }
                }

                return goodsToRestock;
            }
        }

        private static List<Product> GetProductsToRestock(List<Product> products)
        {
            var toRestock = new List<Product>();
            foreach (var product in products)
                CheckAddToRestockList(product, toRestock);

            return toRestock;
        }

        private static void CheckAddToRestockList(Product product, List<Product> toRestock)
        {
            var recentProductSales = product.GetRecentSales(SaleDayCount);
            var expectedAmount = GetExpectedOrderAmount(recentProductSales);
            var batch = product;
            if (product.Quantity < expectedAmount)
            {
                batch.Quantity = expectedAmount - product.Quantity;
                toRestock.Add(batch);
            }
        }

        private static int GetExpectedOrderAmount(List<Sale> recentSales)
        {
            if (recentSales.Count == 0)
                return 0;
            var avg = recentSales.Sum(s => s.Quantity) / (double)SaleDayCount;
            var orderAmount = (int)Math.Ceiling(avg);
            var margin = (int)Math.Ceiling(orderAmount * OrderAmountMargin);
            return orderAmount + margin;
        }
    }
}
