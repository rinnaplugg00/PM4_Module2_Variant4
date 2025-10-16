namespace ValidationSystem
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAutoTests;
        private System.Windows.Forms.Button btnManualCheck;
        private System.Windows.Forms.DataGridView dataGridView1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnAutoTests = new Button();
            btnManualCheck = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnAutoTests
            // 
            btnAutoTests.Location = new Point(12, 12);
            btnAutoTests.Name = "btnAutoTests";
            btnAutoTests.Size = new Size(200, 30);
            btnAutoTests.TabIndex = 0;
            btnAutoTests.Text = "Автоматические тесты";
            btnAutoTests.Click += btnAutoTests_Click;
            // 
            // btnManualCheck
            // 
            btnManualCheck.Location = new Point(230, 12);
            btnManualCheck.Name = "btnManualCheck";
            btnManualCheck.Size = new Size(230, 30);
            btnManualCheck.TabIndex = 1;
            btnManualCheck.Text = "Проверить вручную введённые";
            btnManualCheck.Click += btnManualCheck_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Location = new Point(12, 60);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(922, 472);
            dataGridView1.TabIndex = 2;
            // 
            // Form1
            // 
            ClientSize = new Size(946, 544);
            Controls.Add(btnAutoTests);
            Controls.Add(btnManualCheck);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Система валидации данных";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }
    }
}
