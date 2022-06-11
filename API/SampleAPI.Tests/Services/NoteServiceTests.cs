namespace SampleAPI.Tests.Services;

public class NoteServiceTests
{
    private readonly INoteService _noteService;

    public NoteServiceTests(INoteService noteService)
    {
        _noteService = noteService;
    }
    
    [Fact]
    public async Task TestCreateUpdate()
    {
        var note = new NotesModel { NoteMessage = "Unit testing" };
        note = await _noteService.CreateUpdate(note);
        Assert.NotEqual(0, note.NoteId);
        Assert.NotEqual(DateTime.MinValue, note.CreateDate);
        Assert.NotEqual(DateTime.MinValue, note.UpdateDate);
    }
}