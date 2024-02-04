using GitSearch.DbServices.Interfaces;
using System.Net.Http.Json;

namespace GitSearch.DbServices.Services
{
    /// <summary>
    ///     Generic base service class implementing basic CRUD operations for entities using an HTTP API.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    public class BaseService<T>
        : IBaseService<T>
        where T : class
    {
        #region Variables

        /// <summary>
        ///     Http client to send post requests.
        /// </summary>
        public readonly HttpClient _httpClient;

        /// <summary>
        ///     Url to API calls.
        /// </summary>
        public readonly string URL;

        /// <summary>
        ///     Uri of the API endpoint.
        /// </summary>
        public readonly string URI;

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="BaseService{T}"/> class.
        /// </summary>
        /// <param name="_URI">The URI of the API endpoint.</param>
        public BaseService(string _URI)
        {
            URL = "https://localhost:7048/swagger/v1/swagger.json";
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(URL);
            URI = _URI;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public async Task<HttpResponseMessage> AddAsync(T Item)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(URI, Item);
                response.EnsureSuccessStatusCode();
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"Endpoint: {URI}\nFailed to retrieve data from API. Task<bool> AddAsync(T Item)", ex);
            }
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> EditAsync(int Id, T Item)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync(URI + Id, Item);
                response.EnsureSuccessStatusCode();
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"Endpoint: {URI}\nFailed to retrieve data from API. Task<bool> EditAsync(int Id, T Item)", ex);
            }
        }

        /// <inheritdoc />
        public async Task<List<T>> GetAllAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(URI);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadFromJsonAsync<List<T>>();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Endpoint: {URI}\nFailed to retrieve data from API. Task<List<T>> GetAllAsync()", ex);
            }
        }

        /// <inheritdoc />
        public async Task<T> GetAsync(int Id)
        {
            try
            {
                var response = await _httpClient.GetAsync(URI + Id);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadFromJsonAsync<T>();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Endpoint: {URI}\nFailed to retrieve data from API. Task<T> GetAsync(int Id)", ex);
            }
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> RemoveAsync(int Id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync(URI + Id);
                response.EnsureSuccessStatusCode();
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"Endpoint: {URI}\nFailed to retrieve data from API. Task<bool> RemoveAsync(int Id)", ex);
            }
        }

        #endregion
    }
}
