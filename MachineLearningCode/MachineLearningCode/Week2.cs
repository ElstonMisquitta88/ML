using MachineLearningCode.Data;
using Microsoft.ML;
using Microsoft.ML.AutoML;
using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.Text;
using static MachineLearningCode.Models;

namespace MachineLearningCode
{
    public class Week2
    {
        public static void Lab7_SavingModel()
        {
            var mlContext = new MLContext();
            var data = mlContext.Data.LoadFromTextFile<InsuranceData>(
            path: "D:\\GitHub\\ML\\MachineLearningCode\\MachineLearningCode\\Data\\linear_insurance_100k.csv",   // your CSV file path
            hasHeader: true,
            separatorChar: ',');

            var pipeline = mlContext.Transforms // f1 = Age + Salary
                                     .Concatenate("Features", "Age")
                                     .Append(mlContext.Transforms.NormalizeMinMax("Features"))
                                     .Append(
                                      mlContext.Regression.Trainers
                                      .OnlineGradientDescent(labelColumnName: "Premium",
                                             featureColumnName: "Features"
                                       ));
            var model = pipeline.Fit(data); // execution = data + Ols ==> Model

            mlContext.Model.Save(model, data.Schema, "insuranceModel.zip");// Save the Model

            var pe = mlContext.Model.
                        CreatePredictionEngine<InsuranceData, InsurancePrediction>(model);
            var prediction = pe.Predict(new InsuranceData { Age = 45 });

            Console.WriteLine(prediction.PredictedPremium);
            Console.Read();

        }

        public static void Lab7_LoadingModel()
        {
            var mlContext = new MLContext();

            // LOAD OLD MODEL
            DataViewSchema inputSchema;
            var loadedModel = mlContext.Model.Load("insuranceModel.zip", out inputSchema);

            // NEW TRAINING DATA (new rows)
            var newData = new List<InsuranceData>
            {
            new InsuranceData { Age = 120, Premium = 70000 },
            };

            var newDataView = mlContext.Data.LoadFromEnumerable(newData);

            // RETRAIN (INCREMENTAL FIT)
            var trainer = mlContext.Regression.Trainers
                        .OnlineGradientDescent(labelColumnName: "Premium", featureColumnName: "Features")

                        ;

            var modelChain = (Microsoft.ML.Data.TransformerChain<ITransformer>)loadedModel;
            IDataView preppedNewDataView = loadedModel.Transform(newDataView);

            // 2. Get the last transformer in the chain, which is the actual trained predictor.
            ITransformer finalPredictor = modelChain.Last();

            // 3. Cast the final predictor to the specific interface that holds the 'Model' property.
            // We assume object as the output type for safety, it varies by scenario.
            var singleFeaturePredictor = (ISingleFeaturePredictionTransformer<object>)finalPredictor;

            // 4. Finally, access the specific Model Parameters type.
            LinearRegressionModelParameters originalModelParameters =
                singleFeaturePredictor.Model as LinearRegressionModelParameters;

            var model2 = trainer.Fit(preppedNewDataView, originalModelParameters);
            var pe = mlContext.Model.
                       CreatePredictionEngine<InsuranceData, InsurancePrediction>(model2);
            var prediction = pe.Predict(new InsuranceData { Age = 120 });

            Console.WriteLine(prediction.PredictedPremium);


            Console.WriteLine("Model updated!");


        }





    }
}
