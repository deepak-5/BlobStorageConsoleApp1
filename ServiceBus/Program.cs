using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace ServiceBusExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string serviceBusConnectionString = "Endpoint=sb://sbexample1.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=xZnxCBAUVvcmQ4OkAd9kcaryZiNjzCoC9+ASbP5ZMr8=";
            string queueName = "NewQueue";

            await using var client = new ServiceBusClient(serviceBusConnectionString);
            ServiceBusSender sender = client.CreateSender(queueName);

            // Send a message
            string messageBody = "Hello, Service Bus!";
            ServiceBusMessage message = new ServiceBusMessage(Encoding.UTF8.GetBytes(messageBody));
            await sender.SendMessageAsync(message);
            Console.WriteLine($"Sent message: The Message Sent is -> {messageBody}");
            Console.WriteLine("");

            // Receive and process messages
            ServiceBusProcessor processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions());
            processor.ProcessMessageAsync += ProcessMessagesAsync;
            processor.ProcessErrorAsync += ErrorHandler;
            await processor.StartProcessingAsync();

            Console.ReadLine(); // Keep the application running
            await processor.StopProcessingAsync();
        }

        static async Task ProcessMessagesAsync(ProcessMessageEventArgs args)
        {
            string messageBody = args.Message.Body.ToString();
            Console.WriteLine($"Received message: The Message Recived is This ->  {messageBody}");

            // Process the message here

            await args.CompleteMessageAsync(args.Message);
        }

        static Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine($"Error: {args.Exception}");
            return Task.CompletedTask;
        }
    }
}
