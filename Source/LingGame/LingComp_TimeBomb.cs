using Verse;

namespace LingGame
{
    public class LingComp_TimeBomb : ThingComp
    {
        public LingCompProerties_TimeBomb Props => (LingCompProerties_TimeBomb)props;

        public override void CompTick()
        {
            base.CompTick();
            parent.HitPoints--;
            if (parent.HitPoints > 0)
            {
                return;
            }

            GenExplosion.DoExplosion(parent.Position, parent.Map, 1.9f, Props.DamageDef, parent, 10);
            parent.Destroy();
        }
    }
}