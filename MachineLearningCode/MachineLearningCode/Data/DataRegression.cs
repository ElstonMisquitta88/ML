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

        public static List<InsuranceData> GetTestData()
        {
            return new List<InsuranceData>
                {
                    new InsuranceData { Age = 80, Premium = 16000 },
                    new InsuranceData { Age = 90, Premium = 18000 },
                    new InsuranceData { Age = 100, Premium = 20000 }
                };
        }


        public static List<FruitData> GetFruitData()
        {
            var samples = new[]
            {
            new FruitData { Weight = 150, Color = "Red",   IsApple = true,  FruitType = "Apple" },
            new FruitData { Weight = 130, Color = "Green", IsApple = true,  FruitType = "Apple" },
            new FruitData { Weight = 110, Color = "Yellow",IsApple = false, FruitType = "Banana" },
            new FruitData { Weight = 180, Color = "Yellow",IsApple = false, FruitType = "Banana" },
            new FruitData { Weight = 200, Color = "Orange",IsApple = false, FruitType = "Orange" },
            new FruitData { Weight = 220, Color = "Orange",IsApple = false, FruitType = "Orange" },
            new FruitData { Weight = 160, Color = "Green", IsApple = false, FruitType = "Mango" },
            new FruitData { Weight = 170, Color = "Yellow",IsApple = false, FruitType = "Mango" },
            new FruitData { Weight = 12, Color = "Black",IsApple = false, FruitType = "Berry" },

            };

            return samples.ToList();
        }
    }
}
