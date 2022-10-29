using RimWorld;
using Verse;

namespace LingGame;

public class LingHediff_FuShiRouTi : HediffWithComps
{
    public int ttick;

    public override void Tick()
    {
        base.Tick();
        ttick++;
        if (ttick < 10)
        {
            return;
        }

        if (!pawn.InBed() && !pawn.Downed)
        {
            pawn.TakeDamage(new DamageInfo(DamageDefOf.Burn, 2f, 20f));
        }

        ttick = 0;
    }
}