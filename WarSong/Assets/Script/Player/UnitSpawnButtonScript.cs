using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UnitSpawnButtonScript : MonoBehaviour {
    public Image unitSpawnButtonImage;
    public Button unitSpawnButton;
    public float coolTime;
    public float remainTime;

    void Start()
    {
        remainTime = coolTime;
    }

    void Update()
    {
        unitSpawnButtonImage.fillAmount = (remainTime / coolTime);
    }

    public void SettingData()
    {
        remainTime = 0;
        unitSpawnButton.enabled = false;
        StartCoroutine(PlusRemainTime());
    }

    IEnumerator PlusRemainTime()
    {
        yield return new WaitForSeconds(0.1f);

        remainTime += 0.1f;
        if(remainTime >= coolTime)
        {
            remainTime = coolTime;
            unitSpawnButton.enabled = true;
        }
        else
        {
            StartCoroutine(PlusRemainTime());
        }
    }
}
