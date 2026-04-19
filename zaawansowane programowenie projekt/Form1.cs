using System.ComponentModel;

namespace zaawansowane_programowenie_projekt
{
    public partial class Form1 : Form
    {

        private BackgroundWorker bw = new BackgroundWorker();
        public Form1()
        {
            InitializeComponent();

            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;

            bw.DoWork += Bw_DoWork;
            bw.ProgressChanged += Bw_ProgressChanged;
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bw.WorkerReportsProgress = true;
            txtRows.Text = "5";
            txtCols.Text = "5";
            txtErrors.Text = "0";
            txtIterations.Text = "1000";
            txtTabuLength.Text = "15";
            txtNeighborhood.Text = "50"; 
            txtTime.Text = "30";   
            txtSeed.Text = "2137"; 


        }
        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            var args = (object[])e.Argument;

            int[,] matrix = (int[,])args[0];
            int iterations = (int)args[1];
            int tabuLength = (int)args[2];
            int neighborhood = (int)args[3];
            int seed = (int)args[4];
            int maxTime = (int)args[5];

            var tabu = new TabuSearch();

            var result = tabu.Run(matrix, iterations, tabuLength, neighborhood, seed, maxTime, (BackgroundWorker)sender);

            e.Result = result;
        }

        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lblStatus.Text = e.ProgressPercentage + "%";
        }
        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var result = (Solution)e.Result;

            int[,] matrix = GetMatrixFromGrid();

            ShowSolution(result, matrix);

            tabControl1.SelectedTab = tabPage3;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtRows.Text, out int m) || !int.TryParse(txtCols.Text, out int n) || !int.TryParse(txtErrors.Text, out int errors))
            {
                MessageBox.Show("Podaj wartoœæ liczbow¹!");
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
            ColorCells();

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
            //wysrodekowanie cyferek
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void ColorCells()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null)
                        continue;

                    if ((int)cell.Value == 1)
                        cell.Style.BackColor = Color.LightPink;
                    else
                        cell.Style.BackColor = ColorTranslator.FromHtml("#d3e171");

                    //cell.Value = ""; 
                }
            }
        }
        private void Form1_Resize(object sender, EventArgs e)
        {

        }

        private void CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell.Value == null || !int.TryParse(cell.Value.ToString(), out int val) || (val != 0 && val != 1))
            {
                cell.Value = 0;
                val = 0;
            }

            // zmiana koloru
            ColorCells();
        }

        private void CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell.Value == null)
                cell.Value = 0;

            int val = (int)cell.Value;

            // zmiana wartosci
            if (val == 0)
                val = 1;
            else
                val = 0;

            cell.Value = val;

            // zmiana koloru
            //ColorCells();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void txtErrors_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        private int[,] GetMatrixFromGrid()
        {
            int rows = dataGridView1.RowCount;
            int cols = dataGridView1.ColumnCount;

            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    matrix[i, j] = Convert.ToInt32(dataGridView1[j, i].Value);

            return matrix;
        }

        private void ShowSolution(Solution sol, int[,] matrix)
        { 

        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtIterations.Text, out int iterations) ||
                !int.TryParse(txtTabuLength.Text, out int tabuLength) ||
                !int.TryParse(txtNeighborhood.Text, out int neighborhood) ||
                !int.TryParse(txtTime.Text, out int maxTime) ||
                !int.TryParse(txtSeed.Text, out int seed))
            {
                MessageBox.Show("Podaj wartoœci liczbowe!");
                return;
            }

            int[,] matrix = GetMatrixFromGrid();

            bw.RunWorkerAsync(new object[] { matrix, iterations, tabuLength, neighborhood, seed, maxTime });
        }
    }
}
