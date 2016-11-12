using UnityEngine;
using System.Collections;

public class UnitCenterScript : MonoBehaviour {
    public UnitScript unitScript;

    //트리거에 같은 아군 유닛이 들어오면 멈춤
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Unit")
        {
            UnitScript triggerUnit = other.GetComponent<UnitScript>();

            if(unitScript.playerNumber == 1 &&
                unitScript.playerNumber == triggerUnit.playerNumber &&
                unitScript.getUnitType() == triggerUnit.getUnitType() &&
                unitScript.gameObject != triggerUnit.gameObject &&
                triggerUnit.gameObject.transform.localPosition.x > unitScript.gameObject.transform.localPosition.x + 10)
            {
                unitScript.setCheckCanMove(false);
            }
            else if(unitScript.playerNumber == 2 &&
                unitScript.playerNumber == triggerUnit.playerNumber &&
                unitScript.getUnitType() == triggerUnit.getUnitType() &&
                unitScript.gameObject != triggerUnit.gameObject &&
                triggerUnit.gameObject.transform.localPosition.x < unitScript.gameObject.transform.localPosition.x -10)
            {
                unitScript.setCheckCanMove(false);
            }
        }
    }

    //유닛이 앞으로 이동하여 트리거를 벗어나면 본체도 움직임
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Unit")
        {
            UnitScript triggerUnit = other.GetComponent<UnitScript>();

            if (unitScript.playerNumber == triggerUnit.playerNumber &&
                unitScript.getUnitType() == triggerUnit.getUnitType() &&
                unitScript.gameObject != triggerUnit.gameObject)
            {
                unitScript.setCheckCanMove(true);
            }
        }
    }
}
