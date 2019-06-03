using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoExample.Domain.Models;

namespace MongoExample.Data.Config.Entities
{
    public class BaseModelConfig
    {
        public BaseModelConfig()
        {
            BsonClassMap.RegisterClassMap<BaseModel>(cm =>
            {
                cm.AutoMap();
                cm.MapMember(x => x.Id)
                    .SetSerializer(new StringSerializer(MongoDB.Bson.BsonType.ObjectId))
                    .SetIdGenerator(StringObjectIdGenerator.Instance);
                cm.SetIgnoreExtraElements(true);
                cm.SetIgnoreExtraElementsIsInherited(true);
            });
        }
    }
}
