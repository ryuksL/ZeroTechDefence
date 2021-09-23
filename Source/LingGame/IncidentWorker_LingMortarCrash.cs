using RimWorld;
using Verse;

namespace LingGame
{
    public class IncidentWorker_LingMortarCrash : IncidentWorker
    {
        protected override bool CanFireNowSub(IncidentParms parms)
        {
            if (ResearchProjectDef.Named("ZeroTechBase")?.IsFinished == true)
            {
                return true;
            }

            return false;
        }

        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            var map = (Map)parms.target;
            var pos = DropCellFinder.RandomDropSpot(map);
            string text = "LetterLabelIncidentWorker_LingMortarCrash".Translate();
            string text2 = "LetterTextIncidentWorker_LingMortarCrash".Translate();
            if (Rand.Chance(0.5f))
            {
                var thing = ThingMaker.MakeThing(ZeroTechDefenceDefOf.LingTurret_CrazyMortar);
                SkyfallerMaker.SpawnSkyfaller(ThingDefOf.MeteoriteIncoming, thing, pos, map);
                Find.LetterStack.ReceiveLetter(text, text2, LetterDefOf.NeutralEvent, thing);
            }
            else
            {
                var thing2 = ThingMaker.MakeThing(ZeroTechDefenceDefOf.LingTurret_CrazyMortar);
                SkyfallerMaker.SpawnSkyfaller(ThingDefOf.MeteoriteIncoming, thing2, pos, map);
                Find.LetterStack.ReceiveLetter(text, text2, LetterDefOf.NeutralEvent, thing2);
            }

            return true;
        }
    }
}