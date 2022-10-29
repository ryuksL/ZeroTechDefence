using RimWorld;
using Verse;

namespace LingGame;

public class LingProjectile_TryFire : Projectile_Explosive
{
    public override void Tick()
    {
        if (!Position.InHorDistOf(launcher.Position, 1f))
        {
            GenSpawn.Spawn(ThingDefOf.Filth_Fuel, Position, Map);
            FireUtility.TryStartFireIn(Position, Map, 1f);
        }

        base.Tick();
    }
}