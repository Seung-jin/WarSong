using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UnitScript : MonoBehaviour {
    public int playerNumber;    //플레이어 번호
    public float currentHP = 100;
    public float maxHP = 100;
    private int arrange;
    private int damage;
    private int moveSpeed;
    private bool checkCanMove = true;
    private UnitType unitType;

    public SpawnManager spawnManager;
    public Image hpGuage;

    public int getPlayerNumber() { return playerNumber; }
    public float getMaxHP() { return maxHP; }
    public float getCurrentHP() { return currentHP; }
    public int getArrange() { return arrange; }
    public int getDamage() { return damage; }
    public int getMoveSpeed() { return moveSpeed; }
    public bool getCheckCanMove() { return checkCanMove; }
    public UnitType getUnitType() { return unitType; }

    public void setPlayerNumber(int playerNumber) { this.playerNumber = playerNumber; }
    public void setMaxHP(float maxHP) { this.maxHP = maxHP; }
    public void setCurrentHP(float currentHP) { this.currentHP = currentHP; }
    public void setArrange(int arrange) { this.arrange = arrange; }
    public void setDamage(int damage) { this.damage = damage; }
    public void setMoveSpeed(int moveSpeed) { this.moveSpeed = moveSpeed; }
    public void setCheckCanMove(bool checkCanMove) { this.checkCanMove = checkCanMove; }
    public void setUnitType(UnitType unitType) { this.unitType = unitType; }
    
    public void SettingHPGuage()
    {
        hpGuage.fillAmount = currentHP / maxHP;
    }

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

    public enum UnitType
    {
        Circle,
    }
}