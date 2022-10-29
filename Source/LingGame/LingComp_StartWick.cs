using System.Collections.Generic;
using RimWorld;
using Verse;

namespace LingGame;

public class LingComp_StartWick : ThingComp
{
    public LingCompProerties_StartWick Props => (LingCompProerties_StartWick)props;

    public override IEnumerable<Gizmo> CompGetGizmosExtra()
    {
        yield return new Command_Action
        {
            defaultLabel = "QiBaoDaoJuL".Translate(),
            defaultDesc = "QiBaoDaoJuD".Translate(),
            icon = TexCommand.RemoveRoutePlannerWaypoint,
            action = delegate { parent.GetComp<CompExplosive>().StartWick(); }
        };
    }
}