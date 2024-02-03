using System.ComponentModel.DataAnnotations;

namespace GitSearch.DbServices.Models.Database
{
    public class BaseModel
    {
        /// <summary>
        ///     Id
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        ///     CreationDate
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        ///     ModificationDate
        /// </summary>
        public DateTime ModificationDate { get; set; }

        /// <summary>
        ///     IsActive
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        ///     Notes
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        ///     Title
        /// </summary>
        public string? Title { get; set; }
    }
}
