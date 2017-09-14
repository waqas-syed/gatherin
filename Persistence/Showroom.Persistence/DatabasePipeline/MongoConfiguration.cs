﻿using Gatherin.Common;
using MongoDB.Driver;

namespace Gatherin.Persistence.DatabasePipeline
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
            if (_mongoClient == null)
            {
                _mongoClient = new MongoClient(Constants.MongoServer);
                _mongoDatabase = _mongoClient.GetDatabase(Constants.MongoDatabase);
            }
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
