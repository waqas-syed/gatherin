using System.Collections.Generic;
using Gatherin.Domain.Model;

namespace Gatherin.Persistence.Repositories
{
    /// <summary>
    /// Specific operations related to cars
    /// </summary>
    public interface ICarRepository : IRepository<Car>
    {
        IList<Car> GetAllCarByEmail(string email);
    }
}
