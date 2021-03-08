using System;
using Azure;
using System.Globalization;
using Azure.AI.TextAnalytics;
namespace ConsoleApp1
{
	class Program
	{
		// Text Analytics
		private static readonly AzureKeyCredential credentials = new AzureKeyCredential("YOUR_KEY");
		private static readonly Uri endpoint = new Uri("YOUR_ENDPOINT_SERVICE");
		static void Main(string[] args)
		{
			var client = new TextAnalyticsClient(endpoint, credentials);
			// You will implement these methods later in the quickstart.

			SentimentAnalysisExample(client);

			Console.Write("Press any key to exit.");
			Console.ReadKey();
		}

		static void SentimentAnalysisExample(TextAnalyticsClient client)
		{
			//string inputText = "I had the best day of my life. I wish you were there with me.";
			string inputText = "I liked the food. The host was grumpy.";
			DocumentSentiment documentSentiment = client.AnalyzeSentiment(inputText);
			Console.WriteLine($"Document sentiment: {documentSentiment.Sentiment}\n");

			foreach (var sentence in documentSentiment.Sentences)
			{
				Console.WriteLine($"\tText: \"{sentence.Text}\"");
				Console.WriteLine($"\tSentence sentiment: {sentence.Sentiment}");
				Console.WriteLine($"\tPositive score: {sentence.ConfidenceScores.Positive:0.00}");
				Console.WriteLine($"\tNegative score: {sentence.ConfidenceScores.Negative:0.00}");
				Console.WriteLine($"\tNeutral score: {sentence.ConfidenceScores.Neutral:0.00}\n");
			}
		}

	}
}
