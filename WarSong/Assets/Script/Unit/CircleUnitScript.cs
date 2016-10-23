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
        setMoveSpeed(5);
        setUnitType(UnitType.Circle);

        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(getArrange(), 150);
    }

    //public override void UnitMove()
    //{
    //    base.UnitMove();
    //}

    public CircleUnitScript(int maxHP, int arrange, int damage, int moveSpeed)
        : base(maxHP, arrange, damage, moveSpeed)
    {
        setMaxHP(100);
        setCurrentHP(100);
        setArrange(500);
        setDamage(3);
        setMoveSpeed(5);
    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    UnitScript colliderUnit = other.gameObject.GetComponent<UnitScript>();

    //    if(playerNumber == 1 && colliderUnit.getPlayerNumber() == 2)
    //    {
    //        setCheckCanMove(false);
    //        StartCoroutine(Attack(colliderUnit));
    //    }
    //    else if(playerNumber == 2 && colliderUnit.getPlayerNumber() == 1)
    //    {
    //        setCheckCanMove(false);
    //        StartCoroutine(Attack(colliderUnit));
    //    }
    //}

    public override IEnumerator Attack(UnitScript enemy)
    {
        return base.Attack(enemy);
    }
}