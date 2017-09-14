using System.Collections.Generic;
using Gatherin.Domain.Model;
using Gatherin.Persistence.DatabasePipeline;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Gatherin.Persistence.Repositories
{
    public class CarsRepository : ICarRepository
    {
        private IMongoCollection<Car> _mongoCollection;

        public CarsRepository(IMongoConfiguration configuration)
        {
            _mongoCollection = configuration.MongoDatabase.GetCollection<Car>(typeof(Car).Name);
        }
        
        /// <summary>
        /// Add a new car
        /// </summary>
        /// <param name="instance"></param>
        public void Add(Car instance)
        {
            _mongoCollection.InsertOne(instance);
        }

        /// <summary>
        /// Update an existing car  
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public bool Update(Car instance)
        {
            var filter = Builders<Car>.Filter.Eq("Id", instance.Id);
            var update = Builders<Car>.Update
                .Set("Name", instance.Name)
                .Set("Company", instance.Company)
                .Set("ModelYear", instance.ModelYear)
                .Set("OwnerEmail", instance.OwnerEmail);
            UpdateResult result = _mongoCollection.UpdateOne(filter, update);
            return result.ModifiedCount == 1;
        }

        /// <summary>
        /// Delete the car with the given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            var filter = Builders<Car>.Filter.Eq("Id", id);
            var deleteResult = _mongoCollection.DeleteOne(filter);
            return deleteResult.DeletedCount == 1;
        }

        /// <summary>
        /// Get the instance of the car with the given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Car GetInstance(string id)
        {
            return _mongoCollection.Find(x => x.Id == id).SingleOrDefault();
        }

        /// <summary>
        /// Get all Cars
        /// </summary>
        /// <returns></returns>
        public IList<Car> GetAllInstances()
        {
            return _mongoCollection.Find(new BsonDocument()).ToList();
        }

        /// <summary>
        /// Get all the cars by their owner's email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public IList<Car> GetAllCarByEmail(string email)
        {
            var filter = Builders<Car>.Filter.Eq("OwnerEmail", email);
            return _mongoCollection.Find(filter).ToList();
        }
    }
}
