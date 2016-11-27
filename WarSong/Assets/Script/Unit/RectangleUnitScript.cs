using UnityEngine;
using System.Collections;

/// <summary>
/// 근접 탱커 유닛
/// </summary>
public class RectangleUnitScript : UnitScript {

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
        setUnitType(UnitType.Rectangle);
    }

    public RectangleUnitScript(int maxHP, int arrange, int damage, int moveSpeed)
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
