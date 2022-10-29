using Verse;

namespace LingGame;

public class LingHediff_FuShiZhuangBei : HediffWithComps
{
    public override void PostTick()
    {
        base.PostTick();
        pawn.apparel.DropAll(pawn.Position);
        pawn.equipment.DropAllEquipment(pawn.Position);
        pawn.health.RemoveHediff(this);
    }
}