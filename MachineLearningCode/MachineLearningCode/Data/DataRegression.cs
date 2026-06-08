using System;
using System.Collections.Generic;
using System.Text;
using static MachineLearningCode.Models;

namespace MachineLearningCode.Data
{
    public static class DataRegression
    {
        public static List<InsuranceData> GetLinearInsuranceData()
        {
            return new List<InsuranceData>
            {
                new InsuranceData { Age = 10, Premium = 2000 },
                new InsuranceData { Age = 20, Premium = 2500 },
                new InsuranceData { Age = 30, Premium = 6000 },
                new InsuranceData { Age = 40, Premium = 9000 },
                new InsuranceData { Age = 50, Premium = 11000 },
                new InsuranceData { Age = 60, Premium = 12000 },
                new InsuranceData { Age = 70, Premium = 14000 },
                new InsuranceData { Age = 80, Premium = 16000 },
                new InsuranceData { Age = 90, Premium = 18000 },
                new InsuranceData { Age = 100, Premium = 21000 }
            };
        }
    }
}
