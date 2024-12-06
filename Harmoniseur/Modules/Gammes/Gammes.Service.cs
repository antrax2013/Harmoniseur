using Solfege.Sdk.Modules.Notes;

namespace Solfege.Sdk.Modules.Gammes;

public static class GammesService
{
    public static IEnumerable<Note> Lister(Gamme gamme)
    {
        List<Note> notes = [];

        foreach (Intervalles.Intervalle intervalle in gamme.Intervalles)
        {
            Note? note = ServiceNotes.Chercher(gamme.Tonique, intervalle.Distance);
            if (note != null)
            {
                notes.Add(note);
            }
        }
        return notes;
    }
}
