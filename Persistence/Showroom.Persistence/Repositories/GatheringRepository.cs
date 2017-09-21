using Gatherin.Domain.Model.GatherinAggregate;
using Gatherin.Persistence.DatabasePipeline;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Gatherin.Persistence.Repositories
{
    /// <summary>
    /// Gathering Repository
    /// </summary>
    public class GatheringRepository : IGatheringRepository
    {
        private IMongoCollection<Gathering> _mongoCollection;

        /// <summary>
        /// Gathering repository
        /// </summary>
        /// <param name="configuration"></param>
        public GatheringRepository(IMongoConfiguration configuration)
        {
            _mongoCollection = configuration.MongoDatabase.GetCollection<Gathering>(typeof(Gathering).Name);
        }
        
        /// <summary>
        /// Add a new car
        /// </summary>
        /// <param name="instance"></param>
        public void Add(Gathering instance)
        {
            _mongoCollection.InsertOne(instance);
        }

        /// <summary>
        /// Update an existing car  
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public bool Update(Gathering instance)
        {
            var filter = Builders<Gathering>.Filter.Eq(x => x.Id, instance.Id);
            var update = Builders<Gathering>.Update
                .Set(x => x.Title, instance.Title)
                .Set(x => x.Description, instance.Description)
                .Set(x => x.DateOfMeeting, instance.DateOfMeeting)
                .Set(x => x.OrganizerEmail, instance.OrganizerEmail)
                .Set(x => x.Topic, instance.Topic)
                .Set(x => x.Venue, instance.Venue)
                .Set(x => x.IsVideoGathering, instance.IsVideoGathering)
                .Set(x => x.VideoCallLink, instance.VideoCallLink)
                .Set(x => x.Location.Latitude, instance.Location.Latitude)
                .Set(x => x.Location.Longitude, instance.Location.Longitude)
                .Set(x => x.Location.Area, instance.Location.Area);
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
            var filter = Builders<Gathering>.Filter.Eq(x => x.Id, id);
            var deleteResult = _mongoCollection.DeleteOne(filter);
            return deleteResult.DeletedCount == 1;
        }

        /// <summary>
        /// Get the instance of the car with the given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Gathering GetInstance(string id)
        {
            return _mongoCollection.Find(x => x.Id == id).SingleOrDefault();
        }

        /// <summary>
        /// Get all Cars
        /// </summary>
        /// <returns></returns>
        public IList<Gathering> GetAllInstances()
        {
            return _mongoCollection.Find(new BsonDocument()).ToList();
        }

        /// <summary>
        /// Get all the cars by their owner's email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public IList<Gathering> GetAllGatheringsByEmail(string email)
        {
            var filter = Builders<Gathering>.Filter.Eq(x => x.OrganizerEmail, email);
            return _mongoCollection.Find(filter).ToList();
        }

        /// <summary>
        /// Add a new attendee to the list of attendees who will attend the meeting
        /// </summary>
        /// <param name="gatheringId"></param>
        /// <param name="attendee"></param>
        /// <returns></returns>
        public bool AddNewAttendeeToList(string gatheringId, Attendee attendee)
        {
            var filter = Builders<Gathering>.Filter.Eq(x => x.Id, gatheringId);
            var update = Builders<Gathering>.Update.Push(x => x.Attendees, attendee);

            var updateResult = _mongoCollection.FindOneAndUpdate(filter, update);
            return true;

            // Sample code if the Attendees array had another array
            /*var gift1 = new Gift("Night Gown", 23.89M);
            var gift2 = new Gift("Sword", 56.09M);
            var query2 = Builders<Gathering>.Filter.And(
                Builders<Gathering>.Filter.Eq(x => x.Id, gatheringId),
                Builders<Gathering>.Filter.Eq("Attendees.FullName", "Khaleesi"));
            var update2 = Builders<Gathering>.Update.Push("Attendees.$.Gifts", gift1);
            _mongoCollection.FindOneAndUpdate(query2, update2);
            var update3 = Builders<Gathering>.Update.Push("Attendees.$.Gifts", gift2);
            _mongoCollection.FindOneAndUpdate(query2, update3);
            return true;*/
        }
    }
}
