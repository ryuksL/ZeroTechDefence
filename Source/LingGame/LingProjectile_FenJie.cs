using Verse;

namespace LingGame;

public class LingProjectile_FenJie : Projectile_Explosive
{
    protected override void Explode()
    {
        var map = Map;
        var position = Position;
        var explosionRadius = def.projectile.explosionRadius;
        var damageDef = def.projectile.damageDef;
        var instigator = launcher;
        var damageAmount = DamageAmount;
        var weapon = equipmentDef;
        var thingDef = def;
        var thing = intendedTarget.Thing;
        var postExplosionSpawnThingDef = def.projectile.postExplosionSpawnThingDef;
        var postExplosionSpawnChance = def.projectile.postExplosionSpawnChance;
        var postExplosionSpawnThingCount = def.projectile.postExplosionSpawnThingCount;
        var preExplosionSpawnThingDef = def.projectile.preExplosionSpawnThingDef;
        GenExplosion.DoExplosion(position, map, explosionRadius, damageDef, instigator, damageAmount, -1f, null,
            weapon, thingDef, thing, postExplosionSpawnThingDef, postExplosionSpawnChance,
            postExplosionSpawnThingCount, def.projectile.postExplosionGasType,
            def.projectile.applyDamageToExplosionCellsNeighbors,
            preExplosionSpawnThingDef, def.projectile.preExplosionSpawnChance,
            def.projectile.preExplosionSpawnThingCount, def.projectile.explosionChanceToStartFire,
            def.projectile.explosionDamageFalloff);
        var cellRect = CellRect.CenteredOn(Position, 3);
        cellRect.ClipInsideMap(map);
        for (var i = 0; i < 5; i++)
        {
            var randomCell = cellRect.RandomCell;
            FireExplosion(randomCell, map, thingDef.projectile.explosionRadius / 2f);
        }

        Destroy();
    }

    protected void FireExplosion(IntVec3 pos, Map map, float radius)
    {
        var damageDef = def.projectile.damageDef;
        var instigator = launcher;
        var damageAmount = DamageAmount;
        var weapon = equipmentDef;
        var projectile = def;
        var thing = intendedTarget.Thing;
        var postExplosionSpawnThingDef = def.projectile.postExplosionSpawnThingDef;
        var postExplosionSpawnChance = def.projectile.postExplosionSpawnChance;
        var postExplosionSpawnThingCount = def.projectile.postExplosionSpawnThingCount;
        var preExplosionSpawnThingDef = def.projectile.preExplosionSpawnThingDef;
        GenExplosion.DoExplosion(pos, map, radius, damageDef, instigator, damageAmount, -1f, null, weapon,
            projectile, thing, postExplosionSpawnThingDef, postExplosionSpawnChance, postExplosionSpawnThingCount,
            def.projectile.postExplosionGasType, def.projectile.applyDamageToExplosionCellsNeighbors,
            preExplosionSpawnThingDef,
            def.projectile.preExplosionSpawnChance, def.projectile.preExplosionSpawnThingCount,
            def.projectile.explosionChanceToStartFire, def.projectile.explosionDamageFalloff);
    }
}