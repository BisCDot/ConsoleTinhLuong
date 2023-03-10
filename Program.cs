using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppTinhLuong
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            double[] coefficientsSalary = { 1.15, 1.2, 1.25 ,1.3};

            // Mức lương tối thiểu theo vùng
            double[] minimumWage = { 4680000, 4160000, 3640000, 3250000 };
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Chào mừng bạn đến với công cụ tính lương");
            Console.WriteLine("---------------------------------");
            Console.Write("Nhập tổng lương của bạn: ");
            double grossSalary = double.Parse(Console.ReadLine());
            Console.WriteLine("---------------------------------");
            Console.Write("Nhập số người phụ thuộc: ");
            int dependents = int.Parse(Console.ReadLine());
            Console.WriteLine("---------------------------------");
            Console.Write("Nhập mức đóng bảo hiểm xã hội: ");
            double socialInsuranceRate = double.Parse(Console.ReadLine());
            Console.WriteLine("---------------------------------");

            Console.Write("Hãy chọn vùng theo số (1 cho Hanoi, 2 cho thành phố, 3 cho các tỉnh huyện): ");
            int region = int.Parse(Console.ReadLine());
            double luongTheoVung = minimumWage[region - 1] * coefficientsSalary[region - 1];
            double compulsoryInsurance = 0;
            if (socialInsuranceRate <= 29000000)
            {
                compulsoryInsurance = socialInsuranceRate * (0.08 + 0.015 + 0.01);
            }
            else
            {
                compulsoryInsurance = (29800000 * (0.08 + 0.015)) + (socialInsuranceRate * 0.01);
            }
            int reduceDependent = dependents * 4400000;
            double taxableIncome = grossSalary - 11000000 - reduceDependent - compulsoryInsurance;
            double personalIncomeTax = 0;

            if (taxableIncome <= 0)
            {
                personalIncomeTax = 0;
            }
            else if (taxableIncome <= 5000000)
            {
                personalIncomeTax = taxableIncome * 0.05;
            }
            else if (taxableIncome <= 10000000)
            {
                personalIncomeTax = taxableIncome * 0.1 - 250000;
            }
            else if (taxableIncome <= 18000000)
            {
                personalIncomeTax = taxableIncome * 0.15 - 750000;
            }
            else if (taxableIncome <= 32000000)
            {
                personalIncomeTax = taxableIncome * 0.2 - 1650000;
            }
            else if (taxableIncome <= 52000000)
            {
                personalIncomeTax = taxableIncome * 0.25 - 3250000;
            }
            else if (taxableIncome <= 80000000)
            {
                personalIncomeTax = taxableIncome * 0.3 - 5850000;
            }
            else
            {
                personalIncomeTax = taxableIncome * 0.35 - 9850000;
            }

            double netSalary = grossSalary - compulsoryInsurance - personalIncomeTax;
            Console.WriteLine("===============================================");
            Console.WriteLine($"Lương Gross là {grossSalary:#,##0}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Số tiền bảo hiểm bắt buộc là {compulsoryInsurance:#,##0}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Thuế TNCN của bạn là {personalIncomeTax:#,##0}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Lương Net của bạn là {netSalary:#,##0}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Thu nhập chịu thuế của bạn là {taxableIncome:#,##0}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Cảm ơn bạn đã sử dụng");
            Console.ReadKey();
        }
    }
}