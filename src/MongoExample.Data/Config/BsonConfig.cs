using MongoExample.Data.Config.Entities;

namespace MongoExample.Data.Config
{
    public static class BsonConfig
    {
        public static void Configure()
        {
            new BaseModelConfig();
        }
    }
}
