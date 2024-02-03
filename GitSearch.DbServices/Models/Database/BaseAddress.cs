namespace GitSearch.DbServices.Models.Database
{
    public class BaseAddress : BaseModel
    {
        /// <summary>
        ///     StreetAddress
        /// </summary>
        public string? StreetAddress { get; set; }

        /// <summary>
        ///     City
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        ///     State
        /// </summary>
        public string? State { get; set; }

        /// <summary>
        ///     PostalCode
        /// </summary>
        public string? PostalCode { get; set; }

        /// <summary>
        ///     Country
        /// </summary>
        public string? Country { get; set; }

        /// <summary>
        ///     Latitude
        /// </summary>
        public string? Latitude { get; set; }

        /// <summary>
        ///     Logtitude
        /// </summary>
        public string? Logtitude { get; set; }

    }
}
