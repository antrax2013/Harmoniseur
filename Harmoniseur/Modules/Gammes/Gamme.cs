using Solfege.Sdk.Modules.Intervalles;
using Solfege.Sdk.Modules.Notes;

namespace Solfege.Sdk.Modules.Gammes;

public record Gamme(Note Tonique, List<Intervalle> Intervalles);
