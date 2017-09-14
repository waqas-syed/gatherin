using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Showroom.Domain.Model;

namespace Showroom.Persistence.Repositories
{
    /// <summary>
    /// Specific operations related to cars
    /// </summary>
    public interface ICarRepository : IRepository<Car>
    {
        IList<Car> GetAllCarByEmail(string email);
    }
}
