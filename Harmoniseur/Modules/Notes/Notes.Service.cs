using System.Collections.Immutable;

namespace Solfege.Sdk.Modules.Notes;
public static class ServiceNotes
{
    private static readonly ImmutableArray<Note> _notes = [
        new("Do"),
        new("Do#","Réb"),
        new("Ré"),
        new("Ré#","Mib"),
        new("Mi","Fab"),
        new("Fa"),
        new("Fa#", "Solb"),
        new("Sol"),
        new("Sol#", "Lab"),
        new("La"),
        new("La#","Sib"),
        new("Si")
    ];

    public static Note? Chercher(string nomNote)
    {
        return _notes.FirstOrDefault(n =>
                n.Nom.Equals(nomNote, StringComparison.CurrentCultureIgnoreCase)
            || n.NomRenverse.Equals(nomNote, StringComparison.CurrentCultureIgnoreCase));
    }

    public static Note? Chercher(string nomNote, int distance)
    {
        Note? note = Chercher(nomNote);
        if (note == null)
            return null;

        return note.Chercher(distance);
    }

    public static Note? Chercher(this Note note, int distance)
    {
        int index = _notes.ToList().FindIndex(n => n.Nom.Equals(note.Nom, StringComparison.CurrentCultureIgnoreCase));
        if (index == -1)
            return null;

        if (distance == 0)
            return note;

        return _notes[(index + distance) % _notes.Length];
    }

    public static Note? Precedente(string nomNote)
    {
        Note? note = Chercher(nomNote);
        if (note == null)
            return null;

        return note.Precedente();
    }

    public static Note? Precedente(this Note note)
    {
        int index = _notes.IndexOf(note);
        if (index == -1)
            return null;
        if (index == 0)
            return _notes.Last();
        return _notes[index - 1];

    }

    public static Note? Suivante(string nomNote)
    {
        Note? note = Chercher(nomNote);
        if (note == null)
            return null;

        return note.Suivante();
    }

    public static Note? Suivante(this Note note)
    {
        int index = _notes.IndexOf(note);
        return index == -1 ? null : _notes[(index + 1) % _notes.Length];
    }

    public static int? Distance(string nomNoteDeDepart, string nomNoteDArrivee)
    {
        Note? noteDeDepart = Chercher(nomNoteDeDepart);
        if (noteDeDepart == null)
            return null;

        Note? noteDArrivee = Chercher(nomNoteDArrivee);
        if (noteDArrivee == null)
            return null;

        return noteDeDepart.Distance(noteDArrivee);

    }

    public static int? Distance(this Note noteDeDepart, Note noteDArrivee)
    {
        int indexDeDepart = _notes.IndexOf(noteDeDepart);
        int indexDArrivee = _notes.IndexOf(noteDArrivee);

        if (indexDeDepart == -1 || indexDArrivee == -1)
            return null;

        if (indexDeDepart > indexDArrivee)
            indexDArrivee += _notes.Length;
        return indexDArrivee - indexDeDepart;
    }
}
