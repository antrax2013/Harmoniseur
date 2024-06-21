using System.Collections.Immutable;

namespace Solfege.Sdk.Modules.Intervalles;

public static class ServiceIntervalles
{
    private static readonly ImmutableArray<Intervalle> _intervalle = [
        new("Unisson", 0, ["Prime","Octave", "Unisson Juste", "Octave Juste", "Tonique"]),
        new("Seconde", 2, ["Seconde Majeure"]),
        new("Tierce", 4, ["Tierce Majeure"]),
        new("Quarte", 5, ["Quarte Majeure", "Quarte Juste"]),
        new("Quinte", 7, ["Quinte Majeure", "Quinte Juste"]),
        new("Sixte", 9, ["Sixte Majeure", "Sixième", "Sixième Majeure"]),
        new("Septième", 11, ["Septième Majeure"]),
    ];

    public static Intervalle? Chercher(string nomIntervalle)
    {
        return _intervalle.FirstOrDefault(i => 
            i.Nom.Equals(nomIntervalle, StringComparison.CurrentCultureIgnoreCase)
            || i.Alias!= null && i.Alias.ToList().Exists(a => a.Equals(nomIntervalle, StringComparison.CurrentCultureIgnoreCase))
            );
    }
}