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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtRows
            // 
            txtRows.Location = new Point(47, 65);
            txtRows.Name = "txtRows";
            txtRows.Size = new Size(150, 31);
            txtRows.TabIndex = 0;
            txtRows.TextChanged += textBox1_TextChanged;
            // 
            // txtErrors
            // 
            txtErrors.Location = new Point(47, 173);
            txtErrors.Name = "txtErrors";
            txtErrors.Size = new Size(150, 31);
            txtErrors.TabIndex = 1;
            // 
            // txtCols
            // 
            txtCols.Location = new Point(47, 118);
            txtCols.Name = "txtCols";
            txtCols.Size = new Size(150, 31);
            txtCols.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 37);
            label1.Name = "label1";
            label1.Size = new Size(58, 25);
            label1.TabIndex = 3;
            label1.Text = "Rows:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 99);
            label2.Name = "label2";
            label2.Size = new Size(86, 25);
            label2.TabIndex = 4;
            label2.Text = "Columns:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 152);
            label3.Name = "label3";
            label3.Size = new Size(222, 25);
            label3.TabIndex = 5;
            label3.Text = "Number of random errors:";
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(47, 395);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(176, 99);
            btnGenerate.TabIndex = 6;
            btnGenerate.Text = "GENERATE";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.Location = new Point(392, 27);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 34;
            dataGridView1.Size = new Size(605, 467);
            dataGridView1.TabIndex = 7;
            dataGridView1.CellClick += CellClick;
            dataGridView1.CellValueChanged += CellValueChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1020, 520);
            Controls.Add(dataGridView1);
            Controls.Add(btnGenerate);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtCols);
            Controls.Add(txtErrors);
            Controls.Add(txtRows);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Resize += Form1_Resize;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
    }
}
