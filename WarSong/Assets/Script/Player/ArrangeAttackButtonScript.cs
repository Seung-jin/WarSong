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

    void Update()
    {
        if (remainArrangeAttack <= 0)
            arrangeAttackButton.enabled = false;
        else
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
    }

    public void SettingData()
    {
        remainTime = 0;
        arrangeAttackButton.enabled = false;
        StartCoroutine(PlusRemainTime());
        remainArrangeAttack--;
        remainArrangeAttackText.text = remainArrangeAttack + "";
        StartCoroutine(FillRemainArrangeAttack());
    }

    IEnumerator PlusRemainTime()
    {
        yield return new WaitForSeconds(0.1f);

        remainTime += 0.1f;
        if (remainTime >= coolTime)
        {
            remainTime = coolTime;
            arrangeAttackButton.enabled = true;
        }
        else
        {
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
            StartCoroutine(FillRemainArrangeAttack());
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
            if (remainArrangeAttack == 0)
                StartCoroutine(FillRemainArrangeAttack());
        }
    }
}
