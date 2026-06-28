using Microsoft.SemanticKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MachineLearningCode
{
    public class GreetingPlugin
    {
        [KernelFunction]
        [Description("This function takes a name as input and returns a greeting message.")]
        public string SayHello(string name)
        {
            return $"Hello {name}, welcome to Semantic Kernel! This is a simple greeting function.";
        }
    }


    public class RepldgeFilePlugin
    {
        [KernelFunction]
        [Description("This function generates a RepldgeFile")]
        public string RepldgeFileFunction()
        {
            return "Sample RepldgeFile";
        }
    }


}
