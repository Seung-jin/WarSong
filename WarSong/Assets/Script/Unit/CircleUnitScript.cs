using UnityEngine;
using System.Collections;

/// <summary>
/// 원거리 유닛
/// </summary>
public class CircleUnitScript : UnitScript {

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
        setMaxHP(10);
        setCurrentHP(getMaxHP());
        setArrange(500);
        setDamage(3);
        setMoveSpeed(2.5f);
        setUnitType(UnitType.Circle);
    }

    public CircleUnitScript(int maxHP, int arrange, int damage, int moveSpeed)
        : base(maxHP, arrange, damage, moveSpeed)
    {
        Initialize();
    }

    public override IEnumerator Attack(UnitScript enemy)
    {
        return base.Attack(enemy);
    }

    public override IEnumerator CastleAttack(CastleScript enemyCastle)
    {
        return base.CastleAttack(enemyCastle);
    }
}