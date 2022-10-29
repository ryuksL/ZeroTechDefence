using RimWorld;
using Verse;

namespace LingGame;

public class ElectronicWall : Building
{
    private float ExPower;

    public CompPowerTrader CCompPowerTrader => GetComp<CompPowerTrader>();

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref ExPower, "ExPower");
    }

    public override void PreApplyDamage(ref DamageInfo dinfo, out bool absorbed)
    {
        if (GetComp<CompPowerTrader>().PowerOn)
        {
            ExPower -= dinfo.Amount;
            CCompPowerTrader.PowerOutput = CCompPowerTrader.Props.PowerConsumption + ExPower;
            if (ExPower <= -10000f)
            {
                ExPower = -10000f;
            }

            absorbed = true;
        }
        else
        {
            base.PreApplyDamage(ref dinfo, out absorbed);
        }
    }

    public override void TickRare()
    {
        base.TickRare();
        if (GetComp<CompPowerTrader>().PowerOn)
        {
            HitPoints = MaxHitPoints;
            ExPower = (int)(ExPower * 0.9f);
        }
        else if (HitPoints > MaxHitPoints / 9)
        {
            HitPoints -= MaxHitPoints / 10;
        }
    }
}