using UnityEngine;
using System.Collections;

public class UnitScript : MonoBehaviour {
    private int playerNumber;
    private int currentHP;
    private int maxHP;
    private int arrange;
    private int damage;
    private int moveSpeed;
    //private bool checkCanMove = false;

    //public void setCheckCanMove(bool checkCanMove) { this.checkCanMove = checkCanMove; }

    public UnitScript(int maxHP, int arrange, int damage, int moveSpeed)
    {
        this.maxHP = maxHP;
        currentHP = maxHP;
        this.arrange = arrange;
        this.damage = damage;
        this.moveSpeed = moveSpeed;
    }

    public virtual void Attack()
    {
        print("Attack!!");
    }

    public virtual void Move()
    {
        if(playerNumber == 1)
        {
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + moveSpeed,
                gameObject.transform.localPosition.y, 0);
        }
    }
}