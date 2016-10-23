using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CastleScript : MonoBehaviour {

    private const float MaxCastleHP = 1000;
    private float currentCastleHP;
    public int playerNumber;

    public Image hpGuage;

    public void setCurrentCastleHP(float currentCastleHP) { this.currentCastleHP = currentCastleHP; }

    public float getCurrentCastleHP() { return currentCastleHP; }

    void Start()
    {
        currentCastleHP = MaxCastleHP;
    }
}