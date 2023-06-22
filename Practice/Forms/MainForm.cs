using Microsoft.Identity.Client;
using Practice.Entitys;
using System.Diagnostics;
using System.Windows.Forms;

namespace Practice
{
    public partial class MainForm : Form
    {
        private const int SaleDayCount = 7;
        private const double OrderAmountMargin = 0.3;

        public MainForm()
        {
            InitializeComponent();
            RemoveExpiretionProducts();
            GenerateRndQuantity();
            GetPreference();
        }
        private static void GetPreference()
        {
            using (var context = new Practicebase())
            {
                var suppliers = context.Suppliers.ToList();
                foreach (var sup in suppliers)
                {
                    context.Entry(sup).Reference(s => s.Product).Load();
                    if (sup.Preference == 1)
                        sup.Product.SupplierId = sup.Id;
                }
                context.SaveChanges();
            }
        }
        private void RemoveExpiretionProducts()
        {
            using (var context = new Practicebase())
            {
                var unsoldSupplies = context.Supplies.Where(s => s.Quantity > 0).ToList();

                foreach (var supply in unsoldSupplies)
                {
                    context.Entry(supply).Reference(s => s.Product).Load();
                    if (supply.DateOfSupplie.AddDays(supply.Product.ExpirationDate) < DateTime.Today)
                        supply.Quantity = 0;
                }
                context.SaveChanges();
            }
        }
        private void GenerateRndQuantity()
        {
            using (var context = new Practicebase())
            {
                var rnd = new Random();

                var supplier = context.Suppliers.ToList();
                var sales = context.Sales.ToList();
                var products = context.Products.ToList();

                foreach (var sup in supplier)
                {
                    sup.Quantity = rnd.Next(0, 100);
                    sup.Price = rnd.Next(100,150);
                    sup.DistanceKm = rnd.Next(1,20);
                    sup.ShippingCoast = rnd.Next(30, 50);

                    sup.Preference = (int)(sup.Price + (decimal)sup.DistanceKm + sup.ShippingCoast);

                    if (sup.Quantity < CheckAddToRestockList(context.Products.Find(sup.ProductId)))
                    {
                        sup.Preference = 3;
                    }
                    else if(sup.Preference != supplier.Min(sup => sup.Price + (decimal)sup.DistanceKm + sup.ShippingCoast))
                    {
                        sup.Preference = 2;
                    }
                    else
                    {
                        sup.Preference = 1;
                    }
                }
               
                context.SaveChanges();
            }
        }

        private static int CheckAddToRestockList(Product product)
        {
            var recentProductSales = product.GetRecentSales(SaleDayCount);
            var expectedAmount = GetExpectedOrderAmount(recentProductSales);
            var batch = product;
            if (product.Quantity < expectedAmount)
            {
                return batch.Quantity = expectedAmount - product.Quantity;
            }
            return int.MaxValue;
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

        private void button6_Click(object sender, EventArgs e)
        {
            var form = new SupplieForm();
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var form = new WarehouseForm();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new SaleForm();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new OrderForm();
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form = new SupplierForm();
            form.ShowDialog();
        }
    }
}