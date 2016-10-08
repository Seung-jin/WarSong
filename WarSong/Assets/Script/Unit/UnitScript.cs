using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UnitScript : MonoBehaviour {
    public int playerNumber;    //플레이어 번호
    private int currentHP;
    private int maxHP;
    private int arrange;
    private int damage;
    private int moveSpeed;
    private bool checkCanMove = true;

    public SpawnManager spawnManager;

    public int getPlayerNumber() { return playerNumber; }
    public int getMaxHP() { return maxHP; }
    public int getArrange() { return arrange; }
    public int getDamage() { return damage; }
    public int getMoveSpeed() { return moveSpeed; }
    public bool getCheckCanMove() { return checkCanMove; }

    public void setPlayerNumber(int playerNumber) { this.playerNumber = playerNumber; }
    public void setMaxHP(int maxHP) { this.maxHP = maxHP; }
    public void setCurrentHP(int currentHP) { this.currentHP = currentHP; }
    public void setArrange(int arrange) { this.arrange = arrange; }
    public void setDamage(int damage) { this.damage = damage; }
    public void setMoveSpeed(int moveSpeed) { this.moveSpeed = moveSpeed; }
    public void setCheckCanMove(bool checkCanMove) { this.checkCanMove = checkCanMove; }

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
        print("Move");
    }

    public virtual void Initialize()
    {
        print("Initialize");

        playerNumber = spawnManager.playerNumber;
        checkCanMove = true;
    }

    public enum unitType
    {
        Circle,
    }
}