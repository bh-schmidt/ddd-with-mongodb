using Microsoft.Extensions.Configuration;
using System;

namespace MongoExample.Infra.CrossCutting.AppSettings
{
    public static class AppSettings
    {
        public static string MongoDbConnectionString { get; private set; }
        public static string MongoDbDatabaseName { get; private set; }
        public static string CustomerCollectionName { get; private set; }

        public static void Configure(IConfiguration configuration)
        {
            MongoDbConnectionString = configuration.GetConnectionString("MongoDbConnectionString");
            MongoDbDatabaseName = configuration.GetSection("MongoDbDatabaseName").Value;
            CustomerCollectionName = configuration.GetSection("CustomerCollectionName").Value;
        }
    }
}
