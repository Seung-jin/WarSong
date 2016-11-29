using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ArrangeAttackButtonScript : MonoBehaviour {

    public Image arrangeAttackButtonImage;
    public Button arrangeAttackButton;
    public Text remainArrangeAttackText;

    public float coolTime;
    public float remainTime;
    public int remainArrangeAttack;

    public GameObject lines;
    public int playerNumber;

    private const int MAX_Arrange_Attack = 2;   //광역기는 총 2개까지 저장 가능
    private bool checkDoingRemain;  //쿨타임이 돌고 있는지 체크
    private bool checkDoingFill;    //은폐 횟수를 채우고 있는지 체크

    void Update()
    {
        if (remainArrangeAttack <= 0)
            arrangeAttackButton.enabled = false;
        else if (remainArrangeAttack > 0 && !checkDoingRemain)
            arrangeAttackButton.enabled = true;

        if (remainArrangeAttack >= MAX_Arrange_Attack)
            StopCoroutine(FillRemainArrangeAttack());

        arrangeAttackButtonImage.fillAmount = (remainTime / coolTime);
    }

    void Start()
    {
        remainTime = coolTime;
        remainArrangeAttack = 0;
        remainArrangeAttackText.text = remainArrangeAttack + "";
        StartCoroutine(FillRemainArrangeAttack());
        checkDoingRemain = false;
        checkDoingFill = false;
    }

    IEnumerator PlusRemainTime()
    {
        yield return new WaitForSeconds(0.1f);

        remainTime += 0.1f;
        if (remainTime >= coolTime)
        {
            remainTime = coolTime;
            arrangeAttackButton.enabled = true;
            checkDoingRemain = false;
            StopCoroutine(PlusRemainTime());
        }
        else
        {
            arrangeAttackButton.enabled = false;
            checkDoingRemain = true;
            StartCoroutine(PlusRemainTime());
        }
    }

    //광역기는 20초마다 1개씩 충전
    IEnumerator FillRemainArrangeAttack()
    {
        yield return new WaitForSeconds(20);

        if (remainArrangeAttack < MAX_Arrange_Attack)
            remainArrangeAttack++;
        remainArrangeAttackText.text = remainArrangeAttack + "";
        if (remainArrangeAttack < MAX_Arrange_Attack)
        {
            StartCoroutine(FillRemainArrangeAttack());
            checkDoingFill = true;
        }
        else
            checkDoingFill = false;
    }

    public void AttackAllEnemy()
    {
        if(remainArrangeAttack > 0)
        {
            for (int i = 0; i < lines.transform.childCount; i++)
            {
                GameObject line = lines.transform.GetChild(i).gameObject;
                for (int j = 1; j < line.transform.childCount; j++)
                {
                    Unit unit = line.transform.GetChild(j).GetComponent<Unit>();
                    if (unit.playerNumber != playerNumber)
                    {
                        unit.setCurrentHP(unit.getCurrentHP() - 5);
                    }
                }
            }
            remainArrangeAttack--;
            remainArrangeAttackText.text = remainArrangeAttack + "";
            if (remainArrangeAttack == 0 && !checkDoingFill)
                StartCoroutine(FillRemainArrangeAttack());

            remainTime = 0;
            arrangeAttackButton.enabled = false;
            if (!checkDoingRemain)
                StartCoroutine(PlusRemainTime());
        }
    }
}
