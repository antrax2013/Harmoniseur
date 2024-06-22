using NFluent;
using Solfege.Sdk.Modules.Notes;

namespace Solfege.Sdk.Test;

internal class ServiceNotesTests
{
    [TestCase("Do")]
    [TestCase("Ré")]
    [TestCase("Mi")]
    [TestCase("Fa")]
    [TestCase("Sol")]
    [TestCase("La")]
    [TestCase("SI")]
    [TestCase("DO")]
    [TestCase("do")]
    [TestCase("dO")]
    public void Quand_Je_Cherche_Une_Note_Qui_Existe_J_Obtiens_La_Note_Attendue(string nomNote) {
        // When
        var note = ServiceNotes.Chercher(nomNote);

        // Then
        Check.That(note).IsNotNull();
        Check.That(note?.Nom).IsEqualIgnoringCase(nomNote);
    }

    [TestCase("Do", "Do")]
    [TestCase("Ré", "Ré")]
    [TestCase("Mi", "Mi")]
    [TestCase("Fa", "Fa")]
    [TestCase("Sol", "Sol")]
    [TestCase("La", "La")]
    [TestCase("SI", "Si")]
    [TestCase("DO", "Do")]
    [TestCase("do","Do")]
    [TestCase("dO", "Do")]
    [TestCase("Réb", "Do#")]
    [TestCase("Mib", "Ré#")]
    [TestCase("Fab", "Mi")]
    [TestCase("Solb", "Fa#")]
    [TestCase("Lab", "Sol#")]
    [TestCase("Sib", "La#")]
    public void Quand_Je_Cherche_Une_Note_Qui_Existe_Par_Son_Nom_Inverse_J_Obtiens_La_Note_Attendue(string nomNote, string nomAttendu)
    {
        // When
        var note = ServiceNotes.Chercher(nomNote);

        // Then
        Check.That(note).IsNotNull();
        Check.That(note?.Nom).IsEqualIgnoringCase(nomAttendu);
    }

    [Test]
    public void Quand_Je_Cherche_Une_Note_Qui_N_Existe_Pas_J_Obtiens_Null()
    {
        // When
        var note = ServiceNotes.Chercher("Une Note qui n'existe pas");

        // Then
        Check.That(note).IsNull();
    }

    [TestCase("Do", "Do#")]
    [TestCase("Do#", "Ré")]
    [TestCase("Ré", "Ré#")]
    [TestCase("Ré#", "Mi")]
    [TestCase("Mi", "Fa")]
    [TestCase("Fa", "Fa#")]
    [TestCase("Fa#", "Sol")]
    [TestCase("Sol", "Sol#")]
    [TestCase("Sol#", "La")]
    [TestCase("La", "La#")]
    [TestCase("La#", "Si")]
    [TestCase("Si", "Do")]
    public void Quand_Je_Cherche_La_Note_Suivante_D_Une_Note_Qui_Existe_Par_Son_Nom_J_Obtiens_La_Note_Attendue(string nomNote, string nomAttendu)
    {
        // When
        var noteObetenue = ServiceNotes.Suivante(nomNote);

        // Then
        Check.That(noteObetenue).IsNotNull();
        Check.That(noteObetenue!.Nom).IsEqualIgnoringCase(nomAttendu);
    }

    [Test]
    public void Quand_Je_Cherche_La_Note_Suivante_D_Une_Note_Qui_N_Existe_Pas_J_Obtiens_Null()
    {
        // When
        var note = ServiceNotes.Suivante("Une Note qui n'existe pas");

        // Then
        Check.That(note).IsNull();
    }

    [TestCase("Do#", "Do")]
    [TestCase("Ré", "Do#")]
    [TestCase("Ré#", "Ré" )]
    [TestCase("Mi", "Ré#")]
    [TestCase("Fa", "Mi" )]
    [TestCase("Fa#", "Fa")]
    [TestCase("Sol", "Fa#" )]
    [TestCase("Sol#", "Sol")]
    [TestCase("La", "Sol#")]
    [TestCase("La#", "La")]
    [TestCase("Si", "La#")]
    [TestCase("Do", "Si")]
    public void Quand_Je_Cherche_La_Note_Precedente_D_Une_Note_Qui_Existe_Par_Son_Nom_J_Obtiens_La_Note_Attendue(string nomNote, string nomAttendu)
    {
        // When
        var noteObetenue = ServiceNotes.Precedente(nomNote);

        // Then
        Check.That(noteObetenue).IsNotNull();
        Check.That(noteObetenue!.Nom).IsEqualIgnoringCase(nomAttendu);
    }

    [Test]
    public void Quand_Je_Cherche_La_Note_Precedente_D_Une_Note_Qui_N_Existe_Pas_J_Obtiens_Null()
    {
        // When
        var note = ServiceNotes.Precedente("Une Note qui n'existe pas");

        // Then
        Check.That(note).IsNull();
    }

    [TestCase("Do", "Ré", 2)]
    [TestCase("Ré", "Do", 10)]
    [TestCase("Do", "Do#", 1)]
    [TestCase("Do#", "Do", 11)]
    [TestCase("Do", "Si", 11)]
    [TestCase("Do#", "Réb", 0)]
    [TestCase("Do", "Do", 0)]
    public void Quand_Je_Cherche_La_Distance_Entre_2_Notes_Qui_Existent_J_Obtiens_La_Distance_Attendue(string nomNoteDeDepart, string nomNoteDArrivee, int distanceAttendue)
    {
        // When
        int? distance = ServiceNotes.Distance(nomNoteDeDepart, nomNoteDArrivee);

        // Then
        Check.That(distance).IsEqualTo(distanceAttendue);
    }

    [TestCase("Un note qui n'existe pas", "Ré")]
    [TestCase("Ré", "Une note qui n'existe pas")]
    public void Quand_Je_Cherche_La_Distance_Entre_1_Note_Qui_Existe_Et_Une_Qui_N_Existe_Pas_J_Obtiens_Null(string nomNoteDeDepart, string nomNoteDArrivee)
    {
        // When
        int? distance = ServiceNotes.Distance(nomNoteDeDepart, nomNoteDArrivee);

        // Then
        Check.That(distance).IsNull();
    }

    [TestCase("Do", 0, "Do")]
    [TestCase("Si", 1, "Do")]
    [TestCase("Do", 11, "Si")]
    [TestCase("Fa", -1, "Mi")]
    public void Quand_Je_Cherche_Une_Note_A_partir_D_Une_Autre_Note_Et_D_Une_Distance_J_Obtiens_La_Note_Attendue(string nomNoteDeDepart, int distance, string nomNoteAttendue) 
    {
        // When
        var note = ServiceNotes.Chercher(nomNoteDeDepart, distance);

        // Then
        Check.That(note?.Nom).IsEqualTo(nomNoteAttendue);
    }

}
