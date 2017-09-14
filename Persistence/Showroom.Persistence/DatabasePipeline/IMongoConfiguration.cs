using MongoDB.Driver;

namespace Gatherin.Persistence.DatabasePipeline
{
    /// <summary>
    /// Configuration for MongoDB
    /// </summary>
    public interface IMongoConfiguration
    {
        /// <summary>
        /// Get the Mongo Client
        /// </summary>
        MongoClient MongoClient { get; }

        /// <summary>
        /// Get the Mongo Database
        /// </summary>
        IMongoDatabase MongoDatabase { get; }
    }
}
