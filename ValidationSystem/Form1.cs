using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ValidationSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.ReadOnly = false;
        }

        private void btnAutoTests_Click(object sender, EventArgs e)
        {
            var results = TestRunner.RunAllTests();
            dataGridView1.DataSource = results;
        }

        private void btnManualCheck_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("Сначала запустите автоматические тесты!");
                return;
            }

            var table = (List<TestResult>)dataGridView1.DataSource;
            foreach (var row in table)
            {
                try
                {
                    bool actual = RunValidation(row.Метод, row.ВходныеДанные);
                    row.ФактическийРезультат = actual.ToString();
                    row.Статус = (row.ОжидаемыйРезультат == row.ФактическийРезультат) ? "Пройден" : "Не пройден";
                }
                catch
                {
                    row.ФактическийРезультат = "Ошибка";
                    row.Статус = "Ошибка";
                }
            }
            dataGridView1.Refresh();
        }

        private bool RunValidation(string method, string input)
        {
            return method switch
            {
                "IsValidEmail" => Validators.IsValidEmail(input),
                "IsValidPhone" => Validators.IsValidPhone(input),
                "IsValidDate" => Validators.IsValidDate(input),
                "IsStrongPassword" => Validators.IsStrongPassword(input),
                "IsValidUsername" => Validators.IsValidUsername(input),
                "IsValidPostalCode" => Validators.IsValidPostalCode(input),
                _ => false
            };
        }
    }
}
