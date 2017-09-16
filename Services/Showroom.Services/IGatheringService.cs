using System.Collections.Generic;
using Gatherin.Domain.Model.GatherinAggregate;

namespace Gatherin.Services
{
    /// <summary>
    /// ICarService
    /// </summary>
    public interface IGatheringService
    {
        /// <summary>
        /// Create a new gathering
        /// </summary>
        /// <param name="gathering"></param>
        void AddNewGathering(Gathering gathering);

        /// <summary>
        /// Update an existing Gathering
        /// </summary>
        /// <param name="gathering"></param>
        void UpdateGathering(Gathering gathering);

        /// <summary>
        /// Get all the gathering by the given email
        /// </summary>
        /// <returns></returns>
        IList<Gathering> GetAllGatheringByEmail(string email);

        /// <summary>
        /// Get a gathering by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Gathering GetGatheringById(string id);

        /// <summary>
        /// Get all the Gathering that are present in the Database
        /// </summary>
        /// <returns></returns>
        IList<Gathering> GetAllGatherings();

        /// <summary>
        /// Delete the Gathering with the provided ID
        /// </summary>
        /// <param name="id"></param>
        bool Delete(string id);

        /// <summary>
        /// Add a new Attendee to the specified gathering
        /// </summary>
        /// <param name="gatheringId"></param>
        /// <param name="attendee"></param>
        void AddNewAttendee(string gatheringId, Attendee attendee);
    }
}
