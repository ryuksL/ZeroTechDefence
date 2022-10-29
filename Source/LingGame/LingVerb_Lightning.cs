using RimWorld;
using Verse;

namespace LingGame;

public class LingVerb_Lightning : Verb
{
    protected override bool TryCastShot()
    {
        var compPowerTrader = caster.TryGetComp<CompPowerTrader>();
        if (compPowerTrader is not { PowerOn: true })
        {
            return false;
        }

        var num = 0f;
        foreach (var batteryComp in compPowerTrader.PowerNet.batteryComps)
        {
            num += batteryComp.StoredEnergy;
            if (num >= 10f)
            {
                break;
            }
        }

        var num2 = 10f;
        if (num >= 10f)
        {
            caster.Map.weatherManager.eventHandler.AddEvent(
                new WeatherEvent_LightningStrike(caster.Map, currentTarget.Cell));
            foreach (var batteryComp2 in compPowerTrader.PowerNet.batteryComps)
            {
                if (batteryComp2.StoredEnergy >= num2)
                {
                    batteryComp2.SetStoredEnergyPct((batteryComp2.StoredEnergy - num2) /
                                                    batteryComp2.Props.storedEnergyMax);
                    break;
                }

                num2 -= batteryComp2.StoredEnergy;
                batteryComp2.SetStoredEnergyPct(0f);
            }

            return true;
        }

        MoteMaker.ThrowText(caster.DrawPos, caster.Map, "Need10WPower".Translate());
        return false;
    }
}