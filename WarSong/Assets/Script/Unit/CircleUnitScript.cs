using UnityEngine;
using System.Collections;

public class CircleUnitScript : UnitScript {

    void Start()
    {
        setMaxHP(100);
        setCurrentHP(100);
        setArrange(10);
        setDamage(3);
        setMoveSpeed(5);
    }

    void Update()
    {
        Move();
    }

    public override void Move()
    {
        if (playerNumber == 1 && getCheckCanMove())
        {
            print("move");
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + getMoveSpeed(),
                gameObject.transform.localPosition.y, 0);
        }
    }

    public override void Initialize()
    {
        base.Initialize();

    }

    public CircleUnitScript(int maxHP, int arrange, int damage, int moveSpeed)
        : base(maxHP, arrange, damage, moveSpeed)
    {

    }
}