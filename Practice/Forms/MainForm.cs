namespace Practice
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            RemoveExpiretionProducts();
            GenerateRndQuantity();
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
                (from supplier in context.Suppliers
                 select supplier.Quantity).ToList().ForEach(s=>s.Equals(rnd.Next(0,100)));
                context.SaveChanges();
            }
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            using (var db = new Practicebase())
            {
                db.SaveChanges();
            }
        }
    }
}