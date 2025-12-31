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
    
[HttpGet]
public IActionResult GetStudySessions()
{
    var connectionString = _configuration.GetConnectionString("DefaultConnection");

    using var connection = new MySqlConnection(connectionString);
    connection.Open();

    var query = "SELECT * FROM study_sessions";

    using var command = new MySqlCommand(query, connection);
    using var reader = command.ExecuteReader();

    var sessions = new List<StudySession>();

    while (reader.Read())
    {
        var session = new StudySession();

        session.Id = reader.GetInt32("id");
        session.UserId = reader.GetInt32("user_id"); // ✔ obrigatório
        session.StudyDate = reader.GetDateTime("study_date");
        session.MinutesStudied = reader.GetInt32("minutes_studied");

        if (reader.IsDBNull(reader.GetOrdinal("content_id")))
            session.ContentId = null;
        else
            session.ContentId = reader.GetInt32("content_id");

        if (reader.IsDBNull(reader.GetOrdinal("created_at")))
            session.CreatedAt = DateTime.MinValue;
        else
            session.CreatedAt = reader.GetDateTime("created_at");

        sessions.Add(session);
    }

    return Ok(sessions);
}
    }
}
