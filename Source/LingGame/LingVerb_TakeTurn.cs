using RimWorld;
using Verse;

namespace LingGame
{
    public class LingVerb_TakeTurn : Verb
    {
        protected override bool TryCastShot()
        {
            currentTarget.Thing.TakeDamage(new DamageInfo(DamageDefOf.Stun, 3f, 200f));
            FleckMaker.ThrowFireGlow(currentTarget.CenterVector3, currentTarget.Thing.Map, 0.5f);
            return true;
        }
    }
}