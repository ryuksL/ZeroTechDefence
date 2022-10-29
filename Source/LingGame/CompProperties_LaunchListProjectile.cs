using System.Collections.Generic;
using Verse;

namespace LingGame;

public class CompProperties_LaunchListProjectile : CompProperties
{
    public List<ThingDef> ProjectileDef;

    public CompProperties_LaunchListProjectile()
    {
        compClass = typeof(Comp_LaunchListProjectile);
    }
}