using System;
using Azure;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define the name of your Azure Key Vault
            var keyVaultName = "trainingexmple1";

            // Construct the URI for your Key Vault
            var kvUri = $"https://{keyVaultName}.vault.azure.net";

            // Create a SecretClient instance to interact with Azure Key Vault
            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

            // Define the name of the secret you want to retrieve
            var secretName = "Secret-key-New";

            // Retrieve the specified secret from Azure Key Vault
            KeyVaultSecret secret = client.GetSecret(secretName);

            // Display the value of the retrieved secret
            Console.WriteLine($"Secret: {secret.Value}");
        }
        catch (RequestFailedException ex)
        {
            // Handle any exceptions that might occur during the retrieval process
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
