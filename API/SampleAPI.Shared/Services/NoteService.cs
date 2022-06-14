namespace SampleAPI.Shared.Services;

public interface INoteService
{
    Task<NotesModel> CreateUpdate(NotesModel note);
    Task<NotesModel?> ReadSingle(int noteId);
    Task<List<NotesModel>> ReadAll();
    Task Delete(NotesModel note);
}

public class NoteService : INoteService
{
    private readonly ConfigurationModel _configuration;
    private readonly DbHelper _db;

    public NoteService(ConfigurationModel configuration,
        DbHelper db)
    {
        _configuration = configuration;
        _db = db;
    }

    public async Task<NotesModel> CreateUpdate(NotesModel note)
    {
        note.UpdateDate = DateTime.Now;

        if (note.NoteId == 0)
        {
            note.CreateDate = DateTime.Now;
            _db.Notes.Add(note);
        }
        else
        {
            _db.Notes.Update(note);
        }

        await _db.SaveChangesAsync();

        return note;
    }

    public Task<NotesModel?> ReadSingle(int noteId)
    {
        var note = _db.Notes.FirstOrDefault(r => r.NoteId == noteId);
        return Task.FromResult(note);
    }
    
    public Task<List<NotesModel>> ReadAll()
    {
        var notes = _db.Notes.ToList();
        return Task.FromResult(notes);
    }
    
    public async Task Delete(NotesModel note)
    {
        _db.Notes.Remove(note);
        await _db.SaveChangesAsync();
    }
    
    private async Task<NotesModel> DapperCreateUpdate(NotesModel note)
    {
        var connection = new SqlConnection();
        connection.ConnectionString = _configuration.ConnectionString;

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
}