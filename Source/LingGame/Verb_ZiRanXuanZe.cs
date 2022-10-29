using RimWorld;
using Verse;

namespace LingGame;

public class Verb_ZiRanXuanZe : Verb
{
    private int FangShi => ((LingBuildingZiRanXuanZe)caster).FangShi;

    protected override bool TryCastShot()
    {
        if (FangShi == 0)
        {
            GenExplosion.DoExplosion(currentTarget.Cell, caster.Map, 5f, DamageDefOf.EMP, caster, 6000, 2f);
            GenExplosion.DoExplosion(currentTarget.Cell, caster.Map, 5f, DamageDefOf.Stun, caster, 60, 2f);
            return true;
        }

        if (FangShi == 1)
        {
            var cellRect = new CellRect(currentTarget.Cell.x - 6, currentTarget.Cell.z - 6, 13, 13);
            for (var i = 0; i < 10; i++)
            {
                caster.Map.weatherManager.eventHandler.AddEvent(
                    new WeatherEvent_LightningStrike(caster.Map, cellRect.RandomCell));
            }

            return true;
        }

        if (FangShi == 2)
        {
            var cellRect2 = new CellRect(currentTarget.Cell.x - 4, currentTarget.Cell.z - 4, 9, 9);
            for (var j = 0; j < 7; j++)
            {
                SkyfallerMaker.SpawnSkyfaller(ThingDefOf.MeteoriteIncoming, cellRect2.RandomCell, caster.Map);
            }

            return true;
        }

        if (FangShi == 3)
        {
            caster.Map.weatherManager.eventHandler.AddEvent(
                new WeatherEvent_LightningStrike(caster.Map, currentTarget.Cell));
            GenExplosion.DoExplosion(currentTarget.Cell, caster.Map, 1f, DamageDefOf.Burn, caster, 100);
            return true;
        }

        if (FangShi != 4)
        {
            return true;
        }

        foreach (var cell in new CellRect(currentTarget.Cell.x - 3, currentTarget.Cell.z - 3, 7, 7).Cells)
        {
            GenSpawn.Spawn(ThingDefOf.Filth_Fuel, cell, caster.Map);
            FireUtility.TryStartFireIn(cell, caster.Map, 2f);
        }

        return true;
    }
}