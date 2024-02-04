namespace GitSearch.DbServices.Interfaces
{
    /// <summary>
    ///     Generic interface for basic CRUD operations on entities.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseService<T>
       where T : class
    {
        /// <summary>
        /// Gets all items from the database.
        /// </summary>
        /// <returns>List of active items.</returns>
        Task<List<T>> GetAllAsync();

        /// <summary>
        /// Gets an item with the given id from the database.
        /// </summary>
        /// <param name="id">Item Id.</param>
        /// <returns>Item with the given Id.</returns>
        Task<T> GetAsync(int id);

        /// <summary>
        /// Adds an item to the database.
        /// </summary>
        /// <param name="Item">The model to be added.</param>
        /// <returns>HttpResponseMessage indicating the result of the add operation.</returns>
        Task<HttpResponseMessage> AddAsync(T Item);

        /// <summary>
        /// Removes an item from the database.
        /// </summary>
        /// <param name="Id">Item Id.</param>
        /// <returns>HttpResponseMessage indicating the result of the remove operation.</returns>
        Task<HttpResponseMessage> RemoveAsync(int Id);

        /// <summary>
        /// Edits an item in the database.
        /// </summary>
        /// <param name="Id">Item Id.</param>
        /// <param name="Item">The updated item.</param>
        /// <returns>HttpResponseMessage indicating the result of the edit operation.</returns>
        Task<HttpResponseMessage> EditAsync(int Id, T Item);
    }
}
