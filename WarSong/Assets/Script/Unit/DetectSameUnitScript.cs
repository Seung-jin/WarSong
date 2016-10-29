using UnityEngine;
using System.Collections;

public class DetectSameUnitScript : MonoBehaviour {
    public UnitScript unitScript;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Unit")
        {
            UnitScript triggerUnit = other.GetComponent<UnitScript>();

            if(triggerUnit.playerNumber == unitScript.playerNumber &&
                triggerUnit.getUnitType() == unitScript.getUnitType() &&
                other.gameObject != unitScript.gameObject)
            {
                print("enter same unit");
                unitScript.setCheckCanMove(false);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Unit")
        {
            UnitScript triggerUnit = other.GetComponent<UnitScript>();

            if (triggerUnit.playerNumber == unitScript.playerNumber &&
                triggerUnit.getUnitType() == unitScript.getUnitType() &&
                other.gameObject != unitScript.gameObject)
            {
                print("stay same unit");
                unitScript.setCheckCanMove(false);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Unit")
        {
            UnitScript triggerUnit = other.GetComponent<UnitScript>();

            if (triggerUnit.playerNumber == unitScript.playerNumber &&
                triggerUnit.getUnitType() == unitScript.getUnitType() &&
                other.gameObject != unitScript.gameObject)
            {
                print("exit same unit");
                unitScript.setCheckCanMove(true);
            }
        }

    }
}
