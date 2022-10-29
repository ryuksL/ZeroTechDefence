using System.Collections.Generic;
using RimWorld;
using Verse;

namespace LingGame;

public class LingBuildingZiRanXuanZe : Building_TurretGun
{
    private readonly string FangShi0 = "StunBomb".Translate();

    private readonly string FangShi1 = "SanLei".Translate();

    private readonly string FangShi2 = "YunShi".Translate();

    private readonly string FangShi3 = "JiShuLei".Translate();

    private readonly string FangShi4 = "ZongHuo".Translate();
    public int FangShi;

    public override IEnumerable<Gizmo> GetGizmos()
    {
        foreach (var gizmo in base.GetGizmos())
        {
            yield return gizmo;
        }

        yield return new Command_Action
        {
            action = delegate
            {
                FangShi++;
                if (FangShi > 3)
                {
                    FangShi = 0;
                }
            },
            defaultLabel = "LingXCG_QieHuan".Translate(),
            defaultDesc = "ChangeAttackType".Translate(),
            icon = TexCommand.Attack
        };
    }

    public override string GetInspectString()
    {
        var inspectString = base.GetInspectString();
        return FangShi switch
        {
            0 => string.Concat(new string[]
            {
                inspectString,
                "\n",
                "LingNewAttackType".Translate() + FangShi0 + ""
            }),
            1 => string.Concat(new string[]
            {
                inspectString,
                "\n",
                "LingNewAttackType".Translate() + FangShi1 + ""
            }),
            2 => string.Concat(new string[]
            {
                inspectString,
                "\n",
                "LingNewAttackType".Translate() + FangShi2 + ""
            }),
            3 => string.Concat(new string[]
            {
                inspectString,
                "\n",
                "LingNewAttackType".Translate() + FangShi3 + ""
            }),
            4 => string.Concat(new string[]
            {
                inspectString,
                "\n",
                "LingNewAttackType".Translate() + FangShi4 + ""
            }),
            _ => string.Concat(new string[]
            {
                inspectString,
                "\n",
                "LingNewAttackType".Translate() + "unknow"
            })
        };
    }
}