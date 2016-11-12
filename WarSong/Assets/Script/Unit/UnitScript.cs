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
    
    void Start()
    {
        StartCoroutine(DestroyUnit());
    }

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

    //충돌되는 물체 감지
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "UnitCenter") //적군일 때
        {
            UnitScript colliderUnit = other.gameObject.GetComponent<UnitCenterScript>().unitScript;

            if (playerNumber == 1 && colliderUnit.getPlayerNumber() == 2)
            {
                setCheckCanMove(false);
                StartCoroutine(Attack(colliderUnit));
            }
            else if (playerNumber == 2 && colliderUnit.getPlayerNumber() == 1)
            {
                setCheckCanMove(false);
                StartCoroutine(Attack(colliderUnit));
            }
        }
        else if(other.tag == "Castle")  //상대 성일 때
        {
            CastleScript castle = other.gameObject.GetComponent<CastleScript>();

            if(castle.playerNumber != playerNumber)
            {
                setCheckCanMove(false);
                StartCoroutine(CastleAttack(castle));
            }
        }
    }

    //유닛이 계속해서 적과 만난 상태일 때 움직이지 못하도록 함
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Unit")
        {
            UnitScript colliderUnit = other.gameObject.GetComponent<UnitScript>();
            if (playerNumber == 1 && colliderUnit.getPlayerNumber() == 2 &&
                playerNumber == 2 && colliderUnit.getPlayerNumber() == 1)
                setCheckCanMove(false);
        }
        else if (other.tag == "Castle")
        {
            CastleScript colliderCastle = other.gameObject.GetComponent<CastleScript>();

            if (colliderCastle.playerNumber != playerNumber)
            {
                setCheckCanMove(false);
            }
        }
    }

    //유닛 움직임
    public void UnitMove()
    {
        if (playerNumber == 1 && getCheckCanMove())
        {
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + getMoveSpeed(),
                gameObject.transform.localPosition.y, 0);
        }
        else if (playerNumber == 2 && getCheckCanMove())
        {
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x - getMoveSpeed(),
                gameObject.transform.localPosition.y, 0);
        }
    }

    //적의 유닛을 공격
    public virtual IEnumerator Attack(UnitScript enemy)
    {
        yield return new WaitForSeconds(1);
        enemy.setCurrentHP(enemy.getCurrentHP() - getDamage());

        if (enemy.getCurrentHP() > 0)
            StartCoroutine(Attack(enemy));
        else
            checkCanMove = true;
    }

    //적의 성을 공격
    public virtual IEnumerator CastleAttack(CastleScript enemyCastle)
    {
        yield return new WaitForSeconds(1);
        enemyCastle.setCurrentCastleHP(enemyCastle.getCurrentCastleHP() - getDamage());

        if (enemyCastle.getCurrentCastleHP() > 0)
            StartCoroutine(CastleAttack(enemyCastle));
        else
            checkCanMove = false;
    }

    public virtual void Initialize()
    {
        print("Initialize");

        playerNumber = spawnManager.playerNumber;
        checkCanMove = true;
    }

    public IEnumerator DestroyUnit()
    {
        yield return new WaitForSeconds(0.1f);
        if (currentHP < 0)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
            StartCoroutine(DestroyUnit());
    }

    public enum UnitType
    {
        Circle,
    }

}