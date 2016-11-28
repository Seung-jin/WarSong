using UnityEngine;
using System.Collections;

public class UnitCenter : MonoBehaviour {
    public Unit unitScript;
    public Unit triggerUnit = null;

    void Update()
    {
        if (!gameObject.GetComponent<BoxCollider2D>().isTrigger)
            unitScript.setCheckCanMove(true);        
    }

    //트리거에 같은 아군 유닛이 들어오면 멈춤
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "UnitCenter")
        {
            Unit newUnit = other.transform.parent.GetComponent<Unit>();

            if (unitScript.playerNumber == 1 &&
                unitScript.playerNumber == newUnit.playerNumber &&
                unitScript.getUnitType() == newUnit.getUnitType() &&
                !unitScript.gameObject.Equals(newUnit.gameObject) &&
                newUnit.gameObject.transform.localPosition.x < unitScript.gameObject.transform.localPosition.x + 10)
            {
                triggerUnit = newUnit;
                triggerUnit.setCheckCanMove(false);
            }
            else if (unitScript.playerNumber == 2 &&
                unitScript.playerNumber == newUnit.playerNumber &&
                unitScript.getUnitType() == newUnit.getUnitType() &&
                unitScript.gameObject != newUnit.gameObject &&
                newUnit.gameObject.transform.localPosition.x > unitScript.gameObject.transform.localPosition.x - 10)
            {
                triggerUnit = newUnit;
                triggerUnit.setCheckCanMove(false);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "UnitCenter")
        {
            Unit newUnit = other.transform.parent.GetComponent<Unit>();

            if (unitScript.playerNumber == 1 &&
                unitScript.playerNumber == newUnit.playerNumber &&
                unitScript.getUnitType() == newUnit.getUnitType() &&
                !unitScript.gameObject.Equals(newUnit.gameObject) &&
                newUnit.gameObject.transform.localPosition.x < unitScript.gameObject.transform.localPosition.x + 10)
            {
                triggerUnit = newUnit;
                triggerUnit.setCheckCanMove(false);
            }
            else if (unitScript.playerNumber == 2 &&
                unitScript.playerNumber == newUnit.playerNumber &&
                unitScript.getUnitType() == newUnit.getUnitType() &&
                unitScript.gameObject != newUnit.gameObject &&
                newUnit.gameObject.transform.localPosition.x > unitScript.gameObject.transform.localPosition.x - 10)
            {
                triggerUnit = newUnit;
                triggerUnit.setCheckCanMove(false);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "UnitCenter" &&
            other.transform.gameObject.Equals(triggerUnit.gameObject))
        {
            print("exit");
            triggerUnit = other.transform.parent.GetComponent<Unit>();

            triggerUnit.setCheckCanMove(true);
        }
    }
}