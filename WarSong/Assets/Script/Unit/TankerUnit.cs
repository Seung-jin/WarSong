using UnityEngine;
using System.Collections;

/// <summary>
/// 근접 탱커 유닛
/// </summary>
public class TankerUnit : Unit {

    void Update()
    {
        base.UnitMove();
        base.SettingHPGuage();
        base.DestroyUnit();
        if (!gameObject.GetComponent<BoxCollider2D>().isTrigger)
            setCheckCanMove(true);
    }

    public override void Initialize()
    {
        base.Initialize();
        setMaxHP(18);
        setCurrentHP(getMaxHP());
        setArrange(500);
        setDamage(2);
        setMoveSpeed(3);
        setUnitType(UnitType.Tanker);
    }

    public TankerUnit(int maxHP, int arrange, int damage, int moveSpeed)
        : base(maxHP, arrange, damage, moveSpeed)
    {
        Initialize();
    }

    public override IEnumerator Attack(Unit enemy)
    {
        return base.Attack(enemy);
    }

    public override IEnumerator CastleAttack(CastleScript enemyCastle)
    {
        return base.CastleAttack(enemyCastle);
    }
}
