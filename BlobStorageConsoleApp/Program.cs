using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

class Program
{
    static async Task Main(string[] args)
    {
        // Replace with your connection string
        string connectionString = "DefaultEndpointsProtocol=https;AccountName=blobfnfi;AccountKey=uCSH8iAYjDslVX/2aohEbIAo4dIfeTdETfZTltRzIDLYKcWmDoQfNJFgnoa7E4BeOf9E2gR6xx1P+AStaDwlIA==;EndpointSuffix=core.windows.net";

        // Create a BlobServiceClient using the connection string
        BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

        // Replace with your container name
        string containerName = "container2";
        BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

        // Upload a blob
        string blobName = "New-Blob-File.txt";
        BlobClient blobClient = containerClient.GetBlobClient(blobName);
        using (var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes("Hello There!")))
        {
            await blobClient.UploadAsync(stream, true);
        }

        //// Upload a blob using user input!
        //Console.Write("Enter the name for the new blob: ");
        //string blobName = Console.ReadLine();

        //Console.Write("Enter the content for the blob: ");
        //string content = Console.ReadLine();

        //BlobClient blobClient = containerClient.GetBlobClient(blobName);
        //using (var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(content)))
        //{
        //    await blobClient.UploadAsync(stream, true);
        //}

        //Console.WriteLine($"Blob '{blobName}' uploaded successfully!");


        // List blobs in the container
        await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
        {
            Console.WriteLine($"Blob: {blobItem.Name}");
        }

        Console.WriteLine("Done!");
    }
}
