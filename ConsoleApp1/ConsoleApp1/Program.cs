using System;
using Azure;
using System.Globalization;
using Azure.AI.TextAnalytics;

namespace ConsoleApp1
{
    class Program
    {
        private static readonly AzureKeyCredential credentials = new AzureKeyCredential("413f9038b58f4b40a8b47503233304d7");
        private static readonly Uri endpoint = new Uri("https://text1isgs.cognitiveservices.azure.com/");

        static void Main(string[] args)
        {
            var client = new TextAnalyticsClient(endpoint, credentials);
           
            KeyPhraseExtractionExample(client);

            Console.Write("Press any key to exit.");
            Console.ReadKey();
        }

        static void KeyPhraseExtractionExample(TextAnalyticsClient client)
        {
            var response = client.ExtractKeyPhrases("Показательное превосходство насилие мужчина насилие");
            // Printing key phrases
            Console.WriteLine("Key phrases:");

            foreach (string keyphrase in response.Value)
            {
                Console.WriteLine($"\t{keyphrase}");
            }
        }
    }
}
