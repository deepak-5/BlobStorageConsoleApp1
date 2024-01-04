using System;
using Azure.Messaging.EventGrid;
using System.Threading.Tasks;
using Azure;

class Program
{
    static async Task Main(string[] args)
    {
        string topicEndpoint = "YOUR_TOPIC_ENDPOINT"; // Replace with your Event Grid topic endpoint
        string topicKey = "YOUR_TOPIC_KEY"; // Replace with your Event Grid topic key

        await PublishEventAsync(topicEndpoint, topicKey);
    }

    static async Task PublishEventAsync(string topicEndpoint, string topicKey)
    {
        Uri endpoint = new Uri(topicEndpoint);
        AzureKeyCredential credential = new AzureKeyCredential(topicKey);

        EventGridPublisherClient client = new EventGridPublisherClient(endpoint, credential);

        //var eventData = new[]
        //{
        //    new EventGridEvent(
        //       //source: new Uri("https://example.com/myapp"),
        //        type: "SampleEventType",
        //        data: BinaryData.FromObjectAsJson(new { Message = "Hello, Event Grid!" }),
        //        subject: "myapp/sampleevent"
        //    )
        //};

        //await client.SendEventsAsync(eventData);
        Console.WriteLine("Event published successfully!");
    }
}
