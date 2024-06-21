namespace Solfege.Sdk.Modules.Notes;

public class Note
{
    public readonly string Nom;
    private readonly string? _nomRenverse;
    public string NomRenverse
    {
        get
        {
            return _nomRenverse ?? Nom;
        }
    }

#pragma warning disable IDE0290 // Utiliser le constructeur principal
    public Note(string nom, string? nomRenverse = null)
#pragma warning restore IDE0290 // Utiliser le constructeur principal
    {
        Nom = nom;
        _nomRenverse = nomRenverse;
    }
}
