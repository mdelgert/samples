namespace SampleAPI.Shared.Services;

public interface INoteService
{
    Task<NotesModel> CreateUpdate(NotesModel note);
}

public class NoteService : INoteService
{
    private readonly ConfigurationModel _configuration;
    
    public NoteService(ConfigurationModel configuration)
    {
        _configuration = configuration;
    }

    public async Task<NotesModel> CreateUpdate(NotesModel note)
    {
        var connection = GetConnection();
        
        await using (connection)
        {
            note = await connection.QuerySingleOrDefaultAsync<NotesModel>("dbo.sp_insertNotes",
                new
                {
                    noteId = note.NoteId,
                    noteMessage = note.NoteMessage
                },
                commandType: CommandType.StoredProcedure);
        }
        
        return note;
    }

    private SqlConnection GetConnection()
    {
        var connection = new SqlConnection();
        connection.ConnectionString = _configuration.ConnectionString;
        return connection;
    }
}