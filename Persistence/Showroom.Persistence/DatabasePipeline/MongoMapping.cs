using Gatherin.Domain.Model;
using MongoDB.Bson.Serialization;

namespace Gatherin.Persistence.DatabasePipeline
{
    /// <summary>
    /// Maps the Entity classes to BSON and specifies important attributes
    /// </summary>
    public class MongoMapping
    {
        private static bool _areMappingsRegistered = false;

        /// <summary>
        /// Register the mappings
        /// </summary>
        public static void Register()
        {
            if (!_areMappingsRegistered)
            {
                BsonClassMap.RegisterClassMap<Car>(cm =>
                {
                    cm.AutoMap();
                    cm.MapIdMember(c => c.Id); //.SetIdGenerator(CombGuidGenerator.Instance);
                });
                _areMappingsRegistered = true;
            }
        }
    }
}
