namespace SampleAPI.Shared.Model;

public class NotesModel
{
    public int NoteId { get; set; }
    public string? NoteMessage { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
}