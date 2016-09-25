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
        print(getCheckCanMove() + "   " + getPlayerNumber());
    }

    public CircleUnitScript(int maxHP, int arrange, int damage, int moveSpeed)
        : base(maxHP, arrange, damage, moveSpeed)
    {

    }
}