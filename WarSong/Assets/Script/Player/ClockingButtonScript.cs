using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClockingButtonScript : MonoBehaviour
{
    public Image clockingButtonImage;
    public Button clockingButton;
    public Text remainClockingText;

    public float coolTime;
    public float remainTime;
    public int remainClocking;

    private const int MAX_CLOCKING = 3;

    void Update()
    {
        if (remainClocking <= 0)
            clockingButton.enabled = false;
        else
            clockingButton.enabled = true;

        if (remainClocking >= MAX_CLOCKING)
            StopCoroutine(FillRemainClocking());

        clockingButtonImage.fillAmount = (remainTime / coolTime);
    }

    void Start()
    {
        remainTime = coolTime;
        remainClocking = 0;
        remainClockingText.text = remainClocking + "";
        StartCoroutine(FillRemainClocking());
    }

    public void SettingData()
    {
        remainTime = 0;
        clockingButton.enabled = false;
        StartCoroutine(PlusRemainTime());
        remainClocking--;
        remainClockingText.text = remainClocking + "";
        StartCoroutine(FillRemainClocking());
    }

    IEnumerator PlusRemainTime()
    {
        yield return new WaitForSeconds(0.1f);

        remainTime += 0.1f;
        if (remainTime >= coolTime)
        {
            remainTime = coolTime;
            clockingButton.enabled = true;
        }
        else
        {
            StartCoroutine(PlusRemainTime());
        }
    }

    //은폐는 총 3번까지 저장 가능
    IEnumerator FillRemainClocking()
    {
        yield return new WaitForSeconds(5);

        if(remainClocking < MAX_CLOCKING)
            remainClocking++;
        remainClockingText.text = remainClocking + "";
        if (remainClocking < MAX_CLOCKING)
            StartCoroutine(FillRemainClocking());
    }
}
