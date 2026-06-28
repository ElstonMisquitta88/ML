using AllMiniLmL6V2Sharp.Tokenizer;
using Microsoft.ML.Data;
using AllMiniLmL6V2Sharp;
using MachineLearningCode;
namespace MachinelearningClass
{
    public class Week4 // NLP
    {
        //The vocab.txt is used by the tokenizer to convert text into tokens (numbers),
        //and the ONNX model all-MiniLM-L6-v2.onnx is used by the embedder to
        //convert those tokens into vector embeddings that capture meaning.
        // https://huggingface.co/onnx-models/all-MiniLM-L6-v2-onnx/tree/main
        // Data folder does not have the All mini & GPT model and vocab json please download
        // from huggingface
        
        //public static void Lab15_SimpleBertEncoding()
        //{
        //    var tokenizer = new BertTokenizer(Program.datapath + @"\\vocab.txt");
        //    var embedder = new AllMiniLmL6V2Embedder(

        //        Program.datapath + @"\\Model.onnx",
        //        tokenizer
        //    );
        //    string texttobeMatched = "I love cricket and especially batting.";
        //    var texttobeMatchedV = embedder.GenerateEmbedding(texttobeMatched).ToArray();

        //    Console.WriteLine("Enter text be matched");
        //    string inputText = Console.ReadLine();
        //    var inputTextV = embedder.GenerateEmbedding(inputText).ToArray();
        //    Console.WriteLine(Common.CalculateCosineSimilarity(texttobeMatchedV, inputTextV));


        //}
         
        //public static async Task Lab17_SimpleChatGPTOnline()
        //{
        //    var credential = new ApiKeyCredential(Environment.GetEnvironmentVariable("aikey"));
        //    var chatClient = new ChatClient("gpt-3.5-turbo", credential); // Use a standard model for generation

        //    string simpleSentencePrompt = "I love ";

        //    ChatCompletion completion = await chatClient.CompleteChatAsync(
        //                                messages: new[]
        //                                {
        //                                new UserChatMessage(simpleSentencePrompt)
        //                                }
        //                                );

        //    string prediction = completion.Content.Last().Text;
        //    Console.WriteLine(prediction);
        //}




        public class BertInput
        {
            [VectorType]
            public long[] input_ids { get; set; }
            [VectorType]
            public long[] attention_mask { get; set; }
        }

        public class BertOutput
        {
            [VectorType]
            public float[] sentence_embedding { get; set; }
        }

        public class QAItem
        {
            public string Question { get; set; }
            public string Answer { get; set; }
            public float[] Embedding { get; set; }
        }


    }
}
