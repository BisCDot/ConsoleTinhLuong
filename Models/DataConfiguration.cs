using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTinhLuong.Models
{
    public class DataConfiguration
    {
        public double SocialInsurance { get; set; }
        public double HealthInsurance { get; set; }
        public double UnemploymentInsurance { get; set; }
        public int MaximumInsurance { get; set; }
        public double FamilyAllowances { get; set; }
    }
}