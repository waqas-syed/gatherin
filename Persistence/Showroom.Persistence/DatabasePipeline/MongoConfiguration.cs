using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Showroom.Common;
using Showroom.Domain.Model;

namespace Showroom.Persistence.DatabasePipeline
{
    /// <summary>
    /// Configuration Initializer for MongoDB
    /// </summary>
    public class MongoConfiguration : IMongoConfiguration
    {
        private MongoClient _mongoClient;
        private IMongoDatabase _mongoDatabase;

        /// <summary>
        /// Initialize the Database
        /// </summary>
        public MongoConfiguration()
        {
            _mongoClient = new MongoClient(Constants.MongoServer);
            _mongoDatabase = _mongoClient.GetDatabase(Constants.MongoDatabase);
            Initialize();
        }

        /// <summary>
        /// Initialize the MongoDB configuration
        /// </summary>
        public void Initialize()
        {
            BsonClassMap.RegisterClassMap<Car>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(c => c.Id);//.SetIdGenerator(CombGuidGenerator.Instance);
            });
        }

        /// <summary>
        /// Mongo Database
        /// </summary>
        public MongoClient MongoClient { get { return _mongoClient; } }

        /// <summary>
        /// Mongo Database
        /// </summary>
        public IMongoDatabase MongoDatabase { get { return _mongoDatabase; } }
    }
}
