using UnityEngine;
using System.Collections;

public class UnitScript : MonoBehaviour {
    private int hp;
    private int arrange;
    private int damage;

    public virtual void Attack()
    {
        print("Attack!!");
    }
}