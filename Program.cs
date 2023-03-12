using AppTinhLuong.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AppTinhLuong
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string filePath = "appsettings.json";

            if (!File.Exists(filePath)) // Kiểm tra xem file đã tồn tại chưa
            {
                File.Create(filePath).Close(); // Tạo file mới và đóng lại
                var data = new DataConfiguration()
                {
                    SocialInsurance = 0.08,
                    HealthInsurance = 0.015,
                    UnemploymentInsurance = 0.01,
                    MaximumInsurance = 29800000,
                    FamilyAllowances = 11000000,
                };
                string json = JsonConvert.SerializeObject(data);
                File.WriteAllText("appsettings.json", json);
            }
            string jsonFromFile = File.ReadAllText("appsettings.json");
            DataConfiguration dataFromFile = JsonConvert.DeserializeObject<DataConfiguration>(jsonFromFile);
            double[] coefficientsSalary = { 1.15, 1.2, 1.25, 1.3 };

            // Mức lương tối thiểu theo vùng
            double[] minimumWage = { 4680000, 4160000, 3640000, 3250000 };
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Chào mừng bạn đến với công cụ tính lương");
            Console.WriteLine("---------------------------------");
            Console.Write("Nhập tổng lương của bạn: ");
            string grossSalaryInput = Console.ReadLine();
            if (string.IsNullOrEmpty(grossSalaryInput))
            {
                Console.WriteLine("Vui lòng nhập lương !");
                Console.ReadKey();
                return;
            }
            double grossSalary = double.Parse(grossSalaryInput);
            Console.WriteLine("---------------------------------");
            Console.Write("Nhập số người phụ thuộc: ");
            string dependentsInput = Console.ReadLine();
            if (string.IsNullOrEmpty(dependentsInput))
            {
                Console.WriteLine("Vui lòng nhập số người phụ thuộc!");
            }
            int dependents = int.Parse(dependentsInput);
            Console.WriteLine("---------------------------------");
            Console.Write("Nhập mức đóng bảo hiểm xã hội: ");
            string socialInsuranceRateInput = Console.ReadLine();
            if (string.IsNullOrEmpty(socialInsuranceRateInput))
            {
                Console.WriteLine("Vui lòng nhập mức đóng bảo hiểm xã hội!");
            }
            double socialInsuranceRate = double.Parse(socialInsuranceRateInput);
            Console.WriteLine("---------------------------------");

            Console.Write("Hãy chọn vùng theo số (1 cho Hanoi, 2 cho thành phố, 3 cho các tỉnh huyện): ");
            string regionInput = Console.ReadLine();
            if (string.IsNullOrEmpty(regionInput))
            {
                Console.WriteLine("Vui lòng chọn vùng");
            }
            int region = int.Parse(regionInput);
            double luongTheoVung = minimumWage[region - 1] * coefficientsSalary[region - 1];
            SalaryCalculator salaryCalculator = new SalaryCalculator()
            {
                GrossSalary = grossSalary,
                DependentPerson = dependents,
                SocialInsuranceRate = socialInsuranceRate,
                SocialInsurance = dataFromFile.SocialInsurance,
                HealthInsurance = dataFromFile.HealthInsurance,
                UnemploymentInsurance = dataFromFile.UnemploymentInsurance,
                MaximumInsurance = dataFromFile.MaximumInsurance,
                FamilyAllowances = dataFromFile.FamilyAllowances,
            };

            Console.WriteLine("Bạn có muốn tính lương theo kiểu gì ? (1 Gross => Net, 2 Net => Gross): ");
            string selectInput = Console.ReadLine();
            if (selectInput == null)
            {
                Console.WriteLine("Vui lòng chọn số 1 hoặc 2");
                Console.ReadKey();
                return;
            };
            int select = int.Parse(selectInput);
            switch (select)
            {
                case 1:
                    Console.WriteLine("---------------------------------");
                    salaryCalculator.NetSalaryCalculation();
                    break;

                case 2:
                    Console.WriteLine("---------------------------------");
                    salaryCalculator.GrossSalaryCalculation();
                    break;

                default:
                    Console.WriteLine("Vui lòng chọn đúng số");
                    break;
            }
            //Console.WriteLine($"Thu nhập chịu thuế của bạn là {taxableIncome:#,##0}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Cảm ơn bạn đã sử dụng");
            Console.ReadKey();
        }
    }
}