namespace GitSearch.DbServices.Models.Database
{
    public class ErrorLog : BaseModel
    {
        public string? ErrorMessage { get; set; }
        public Guid? Company { get; set; }
        public int? Line { get; set; }
        public string? StackTrace { get; set; }
    }
}
