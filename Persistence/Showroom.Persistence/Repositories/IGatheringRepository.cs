using Gatherin.Domain.Model.GatherinAggregate;
using System.Collections.Generic;

namespace Gatherin.Persistence.Repositories
{
    /// <summary>
    /// Specific operations related to cars
    /// </summary>
    public interface IGatheringRepository : IRepository<Gathering>
    {
        /// <summary>
        /// Get all the gathering by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        IList<Gathering> GetAllGatheringsByEmail(string email);

        /// <summary>
        /// Add a new Attendee to the list of people who are joining the gathering
        /// </summary>
        /// <param name="gatheringId"></param>
        /// <param name="attendee"></param>
        /// <returns></returns>
        bool AddNewAttendeeToList(string gatheringId, Attendee attendee);
    }
}
