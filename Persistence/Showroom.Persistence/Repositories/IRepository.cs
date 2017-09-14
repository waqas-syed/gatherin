using System.Collections.Generic;

namespace Gatherin.Persistence.Repositories
{
    /// <summary>
    /// Interface for repository of any type
    /// </summary>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Add a new instance of the given type to the database
        /// </summary>
        void Add(T instance);

        /// <summary>
        /// Update the given instance of the given type in the database
        /// </summary>
        /// <param name="instance"></param>
        bool Update(T instance);

        /// <summary>
        /// Delete the instance with the given Id
        /// </summary>
        /// <param name="id"></param>
        bool Delete(string id);

        /// <summary>
        /// Retrieve the instance with the provided Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetInstance(string id);

        /// <summary>
        /// Get all the instance of this type
        /// </summary>
        /// <returns></returns>
        IList<T> GetAllInstances();
    }
}
