using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoExample.Domain.Entities;

namespace MongoExample.Data.Config.Entities
{
    public class CustomerConfig
    {
        public CustomerConfig()
        {
            BsonClassMap.RegisterClassMap<Customer>(cm =>
            {
                cm.AutoMap();
                cm.MapMember(x => x.Id)
                    .SetSerializer(new StringSerializer(MongoDB.Bson.BsonType.ObjectId))
                    .SetIdGenerator(StringObjectIdGenerator.Instance);
            });
        }
    }
}
