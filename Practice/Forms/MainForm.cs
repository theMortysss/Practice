namespace Practice
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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

        }
    }
}