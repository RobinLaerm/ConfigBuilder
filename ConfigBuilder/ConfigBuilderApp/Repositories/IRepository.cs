using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigBuilderApp.Repositories
{
    /// <summary>
    /// Common interface for all repositories.
    /// </summary>
    /// <typeparam name="TElement">type of domain objects</typeparam>
    /// <typeparam name="TKey">type of the key property</typeparam>
    public interface IRepository<TElement, TKey>
    {
        /// <summary>
        /// Returns a list of all domain objects.
        /// </summary>
        /// <returns></returns>
        List<TElement> GetAll();

        /// <summary>
        /// Returns the domain object for the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TElement GetById(TKey id);

        /// <summary>
        /// Adds the instance to the repository.
        /// </summary>
        /// <param name="instance"></param>
        void Add(TElement instance);

        /// <summary>
        /// Removes the instance from the repository.
        /// </summary>
        /// <param name="instance"></param>
        void Remove(TElement instance);

        /// <summary>
        /// Saves all changes made in the repository.
        /// </summary>
        void SaveChanges();
    }
}
