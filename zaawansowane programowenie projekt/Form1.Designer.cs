namespace zaawansowane_programowenie_projekt
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtRows = new TextBox();
            txtErrors = new TextBox();
            txtCols = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnGenerate = new Button();
            dataGridView1 = new DataGridView();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            btnCompute = new Button();
            txtTabuLength = new TextBox();
            txtNeighborhood = new TextBox();
            txtSeed = new TextBox();
            txtTime = new TextBox();
            txtIterations = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            tabPage3 = new TabPage();
            btnStop = new Button();
            label9 = new Label();
            textBox1 = new TextBox();
            lblStatus = new Label();
            progressBar1 = new ProgressBar();
            tabPage4 = new TabPage();
            lblPermutation = new Label();
            lblFinalCost = new Label();
            label11 = new Label();
            label10 = new Label();
            dataGridViewResult = new DataGridView();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResult).BeginInit();
            SuspendLayout();
            // 
            // txtRows
            // 
            txtRows.Location = new Point(6, 31);
            txtRows.Name = "txtRows";
            txtRows.Size = new Size(150, 31);
            txtRows.TabIndex = 0;
            txtRows.TextChanged += textBox1_TextChanged;
            // 
            // txtErrors
            // 
            txtErrors.Location = new Point(6, 167);
            txtErrors.Name = "txtErrors";
            txtErrors.Size = new Size(150, 31);
            txtErrors.TabIndex = 1;
            txtErrors.TextChanged += txtErrors_TextChanged;
            // 
            // txtCols
            // 
            txtCols.Location = new Point(6, 102);
            txtCols.Name = "txtCols";
            txtCols.Size = new Size(150, 31);
            txtCols.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Size = new Size(58, 25);
            label1.TabIndex = 3;
            label1.Text = "Rows:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 74);
            label2.Name = "label2";
            label2.Size = new Size(86, 25);
            label2.TabIndex = 4;
            label2.Text = "Columns:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 139);
            label3.Name = "label3";
            label3.Size = new Size(222, 25);
            label3.TabIndex = 5;
            label3.Text = "Number of random errors:";
            // 
            // btnGenerate
            // 
            btnGenerate.AutoEllipsis = true;
            btnGenerate.BackColor = Color.FromArgb(255, 192, 255);
            btnGenerate.Location = new Point(32, 352);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(176, 99);
            btnGenerate.TabIndex = 6;
            btnGenerate.Text = "GENERATE";
            btnGenerate.UseVisualStyleBackColor = false;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.GridColor = Color.White;
            dataGridView1.Location = new Point(264, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 34;
            dataGridView1.Size = new Size(749, 484);
            dataGridView1.TabIndex = 7;
            dataGridView1.CellClick += CellClick;
            dataGridView1.CellValueChanged += CellValueChanged;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(3, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1024, 525);
            tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Controls.Add(txtRows);
            tabPage1.Controls.Add(btnGenerate);
            tabPage1.Controls.Add(txtErrors);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(txtCols);
            tabPage1.Controls.Add(label2);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1016, 487);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Generator";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnCompute);
            tabPage2.Controls.Add(txtTabuLength);
            tabPage2.Controls.Add(txtNeighborhood);
            tabPage2.Controls.Add(txtSeed);
            tabPage2.Controls.Add(txtTime);
            tabPage2.Controls.Add(txtIterations);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(label4);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1016, 487);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Tabu Search";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCompute
            // 
            btnCompute.AutoEllipsis = true;
            btnCompute.BackColor = Color.FromArgb(255, 192, 255);
            btnCompute.Location = new Point(260, 330);
            btnCompute.Name = "btnCompute";
            btnCompute.Size = new Size(176, 99);
            btnCompute.TabIndex = 10;
            btnCompute.Text = "COMPUTE";
            btnCompute.UseVisualStyleBackColor = false;
            btnCompute.Click += btnCompute_Click;
            // 
            // txtTabuLength
            // 
            txtTabuLength.Location = new Point(17, 122);
            txtTabuLength.Name = "txtTabuLength";
            txtTabuLength.Size = new Size(150, 31);
            txtTabuLength.TabIndex = 9;
            // 
            // txtNeighborhood
            // 
            txtNeighborhood.Location = new Point(17, 196);
            txtNeighborhood.Name = "txtNeighborhood";
            txtNeighborhood.Size = new Size(150, 31);
            txtNeighborhood.TabIndex = 8;
            // 
            // txtSeed
            // 
            txtSeed.Location = new Point(17, 274);
            txtSeed.Name = "txtSeed";
            txtSeed.Size = new Size(150, 31);
            txtSeed.TabIndex = 7;
            // 
            // txtTime
            // 
            txtTime.Location = new Point(17, 358);
            txtTime.Name = "txtTime";
            txtTime.Size = new Size(150, 31);
            txtTime.TabIndex = 6;
            // 
            // txtIterations
            // 
            txtIterations.Location = new Point(17, 45);
            txtIterations.Name = "txtIterations";
            txtIterations.Size = new Size(150, 31);
            txtIterations.TabIndex = 5;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(17, 330);
            label8.Name = "label8";
            label8.Size = new Size(89, 25);
            label8.TabIndex = 4;
            label8.Text = "Max time:";
            label8.Click += label8_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(17, 246);
            label7.Name = "label7";
            label7.Size = new Size(126, 25);
            label7.TabIndex = 3;
            label7.Text = "Random seed:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 168);
            label6.Name = "label6";
            label6.Size = new Size(168, 25);
            label6.TabIndex = 2;
            label6.Text = "Neighborhood size:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 94);
            label5.Name = "label5";
            label5.Size = new Size(108, 25);
            label5.TabIndex = 1;
            label5.Text = "Tabu length:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 17);
            label4.Name = "label4";
            label4.Size = new Size(90, 25);
            label4.TabIndex = 0;
            label4.Text = "Iterations:";
            label4.Click += label4_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(btnStop);
            tabPage3.Controls.Add(label9);
            tabPage3.Controls.Add(textBox1);
            tabPage3.Controls.Add(lblStatus);
            tabPage3.Controls.Add(progressBar1);
            tabPage3.Location = new Point(4, 34);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1016, 487);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Solution";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            btnStop.AutoEllipsis = true;
            btnStop.BackColor = Color.FromArgb(255, 192, 255);
            btnStop.Location = new Point(825, 372);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(176, 99);
            btnStop.TabIndex = 7;
            btnStop.Text = "STOP";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += btnStop_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(556, 1);
            label9.Name = "label9";
            label9.Size = new Size(197, 25);
            label9.TabIndex = 3;
            label9.Text = "Evaluate function value:";
            label9.Click += label9_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(556, 29);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 2;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(556, 1);
            label9.Name = "label9";
            label9.Size = new Size(197, 25);
            label9.TabIndex = 3;
            label9.Text = "Evaluate function value:";
            label9.Click += label9_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(15, 29);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(404, 34);
            progressBar1.TabIndex = 0;
            progressBar1.Click += progressBar1_Click;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(lblPermutation);
            tabPage4.Controls.Add(lblFinalCost);
            tabPage4.Controls.Add(label11);
            tabPage4.Controls.Add(label10);
            tabPage4.Controls.Add(dataGridViewResult);
            tabPage4.Location = new Point(4, 34);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1016, 487);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Results";
            tabPage4.UseVisualStyleBackColor = true;
            tabPage4.Click += tabPage4_Click;
            // 
            // lblPermutation
            // 
            lblPermutation.Location = new Point(5, 124);
            lblPermutation.Name = "lblPermutation";
            lblPermutation.Size = new Size(350, 350);
            lblPermutation.TabIndex = 9;
            // 
            // lblFinalCost
            // 
            lblFinalCost.AutoSize = true;
            lblFinalCost.Location = new Point(6, 31);
            lblFinalCost.Name = "lblFinalCost";
            lblFinalCost.Size = new Size(0, 25);
            lblFinalCost.TabIndex = 8;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 99);
            label11.Name = "label11";
            label11.Size = new Size(112, 25);
            label11.TabIndex = 7;
            label11.Text = "Permutation:";
            label11.Click += label11_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 6);
            label10.Name = "label10";
            label10.Size = new Size(197, 25);
            label10.TabIndex = 4;
            label10.Text = "Evaluate function value:";
            // 
            // dataGridViewResult
            // 
            dataGridViewResult.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResult.Location = new Point(361, 6);
            dataGridViewResult.Name = "dataGridViewResult";
            dataGridViewResult.RowHeadersWidth = 62;
            dataGridViewResult.Size = new Size(649, 475);
            dataGridViewResult.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1020, 520);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Resize += Form1_Resize;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResult).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtRows;
        private TextBox txtErrors;
        private TextBox txtCols;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnGenerate;
        private DataGridView dataGridView1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Label label4;
        private Label label6;
        private Label label5;
        private Label label8;
        private Label label7;
        private Button btnCompute;
        private TextBox txtTabuLength;
        private TextBox txtNeighborhood;
        private TextBox txtSeed;
        private TextBox txtTime;
        private TextBox txtIterations;
        private Label lblStatus;
        private ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TextBox textBox1;
        private Label label9;
        private TabPage tabPage4;
        private Label label11;
        private TextBox textBox3;
        private Label label10;
        private DataGridView dataGridViewResult;
        private Label lblFinalCost;
        private Label lblPermutation;
        private Button btnStop;
    }
}
