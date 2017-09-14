using System.Collections.Generic;
using Gatherin.Domain.Model;
using Gatherin.Domain.Model.GatherinAggregate;

namespace Gatherin.Persistence.Repositories
{
    /// <summary>
    /// Specific operations related to cars
    /// </summary>
    public interface ICarRepository : IRepository<Gathering>
    {
        IList<Gathering> GetAllCarByEmail(string email);
    }
}
