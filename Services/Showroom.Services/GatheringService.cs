using System.Collections.Generic;
using Gatherin.Domain.Model.GatherinAggregate;
using Gatherin.Persistence.Repositories;

namespace Gatherin.Services
{
    /// <summary>
    /// Service to handle the workflow for the Cars
    /// </summary>
    public class GatheringService : IGatheringService
    {
        private IGatheringRepository _gatheringRepository;

        /// <summary>
        /// Initialzie the service given the GatheringRepository
        /// </summary>
        /// <param name="gatheringRepository"></param>
        public GatheringService(IGatheringRepository gatheringRepository)
        {
            _gatheringRepository = gatheringRepository;
        }

        /// <summary>
        /// Add a new Gathering
        /// </summary>
        /// <param name="gathering"></param>
        public void AddNewGathering(Gathering gathering)
        {
            _gatheringRepository.Add(gathering);
        }

        /// <summary>
        /// Update an existing gathering
        /// </summary>
        /// <param name="gathering"></param>
        public void UpdateGathering(Gathering gathering)
        {
            _gatheringRepository.Update(gathering);
        }

        /// <summary>
        /// Get the gathering by the given Email
        /// </summary>
        /// <returns></returns>
        public IList<Gathering> GetAllGatheringByEmail(string email)
        {
            return _gatheringRepository.GetAllGatheringsByEmail(email);
        }

        /// <summary>
        /// Get the gathering by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Gathering GetGatheringById(string id)
        {
            return _gatheringRepository.GetInstance(id);
        }

        /// <summary>
        /// Get all the Gathering that are present in the Database
        /// </summary>
        /// <returns></returns>
        public IList<Gathering> GetAllGatherings()
        {
            return _gatheringRepository.GetAllInstances();
        }

        /// <summary>
        /// Delete the gathering with the given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            return _gatheringRepository.Delete(id);
        }

        /// <summary>
        /// Add a new Attendee to a Gathering
        /// </summary>
        /// <param name="gatheringId"></param>
        /// <param name="attendee"></param>
        public void AddNewAttendee(string gatheringId, Attendee attendee)
        {
            _gatheringRepository.AddNewAttendeeToList(gatheringId, attendee);
        }
    }
}
