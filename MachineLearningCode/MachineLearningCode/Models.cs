using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MachineLearningCode
{
    public class Models
    {
        public class InsuranceData
        {
            [LoadColumn(0)]
            public float Age { get; set; }
            [LoadColumn(2)]
            public float HighBp { get; set; }
            [LoadColumn(3)]
            public float LowBp { get; set; }
            [LoadColumn(1)]
            public float Premium { get; set; }
        }
        public class InsurancePrediction
        {
            public float Age { get; set; }

            [ColumnName("Score")]
            public float PredictedPremium { get; set; }
        }

        //---------------------------------------------------------------

        public class FruitData
        {
            public float Weight { get; set; }
            public string Color { get; set; }
            public bool IsApple { get; set; }   // True = Apple, False = Banana
            public string FruitType { get; set; }

        }

        public class FruitPrediction
        {
            [ColumnName("PredictedLabel")]
            public bool PredictedLabelBool { get; set; }

            // convenience string representation (not used by ML.NET)
            public string PredictedLabel => PredictedLabelBool ? "True" : "False";

            public float Score { get; set; }
            public float Probability { get; set; }
        }

 
    }
}
