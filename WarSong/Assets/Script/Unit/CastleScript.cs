using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CastleScript : MonoBehaviour {

    private const float MaxCastleHP = 100;
    private float currentCastleHP = 100;
    public int playerNumber;
    public Text gameEndText;

    public Image hpGuage;

    public void setCurrentCastleHP(float currentCastleHP) { this.currentCastleHP = currentCastleHP; }

    public float getCurrentCastleHP() { return currentCastleHP; }
    public float getMaxCastleHP() { return MaxCastleHP; }

    void Update()
    {
        hpGuage.fillAmount = currentCastleHP / MaxCastleHP;

        if(currentCastleHP <= 0)
        {
            if (playerNumber == 1)
                gameEndText.text = "Game End!!!\nPlayer2 Win!!!";
            else
                gameEndText.text = "Game End!!!\nPlayer1 Win!!!";

            gameEndText.gameObject.SetActive(true);
        }
    }
}