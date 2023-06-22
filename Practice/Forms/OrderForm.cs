﻿using Practice.Entitys;
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
                dataGridView2.DataSource = MakeOrder(products);
            }
        }

        public static List<Product> MakeOrder(List<Product> products)
        {
            var goodsToRestock = new List<Product>();

            goodsToRestock.AddRange(GetProductsToRestock(products));

            return goodsToRestock;
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
            MessageBox.Show($"{recentProductSales.Count}");
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            //using (var context = new Practicebase())
            //{
            //    foreach (var product in context.Products.ToList())
            //    {
            //        MessageBox.Show($"{product.GetRecentSales(7).Count}");

            //    }
            //}
        }
    }
}
