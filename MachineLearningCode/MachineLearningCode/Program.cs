using Microsoft.ML;
using Microsoft.ML.Data;

namespace MachineLearningCode;

public class Program
{
    public static List<InsuranceData> GetData()
    {
        return new List<InsuranceData>
            {
                new InsuranceData { Age = 10, Premium = 2000 },
                new InsuranceData { Age = 20, Premium = 4000 },
                new InsuranceData { Age = 30, Premium = 6000 },
                new InsuranceData { Age = 40, Premium = 8000 },
                new InsuranceData { Age = 50, Premium = 10000 },
                new InsuranceData { Age = 60, Premium = 12000 },
                new InsuranceData { Age = 70, Premium = 14000 },
                new InsuranceData { Age = 80, Premium = 16000 },
                new InsuranceData { Age = 90, Premium = 18000 },
                new InsuranceData { Age = 100, Premium = 20000 }
            };
    }
    static void Main(string[] args)
    {
        var mlconext = new MLContext();

        var data = mlconext.Data.LoadFromEnumerable(GetData()); // Load data from the list of InsuranceData

        var pipeline = mlconext.Transforms
                        .Concatenate("f1", "Age") // Concatenate the Age column into a Features column
                        .Append(mlconext.Regression.Trainers
                        .Ols(labelColumnName: "Premium", featureColumnName: "f1")); // Append a regression trainer to the pipeline

        var model = pipeline.Fit(data); // Fit the model to the data


        var pe=mlconext.Model.CreatePredictionEngine<InsuranceData, InsurancePrediction>(model); // Create a prediction engine'

        var prediction = pe.Predict(new InsuranceData { Age = 54 }); // Predict the premium for a new data point with Age = 25
        Console.WriteLine($"Predicted Premium for Age 54: {prediction.PredictedPremium}"); // Output the predicted premium
        Console.ReadLine();
    }
}

public class InsurancePrediction
{
    [ColumnName("Score")] // This attribute maps the predicted value to the "Score" column
    public float PredictedPremium { get; set; }
}

public class InsuranceData
{
    public float Age { get; set; }
    public float Premium { get; set; }
}