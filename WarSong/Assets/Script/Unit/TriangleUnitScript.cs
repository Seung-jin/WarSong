using UnityEngine;
using System.Collections;

public class TriangleUnitScript : UnitScript {

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
        setMaxHP(12);
        setCurrentHP(getMaxHP());
        setArrange(500);
        setDamage(5);
        setMoveSpeed(5);
        setUnitType(UnitType.Rectangle);
    }

    public TriangleUnitScript(int maxHP, int arrange, int damage, int moveSpeed)
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
