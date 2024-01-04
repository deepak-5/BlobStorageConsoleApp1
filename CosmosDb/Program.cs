using System;
using System.Linq;
using Microsoft.Azure.Cosmos;

class Program
{
    static async Task Main(string[] args)
    {
        string cosmosConnectionString = "AccountEndpoint=https://task2.documents.azure.com:443/;AccountKey=laDwDHARc8h4cnclVNdprFEFffx5a62ZpePY1Pkteejv1aF01jrwqwUrqN8ItaCV9L965kwBKc1KACDbL7fWgw==;";
        string databaseName = "TaskCosmosDb";
        string containerName = "Task1";

        using (var client = new CosmosClient(cosmosConnectionString))
        {
            var database = client.GetDatabase(databaseName);
            var container = database.GetContainer(containerName);

            // Example query to retrieve all items in the container
            var query = container.GetItemQueryIterator<dynamic>(new QueryDefinition("SELECT * FROM c"));
            while (query.HasMoreResults)
            {
                FeedResponse<dynamic> resultSet = await query.ReadNextAsync();
                foreach (var item in resultSet)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
