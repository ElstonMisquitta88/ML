using MachinelearningClass;
using Microsoft.Extensions.Configuration;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;


namespace MachineLearningCode;

public class Program
{
    //public static string datapath = "D:\\GitHub\\ML\\MachineLearningCode\\MachineLearningCode\\Data\\";

    static async Task Main(string[] args)
    {

        var configuration = new ConfigurationBuilder()
        .SetBasePath(AppContext.BaseDirectory)
        .AddJsonFile("appsettings.json", optional: true)
        .AddUserSecrets<Program>()    
        .Build();

        string model = configuration.GetValue<string>("OpenAI:Model")?? throw new Exception("OpenAI:Model not found.");
        string apiKey = configuration.GetValue<string>("OpenAI:ApiKey")?? throw new Exception("OpenAI:ApiKey not found.");

        var builder = Kernel.CreateBuilder();
        builder.AddOpenAIChatCompletion(
            modelId: model,
            apiKey: apiKey
        );
        var kernel = builder.Build();



        kernel.Plugins.AddFromObject(new GreetingPlugin());
        kernel.Plugins.AddFromObject(new RepldgeFilePlugin());

        var settings = new OpenAIPromptExecutionSettings
        {
            FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
        };

        //   var result = await kernel.InvokePromptAsync(
        //"Say hello to Elston",
        //    new(settings));

        var result = await kernel.InvokePromptAsync(
   "Need to generate Repledge File for the day",
       new(settings));

        Console.WriteLine(result);
    }
}