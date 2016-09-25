using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    private int currentCastleHP;
    private const int MaxCastleHP = 1000;

    public Image hpGuage;

    void Start()
    {
        currentCastleHP = MaxCastleHP;
    }

}
