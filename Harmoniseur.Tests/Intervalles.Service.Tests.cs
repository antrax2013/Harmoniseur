using NFluent;
using Solfege.Sdk.Modules.Intervalles;

namespace Solfege.Sdk.Test;

internal class ServiceIntervallesTests
{
    [TestCase("Unisson", 0)]
    [TestCase("Seconde", 2)]
    [TestCase("Tierce", 4)]
    [TestCase("Quarte", 5)]
    [TestCase("Quinte", 7)]
    [TestCase("sixte", 9)]
    [TestCase("Sixte", 9)]
    [TestCase("Septième", 11)]
    public void Quand_Je_Cherche_Un_Intervalle_Qui_Existe_J_Obtiens_L_Intervalle_Attendu(string nomIntervalle, int distanceAttendue)
    {
        // When
        Intervalle? intervalle = ServiceIntervalles.Chercher(nomIntervalle);

        // Then
        Check.That(intervalle).IsNotNull();
        Check.That(intervalle?.Nom).IsEqualIgnoringCase(nomIntervalle);
        Check.That(intervalle?.Distance).Equals(distanceAttendue);
    }

    [TestCase("Octave", "Unisson")]
    [TestCase("Prime", "Unisson")]
    [TestCase("prime", "Unisson")]
    [TestCase("Octave Juste", "Unisson")]
    public void Quand_Je_Cherche_Un_Intervalle_Qui_Existe_Par_Son_Alias_J_Obtiens_L_Intervalle_Attendu(string nomIntervalle, string nomIntevalleAttendu)
    {
        // When
        Intervalle? intervalle = ServiceIntervalles.Chercher(nomIntervalle);

        // Then
        Check.That(intervalle).IsNotNull();
        Check.That(intervalle?.Nom).IsEqualIgnoringCase(nomIntevalleAttendu);
    }

    [Test]
    public void Quand_Je_Cherche_Un_Intervalle_Qui_N_Existe_Pas_J_Obtiens_Null()
    {
        // When
        Intervalle? intervalle = ServiceIntervalles.Chercher("Un intervalle qui n'existe pas");

        // Then
        Check.That(intervalle).IsNull();
    }
}
