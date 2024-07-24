using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace AzureTesting
{
    public static class KeyVaultConfig
    {
        public static async Task AddKeyVaultSecrets(IConfigurationBuilder configurationBuilder)
        {
            var keyVaultUrl = "https://privatekeygrabowsky.vault.azure.net/";
            var secretClient = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

            // Pobranie sekretów
            var secretToken = await secretClient.GetSecretAsync("jwtTokenKey");
            var sqlToken = await secretClient.GetSecretAsync("sqlConnection");
            var blobToken = await secretClient.GetSecretAsync("blobConnection");

            // Ustawienie sekretów w konfiguracji
            configurationBuilder.AddInMemoryCollection(new Dictionary<string, string?>
        {
            { "AppSettings:Token", secretToken.Value.Value },
            { "ConnectionStrings:DefaultConnection", sqlToken.Value.Value },
            { "AzureBlobStorage:ConnectionString", blobToken.Value.Value }
        });
        }
    }
}
