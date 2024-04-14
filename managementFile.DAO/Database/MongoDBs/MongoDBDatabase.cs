using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace managementFile.DAO.Database.MongoDBs
{
    public class MongoDBDatabase : IMongoDBDatabase
    {
        public MongoDBDatabase()
        {
        }

        public IMongoDatabase ConnectMongoDb() 
        {

            string currentDirectory = Directory.GetCurrentDirectory();
            var parentDirectory = Directory.GetParent(currentDirectory);
            var parentDirectoryPath = parentDirectory?.FullName;


            string libraryDirectory = Path.Combine(parentDirectoryPath,"managementFile.DAO");

            var builder = new ConfigurationBuilder()
            .SetBasePath(libraryDirectory) // Thiết lập đường dẫn cơ sở cho tìm kiếm tệp cấu hình
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);


            IConfiguration configuration = builder.Build();

            var connectionString = configuration.GetConnectionString("MongoDB");

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ManagementFile");

            return database;
        }
    }
}
