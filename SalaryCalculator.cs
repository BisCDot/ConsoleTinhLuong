using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AppTinhLuong
{
    public class SalaryCalculator
    {
        public double GrossSalary { get; set; }
        public double NetSalary { get; set; }
        public double SocialInsurance { get; set; }
        public double HealthInsurance { get; set; }
        public double UnemploymentInsurance { get; set; }
        public double CompulsoryInsurance { get; set; }
        public double SocialInsuranceRate { get; set; }
        public int DependentPerson { get; set; }
        public double PersonalIncomeTax { get; set; }
        public int MaximumInsurance { get; set; }
        public double FamilyAllowances { get; set; }

        public SalaryCalculator()
        {
        }

        public double InsuranceCalculation(double socialInsuranceRate)
        {
            if (socialInsuranceRate <= MaximumInsurance)
            {
                CompulsoryInsurance = socialInsuranceRate * (SocialInsurance + HealthInsurance + UnemploymentInsurance);
            }
            else
            {
                CompulsoryInsurance = (MaximumInsurance * (SocialInsurance + HealthInsurance)) + (socialInsuranceRate * UnemploymentInsurance);
            }
            return CompulsoryInsurance;
        }

        public void NetSalaryCalculation()
        {
            this.InsuranceCalculation(SocialInsuranceRate);
            int reduceDependent = DependentPerson * 4400000;
            double taxableIncome = GrossSalary - FamilyAllowances - reduceDependent - CompulsoryInsurance;
            this.CalculatePersonalIncomeTax(taxableIncome);
            NetSalary = GrossSalary - CompulsoryInsurance - PersonalIncomeTax;
            Console.WriteLine("===============================================");
            Console.WriteLine($"Lương Gross là {GrossSalary:#,##0}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Số tiền bảo hiểm bắt buộc là {CompulsoryInsurance:#,##0}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Thuế TNCN của bạn là {PersonalIncomeTax:#,##0}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Lương Net của bạn là {NetSalary:#,##0}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Thu nhập chịu thuế là {taxableIncome:#,##0}");
        }

        public void GrossSalaryCalculation()
        {
            NetSalary = GrossSalary;
            int reduceDependent = DependentPerson * 4400000;
            double convertedIncome = GrossSalary - FamilyAllowances - reduceDependent;
            double taxableIncome = 0;
            if (convertedIncome <= 0)
            {
                taxableIncome = 0;
            }
            else if (convertedIncome <= 4750000)
            {
                taxableIncome = convertedIncome / 0.95;
            }
            else if (convertedIncome <= 9250000)
            {
                taxableIncome = (convertedIncome - 250000) / 0.9;
            }
            else if (convertedIncome <= 16050000)
            {
                taxableIncome = (convertedIncome - 750000) / 0.85;
            }
            else if (convertedIncome <= 27250000)
            {
                taxableIncome = (convertedIncome - 1650000) / 0.8;
            }
            else if (convertedIncome <= 42250000)
            {
                taxableIncome = (convertedIncome - 3250000) / 0.75;
            }
            else if (convertedIncome <= 61850000)
            {
                taxableIncome = (convertedIncome - 5850000) / 0.7;
            }
            else
            {
                taxableIncome = (convertedIncome - 9850000) / 0.65;
            }
            this.CalculatePersonalIncomeTax(taxableIncome);
            this.InsuranceCalculation(SocialInsuranceRate);
            double assumedGrossSalary = taxableIncome + FamilyAllowances + (CompulsoryInsurance);
            Console.WriteLine("===============================================");
            Console.WriteLine($"Lương Gross là {assumedGrossSalary:#,##0}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Số tiền bảo hiểm bắt buộc là {CompulsoryInsurance:#,##0}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Thuế TNCN của bạn là {PersonalIncomeTax:#,##0}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Lương Net của bạn là {NetSalary:#,##0}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Thu nhập chịu thuế là {taxableIncome:#,##0}");
        }

        public double ConvertNetToGross()
        {
            NetSalary = GrossSalary - (CompulsoryInsurance + PersonalIncomeTax);
            return NetSalary;
        }

        public double CalculatePersonalIncomeTax(double taxableIncome)
        {
            if (taxableIncome <= 0)
            {
                PersonalIncomeTax = 0;
            }
            else if (taxableIncome <= 5000000)
            {
                PersonalIncomeTax = taxableIncome * 0.05;
            }
            else if (taxableIncome <= 10000000)
            {
                PersonalIncomeTax = taxableIncome * 0.1 - 250000;
            }
            else if (taxableIncome <= 18000000)
            {
                PersonalIncomeTax = taxableIncome * 0.15 - 750000;
            }
            else if (taxableIncome <= 32000000)
            {
                PersonalIncomeTax = taxableIncome * 0.2 - 1650000;
            }
            else if (taxableIncome <= 52000000)
            {
                PersonalIncomeTax = taxableIncome * 0.25 - 3250000;
            }
            else if (taxableIncome <= 80000000)
            {
                PersonalIncomeTax = taxableIncome * 0.3 - 5850000;
            }
            else
            {
                PersonalIncomeTax = taxableIncome * 0.35 - 9850000;
            }
            return PersonalIncomeTax;
        }
    }
}