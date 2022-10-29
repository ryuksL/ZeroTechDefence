using System.Linq;
using RimWorld;
using Verse;

namespace LingGame;

[StaticConstructorOnStartup]
public class LingPoisonGas : Gas
{
    public HediffDef hediff;

    public override void PostMake()
    {
        base.PostMake();
        hediff = DefDatabase<HediffDef>.AllDefs.ToList().Find(x => x.defName == def.defName.Substring(8));
    }

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref hediff, "hediff");
    }

    public override void Tick()
    {
        var position = Position;
        if (position.InBounds(Map))
        {
            var thingList = position.GetThingList(Map);
            foreach (var item in thingList)
            {
                Pawn pawn;
                if ((pawn = item as Pawn) != null && !pawn.Downed && !pawn.Dead &&
                    pawn.GetStatValue(StatDefOf.ToxicResistance) == 0f)
                {
                    HealthUtility.AdjustSeverity(pawn, hediff, 0.001f);
                }
            }
        }

        base.Tick();
    }
}