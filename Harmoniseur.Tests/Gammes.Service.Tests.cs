using NFluent;
using Solfege.Sdk.Modules.Gammes;
using Solfege.Sdk.Modules.Intervalles;
using Solfege.Sdk.Modules.Notes;

namespace Solfege.Sdk.Test;

internal class GammesServiceTests
{
    private readonly Gamme GammeDoMajeur = new(
        new Note("Do"),
        [
            ServiceIntervalles.Chercher("Unisson"),
            ServiceIntervalles.Chercher("Seconde"),
            ServiceIntervalles.Chercher("Tierce"),
            ServiceIntervalles.Chercher("Quarte"),
            ServiceIntervalles.Chercher("Quinte"),
            ServiceIntervalles.Chercher("Sixte"),
            ServiceIntervalles.Chercher("Septième"),
        ]
    );

    private readonly Gamme GammePentatoniqueDoMajeur = new(
        new Note("Do"),
        [
            ServiceIntervalles.Chercher("Unisson"),
            ServiceIntervalles.Chercher("Seconde"),
            ServiceIntervalles.Chercher("Tierce"),
            ServiceIntervalles.Chercher("Quinte"),
            ServiceIntervalles.Chercher("Sixte"),
        ]
    );

    [Test]
    public void Quand_Je_Liste_Les_Notes_De_La_Gamme_De_Do_Majeur_J_Obtiens_Les_7_Notes_Non_Alterees()
    {
        // When
        List<Note> Notes = GammesService.Lister(GammeDoMajeur).ToList();

        // Then
        List<string> nomsDesNotes = Notes.Select(note => note.Nom).ToList();
        Check.That(nomsDesNotes).ContainsExactly([
            "Do", "Ré", "Mi", "Fa", "Sol", "La", "Si",
        ]);
    }

    [Test]
    public void Quand_Je_Liste_Les_Notes_De_La_Pentatonique_De_Do_Majeur_J_Obtiens_Les_5_Notes_Attendues()
    {
        // When
        List<Note> Notes = GammesService.Lister(GammePentatoniqueDoMajeur).ToList();

        // Then
        List<string> nomsDesNotes = Notes.Select(note => note.Nom).ToList();
        Check.That(nomsDesNotes).ContainsExactly([
            "Do", "Ré", "Mi", "Sol", "La",
        ]);
    }
}
