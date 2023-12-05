namespace ScreenSound.Modelos;

internal interface IAssessable
{
    double NoteAverage { get; }
    void AddNote(Rate note);
}
