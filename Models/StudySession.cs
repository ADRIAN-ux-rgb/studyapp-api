namespace StudyApp.Api.Models
{
    public class StudySession
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ContentId { get; set; }
        public DateTime StudyDate { get; set; }
        public int MinutesStudied { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}