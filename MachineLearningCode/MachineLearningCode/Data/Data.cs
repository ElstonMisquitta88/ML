using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MachineLearningCode.Models;

namespace MachinelearningClass
{
    public static  class Data
    {
        public static List<CustomerData> GetCustomerData()
        {
            var customers = new[]
            {
                new CustomerData { Age = 22, Spending = 20000 },
                new CustomerData { Age = 25, Spending = 23000 },
                new CustomerData { Age = 45, Spending = 40000 },
                new CustomerData { Age = 50, Spending = 42000 },
                new CustomerData { Age = 65, Spending = 15000 },
                new CustomerData { Age = 70, Spending = 12000 },
            };
            return customers.ToList<CustomerData>();
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
