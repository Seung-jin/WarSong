using UnityEngine;
using System.Collections;

/// <summary>
/// 원거리 유닛
/// </summary>
public class CircleUnitScript : UnitScript {

    void Update()
    {
        Move();
        base.SettingHPGuage();
    }

    public override void Move()
    {
        if (playerNumber == 1 && getCheckCanMove())
        {
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + getMoveSpeed(),
                gameObject.transform.localPosition.y, 0);
        }
    }

    public override void Initialize()
    {
        base.Initialize();
        setMaxHP(100);
        setCurrentHP(100);
        setArrange(500);
        setDamage(3);
        setMoveSpeed(5);
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

    void OnTriggerEnter2D(Collider2D other)
    {
        UnitScript colliderUnit = other.gameObject.GetComponent<UnitScript>();

        if(playerNumber == 1 && colliderUnit.getPlayerNumber() == 2)
        {
            setCheckCanMove(false);
            StartCoroutine(Attack(colliderUnit));
        }
    }

    IEnumerator Attack(UnitScript enemy)
    {
        enemy.setCurrentHP(enemy.getCurrentHP() - getDamage());
        print(enemy.getCurrentHP());

        if(enemy.getCurrentHP() > 0)
        {
            yield return new WaitForSeconds(1);
            StartCoroutine(Attack(enemy));
        }
    }
}