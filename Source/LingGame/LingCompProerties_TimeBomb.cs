using Verse;

namespace LingGame
{
    public class LingCompProerties_TimeBomb : CompProperties
    {
        public DamageDef DamageDef;

        public LingCompProerties_TimeBomb()
        {
            compClass = typeof(LingComp_TimeBomb);
        }
    }
}