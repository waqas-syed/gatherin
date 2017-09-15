using Gatherin.Domain.Model;
using Gatherin.Domain.Model.GatherinAggregate;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

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
                /*BsonClassMap.RegisterClassMap<Gathering>(cm =>
                {
                    cm.AutoMap();
                    cm.MapIdMember(c => c.Id).SetIdGenerator();
                });
                _areMappingsRegistered = true;*/
            }
        }
    }
}
