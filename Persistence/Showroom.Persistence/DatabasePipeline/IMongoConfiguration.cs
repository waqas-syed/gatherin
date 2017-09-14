using MongoDB.Driver;

namespace Showroom.Persistence.DatabasePipeline
{
    /// <summary>
    /// Configuration for MongoDB
    /// </summary>
    public interface IMongoConfiguration
    {
        /// <summary>
        /// Initialize the configuration and connect the required wires
        /// </summary>
        void Initialize();

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
