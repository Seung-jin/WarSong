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
    }

    public override void Initialize()
    {
        base.Initialize();
        setMaxHP(10);
        setCurrentHP(getMaxHP());
        setArrange(500);
        setDamage(3);
        setMoveSpeed(3);
        setUnitType(UnitType.Circle);

        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(getArrange(), 150);
    }

    public CircleUnitScript(int maxHP, int arrange, int damage, int moveSpeed)
        : base(maxHP, arrange, damage, moveSpeed)
    {
        setMaxHP(100);
        setCurrentHP(100);
        setArrange(500);
        setDamage(3);
        setMoveSpeed(5);
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