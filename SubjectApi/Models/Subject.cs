namespace SubjectApi.Models
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string? SubjectName { get; set; }
        public sbyte NumberOfHours { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastUpdatedTime { get; set; }
    }
}
