using System.Collections.Generic;

namespace ValidationSystem
{
    public class TestResult
    {
        public string ТипСценария { get; set; }
        public string Метод { get; set; }
        public string ВходныеДанные { get; set; }
        public string ОжидаемыйРезультат { get; set; }
        public string ФактическийРезультат { get; set; }
        public string Статус { get; set; }
    }

    public static class TestRunner
    {
        public static List<TestResult> RunAllTests()
        {
            var results = new List<TestResult>();

            void Add(string тип, string метод, string ввод, string ожидаемый, bool фактический)
            {
                string факт = фактический.ToString();
                results.Add(new TestResult
                {
                    ТипСценария = тип,
                    Метод = метод,
                    ВходныеДанные = ввод,
                    ОжидаемыйРезультат = ожидаемый,
                    ФактическийРезультат = факт,
                    Статус = ожидаемый == факт ? "Пройден" : "Не пройден"
                });
            }

            // Email
            Add("Нормальный", "IsValidEmail", "user@mail.com", "True", Validators.IsValidEmail("user@mail.com"));
            Add("Граничный", "IsValidEmail", "a@b.com", "True", Validators.IsValidEmail("a@b.com"));
            Add("Ошибочный", "IsValidEmail", "user@@mail", "False", Validators.IsValidEmail("user@@mail"));

            // Phone
            Add("Нормальный", "IsValidPhone", "+77015553344", "True", Validators.IsValidPhone("+77015553344"));
            Add("Граничный", "IsValidPhone", "87015553344", "True", Validators.IsValidPhone("87015553344"));
            Add("Ошибочный", "IsValidPhone", "12345", "False", Validators.IsValidPhone("12345"));

            // Date
            Add("Нормальный", "IsValidDate", "14.10.2025", "True", Validators.IsValidDate("14.10.2025"));
            Add("Граничный", "IsValidDate", "31.12.1999", "True", Validators.IsValidDate("31.12.1999"));
            Add("Ошибочный", "IsValidDate", "31.02.2024", "False", Validators.IsValidDate("31.02.2024"));

            // Password
            Add("Нормальный", "IsStrongPassword", "Admin123", "True", Validators.IsStrongPassword("Admin123"));
            Add("Граничный", "IsStrongPassword", "Aa1bcdef", "True", Validators.IsStrongPassword("Aa1bcdef"));
            Add("Ошибочный", "IsStrongPassword", "123", "False", Validators.IsStrongPassword("123"));

            // Username
            Add("Нормальный", "IsValidUsername", "User_1", "True", Validators.IsValidUsername("User_1"));
            Add("Граничный", "IsValidUsername", "abc", "True", Validators.IsValidUsername("abc"));
            Add("Ошибочный", "IsValidUsername", "ab", "False", Validators.IsValidUsername("ab"));

            // Postal Code
            Add("Нормальный", "IsValidPostalCode", "050000", "True", Validators.IsValidPostalCode("050000"));
            Add("Граничный", "IsValidPostalCode", "999999", "True", Validators.IsValidPostalCode("999999"));
            Add("Ошибочный", "IsValidPostalCode", "12345", "False", Validators.IsValidPostalCode("12345"));

            return results;
        }
    }
}
