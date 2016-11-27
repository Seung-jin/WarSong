using UnityEngine;
using System.Collections;

public class UnitCenterScript : MonoBehaviour {
    public UnitScript unitScript;
    public UnitScript triggerUnit = null;
    //public RaycastHit2D hit;

    //void Update()
    //{
    //    Debug.DrawLine(transform.localPosition, new Vector3(transform.localPosition.x + 10f, transform.localPosition.y, 0));
    //    hit = Physics2D.Raycast(transform.localPosition, Vector2.right, 100f);
    //    if(hit.collider != null)
    //    {
    //        if(hit.collider.tag == "Unit")
    //        {
    //            unitScript.setCheckCanMove(false);
    //            print(hit.collider.tag);

    //        }
    //    }
    //}

    //트리거에 같은 아군 유닛이 들어오면 멈춤
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "UnitCenter")
        {
            UnitScript newUnit = other.transform.parent.GetComponent<UnitScript>();

            if (unitScript.playerNumber == 1 &&
                unitScript.playerNumber == newUnit.playerNumber &&
                unitScript.getUnitType() == newUnit.getUnitType() &&
                !unitScript.gameObject.Equals(newUnit.gameObject) &&
                newUnit.gameObject.transform.localPosition.x < unitScript.gameObject.transform.localPosition.x + 10)
            {
                triggerUnit = newUnit;
                print(unitScript.getUnitType() + "" + unitScript.playerNumber + " collider " +
                    triggerUnit.getUnitType() + "" + triggerUnit.playerNumber);
                triggerUnit.setCheckCanMove(false);
            }
            else if (unitScript.playerNumber == 2 &&
                unitScript.playerNumber == newUnit.playerNumber &&
                unitScript.getUnitType() == newUnit.getUnitType() &&
                unitScript.gameObject != newUnit.gameObject &&
                newUnit.gameObject.transform.localPosition.x > unitScript.gameObject.transform.localPosition.x - 10)
            {
                triggerUnit = newUnit;
                print(unitScript.getUnitType() + "" + unitScript.playerNumber + " collider " +
                    triggerUnit.getUnitType() + "" + triggerUnit.playerNumber);
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
            triggerUnit = other.transform.parent.GetComponent<UnitScript>();

            triggerUnit.setCheckCanMove(true);
        }
    }
}
