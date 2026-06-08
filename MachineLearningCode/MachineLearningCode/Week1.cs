using MachineLearningCode.Data;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Text;
using static MachineLearningCode.Models;

namespace MachineLearningCode
{
    public static class Week1
    {

        // FEATURE >> MODEL >> LABEL
        public static void Lab1_SimplestMLCodeSinglePrediction()
        {
            // (1) Create a new MLContext, which is the starting point for all ML.NET operations
            var mlconext = new MLContext();


            // (2) Load data into an IDataView, which is the data structure used by ML.NET for data processing and model training
            var data = mlconext.Data.LoadFromEnumerable(DataRegression.GetLinearInsuranceData());

            // (3) Define a data processing and model training pipeline. This pipeline will concatenate the Age column into a Features column
            // and then apply a regression trainer to predict the Premium based on the Age.
            var pipeline = mlconext.Transforms
                            .Concatenate("Features", "Age") // Concatenate the Age column into a Features column
                            .Append(mlconext.Regression.Trainers.Sdca( // Append a regression trainer to the pipeline
                                labelColumnName: "Premium",
                                featureColumnName: "Features")
                                    );

            // (4) Fit the model to the data using the defined pipeline.
            // This will train the model based on the provided data and the transformations defined in the pipeline.
            var model = pipeline.Fit(data); // Fit the model to the data


            // (5) Try to predict the premium for a new data point with Age = 25
            var pe = mlconext.Model.CreatePredictionEngine<InsuranceData, InsurancePrediction>(model); // Create a prediction engine'
            var prediction = pe.Predict(new InsuranceData { Age = 54 }); // Predict the premium for a new data point with Age = 25
            
            Console.WriteLine($"Predicted Premium for Age 54: {prediction.PredictedPremium}"); // Output the predicted premium

        }





    }
}
