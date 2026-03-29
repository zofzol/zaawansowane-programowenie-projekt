namespace zaawansowane_programowenie_projekt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txtRows.Text = "5";
            txtCols.Text = "5";
            txtErrors.Text = "3";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtRows.Text, out int m) || !int.TryParse(txtCols.Text, out int n) || !int.TryParse(txtErrors.Text, out int errors))
            {
                MessageBox.Show("Podaj poprawne liczby!");
                return;
            }

            var generator = new InstanceGenerator();
            var matrix = generator.Generate(m, n, errors);
            DisplayMatrix(matrix);
        }

        private void DisplayMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            dataGridView1.RowCount = rows;
            dataGridView1.ColumnCount = cols;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    dataGridView1[j, i].Value = matrix[i, j];
                }
            }
            SetSquareCells(30);

        }

        private void SetSquareCells(int size)
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.Width = size;
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = size;
            }
        }
        private void Form1_Resize(object sender, EventArgs e)
        {

        }
    }
}
