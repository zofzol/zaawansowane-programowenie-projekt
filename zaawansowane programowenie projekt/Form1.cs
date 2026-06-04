using System.ComponentModel;
using System.Windows.Forms.DataVisualization.Charting;

namespace zaawansowane_programowenie_projekt
{
    public partial class Form1 : Form
    {

        public class ProgressData
        {
            public int Iteration { get; set; }
            public int Cost { get; set; }
        }

        private BackgroundWorker bw = new BackgroundWorker();
        private Chart chart1 = new Chart();
        private int[,] lastShuffledMatrix;
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
            txtMaxStagnation.Text = "50";
            txtNeighborhood.Text = "50";
            //txtTime.Text = "30";
            txtSeed.Text = "67";

            //chart1.Parent = tabPage3;
            //chart1.Location = new Point(20, 80);
            //chart1.Size = new Size(500, 250);
            //chart1.ChartAreas.Add(new ChartArea());

            chart1.Parent = tabPage3;
            chart1.Location = new Point(20, 80);
            chart1.Size = new Size(750, 400);
            chart1.ChartAreas.Add(new ChartArea());

            chart1.ChartAreas[0].AxisX.Minimum = 0; //start  osi x od 0
            chart1.ChartAreas[0].AxisX.IsMarginVisible = false;

            Series series = new Series();
            series.Name = "Cost";
            series.ChartType = SeriesChartType.Line;

            chart1.Series.Add(series);

            chart1.ChartAreas[0].AxisX.Title = "Number of Iterations";
            chart1.ChartAreas[0].AxisY.Title = "Cost Function Value";
            Font axisTitleFont = new Font("Arial", 10, FontStyle.Bold);
            chart1.ChartAreas[0].AxisX.TitleFont = axisTitleFont;
            chart1.ChartAreas[0].AxisY.TitleFont = axisTitleFont;
        }
        private void Bw_DoWork(object? sender, DoWorkEventArgs e)
        {
            var args = (object[])e.Argument;

            int[,] matrix = (int[,])args[0];
            int iterations = (int)args[1];
            int tabuLength = (int)args[2];
            int neighborhood = (int)args[3];
            int seed = (int)args[4];
            int maxStagnation = (int)args[5];
            //int maxTime = (int)args[5];

            var tabu = new TabuSearch();

            var result = tabu.Run(matrix, iterations, tabuLength, neighborhood, seed, maxStagnation, (BackgroundWorker)sender);
            e.Result = result;
        }
        private void Bw_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage+1;
            lblStatus.Text = e.ProgressPercentage+1 + "%";

            var data = (ProgressData)e.UserState;
            textBox1.Text= data.Cost.ToString();
            chart1.Series["Cost"].Points.AddXY(data.Iteration, data.Cost);
        }
        private void Bw_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {

            var result = (Solution)e.Result;

            //int[,] matrix = GetMatrixFromGrid();

            ShowSolution(result, lastShuffledMatrix);

            tabControl1.SelectedTab = tabPage4;
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

            //ilosc mozliwych przesuniec dla shift
            int totalPossibleMoves = n * (n - 1);

            //okolo 30% 
            int dynamicNeighborhood = Math.Max(20, totalPossibleMoves / 3);
            //nadpisanie wartosci
            txtNeighborhood.Text = dynamicNeighborhood.ToString();

            var generator = new InstanceGenerator();

            //zwraca macierz przed mieszaniem
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
                bw.WorkerReportsProgress = true;

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
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            dataGridViewResult.RowCount = rows;
            dataGridViewResult.ColumnCount = cols;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int originalCol = sol.Permutation[j];

                    int value = matrix[i, originalCol];

                    dataGridViewResult[j, i].Value = value;

                    if (value == 1)
                        dataGridViewResult[j, i].Style.BackColor = Color.LightPink;
                    else
                        dataGridViewResult[j, i].Style.BackColor =
                            ColorTranslator.FromHtml("#d3e171");
                }
            }

            lblFinalCost.Text = "Final cost: " + sol.Cost;

            lblTime.Text = $"{sol.ExecutionTime.TotalSeconds:F2} s";

            lblPermutation.Text =
                string.Join(", ", sol.Permutation);

            // kwadratowe komórki
            foreach (DataGridViewColumn col in dataGridViewResult.Columns)
                col.Width = 30;

            foreach (DataGridViewRow row in dataGridViewResult.Rows)
                row.Height = 30;

            dataGridViewResult.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtIterations.Text, out int iterations) ||
                !int.TryParse(txtTabuLength.Text, out int tabuLength) ||
                !int.TryParse(txtNeighborhood.Text, out int neighborhood) ||
                !int.TryParse(txtMaxStagnation.Text, out int maxStagnation) ||
                //!int.TryParse(txtTime.Text, out int maxTime) ||
                !int.TryParse(txtSeed.Text, out int seed))
            {
                MessageBox.Show("Podaj wartoœci liczbowe!");
                return;
            }

            //pobranie macierzy po edycji
            int[,] userMatrix = GetMatrixFromGrid();

            //mieszanie kolumn przed taboo
            lastShuffledMatrix = ShuffleColumns(userMatrix, seed);

            //przemieszana macierz trafia do BackgroundWorkera
            bw.RunWorkerAsync(new object[] { lastShuffledMatrix, iterations, tabuLength, neighborhood, seed, maxStagnation });

            chart1.Series["Cost"].Points.Clear();
            tabControl1.SelectedTab = tabPage3;
        }

        private int[,] ShuffleColumns(int[,] matrix, int seed)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            Random localRand = new Random(seed);

            int[] perm = Enumerable.Range(0, n).ToArray();

            for (int i = 0; i < n; i++)
            {
                int j = localRand.Next(i, n);
                (perm[i], perm[j]) = (perm[j], perm[i]);
            }

            int[,] shuffled = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    shuffled[i, j] = matrix[i, perm[j]];
                }
            }

            return shuffled;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (bw.IsBusy)
            {
                bw.CancelAsync();
            }
        }

        private void btnGenEmpty_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtRows.Text, out int m) || !int.TryParse(txtCols.Text, out int n) || !int.TryParse(txtErrors.Text, out int errors))
            {
                MessageBox.Show("Podaj wartoœæ liczbow¹!");
                return;
            }

            //ilosc mozliwych przesuniec dla shift
            int totalPossibleMoves = n * (n - 1);

            //okolo 30% 
            int dynamicNeighborhood = Math.Max(20, totalPossibleMoves / 3);
            //nadpisanie wartosci
            txtNeighborhood.Text = dynamicNeighborhood.ToString();

            var generator = new InstanceGenerator();

            //zwraca macierz przed mieszaniem
            var matrix = new int[m, n];

            DisplayMatrix(matrix);
        }

        private void txtMaxStagnation_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
