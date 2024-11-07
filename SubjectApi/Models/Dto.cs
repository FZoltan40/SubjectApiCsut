namespace SubjectApi.Models
{
    public record CreateSubjectDto(string SubjectName, sbyte NumberOfHours, string Description);
}