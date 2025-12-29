using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using StudyApp.Api.Models;

namespace StudyApp.Api.Controllers
{
    [ApiController]
    [Route("api/study-sessions")]
    public class StudySessionsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public StudySessionsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult CreateStudySession(StudySession session)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            var query = @"
                INSERT INTO study_sessions
                (user_id, content_id, study_date, minutes_studied)
                VALUES
                (@UserId, @ContentId, @StudyDate, @MinutesStudied);
            ";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserId", session.UserId);
            command.Parameters.AddWithValue("@ContentId", session.ContentId);
            command.Parameters.AddWithValue("@StudyDate", session.StudyDate);
            command.Parameters.AddWithValue("@MinutesStudied", session.MinutesStudied);

            command.ExecuteNonQuery();

            return Ok(new { message = "Study session created successfully" });
        }
    }
}
