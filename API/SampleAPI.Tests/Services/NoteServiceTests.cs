using Xunit.Abstractions;

namespace SampleAPI.Tests.Services;

public class NoteServiceTests
{
    private readonly INoteService _noteService;
    private readonly ITestOutputHelper _testOutputHelper;

    public NoteServiceTests(INoteService noteService, ITestOutputHelper testOutputHelper)
    {
        _noteService = noteService;
        _testOutputHelper = testOutputHelper;
    }
    
    [Fact]
    public async Task TestCreateUpdate()
    {
        var note = new NotesModel { NoteMessage = "Unit testing" };
        note = await _noteService.CreateUpdate(note);
        Assert.NotEqual(0, note.NoteId);
        Assert.NotEqual(DateTime.MinValue, note.CreateDate);
        Assert.NotEqual(DateTime.MinValue, note.UpdateDate);
        var findNote1 = await _noteService.ReadSingle(note.NoteId);
        Assert.NotNull(findNote1);
        await _noteService.Delete(note);
        var findNote2 = await _noteService.ReadSingle(note.NoteId);
        Assert.Null(findNote2);
    }
    
    [Fact]
    public Task TestReadAll()
    {
        var notes = _noteService.ReadAll();

        foreach (var note in notes.Result)
        {
            _testOutputHelper.WriteLine(note.NoteMessage);
        }
        
        Assert.NotNull(notes);
        return Task.CompletedTask;
    }
    
}