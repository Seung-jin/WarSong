using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {
    private bool checkSpawnDoing = false;   //소환 대기중인지 아닌지. 유닛 소환 버튼을 누르면 true상태
    private GameObject newUnit;
    private UnitScript.UnitType unitType;
    private bool checkClocking;

    public int playerNumber;
    public List<GameObject> lineList = new List<GameObject>();
    public List<GameObject> unitList = new List<GameObject>();

    public bool getCheckSpawnDoing() { return checkSpawnDoing; }

    /// <summary>
    /// 동그라미 유닛을 클릭했을 때
    /// </summary>
    public void OnClickCircleUnitButton()
    {
        Debug.Log(playerNumber + "player : CircleButton Click");
        if(!checkSpawnDoing)
        {
            checkSpawnDoing = true;
            unitType = UnitScript.UnitType.Circle;
            newUnit = (GameObject)Instantiate(unitList[(int)unitType]);
            CircleUnitScript circleUnit = newUnit.GetComponent<CircleUnitScript>();
            circleUnit.spawnManager = this;
            circleUnit.Initialize();
            CheckClocking(circleUnit);
        }
    }

    public void OnClickRectangleUnitButton()
    {
        Debug.Log(playerNumber + "player : RectangleButton Click");
        if(!checkSpawnDoing)
        {
            checkSpawnDoing = true;
            unitType = UnitScript.UnitType.Rectangle;
            newUnit = (GameObject)Instantiate(unitList[(int)unitType]);
            RectangleUnitScript rectangleUnit = newUnit.GetComponent<RectangleUnitScript>();
            rectangleUnit.spawnManager = this;
            rectangleUnit.Initialize();
            CheckClocking(rectangleUnit);
        }
    }

    public void OnClickTriangleUnitButton()
    {
        Debug.Log(playerNumber + "player : RectangleButton Click");
        if (!checkSpawnDoing)
        {
            checkSpawnDoing = true;
            unitType = UnitScript.UnitType.Triangle;
            newUnit = (GameObject)Instantiate(unitList[(int)unitType]);
            TriangleUnitScript triangleUnit = newUnit.GetComponent<TriangleUnitScript>();
            triangleUnit.spawnManager = this;
            triangleUnit.Initialize();
            CheckClocking(triangleUnit);
        }
    }

    public void OnClickDiamondUnitButton()
    {

    }

    public void OnClickClockingButton()
    {
        checkClocking = true;
    }

    //유닛 소환 직전 은폐버튼을 누른 상태인지 아닌지 체크
    public void CheckClocking(UnitScript unit)
    {
        if (checkClocking)
        {
            unit.unitImage.color = new Color(unit.unitImage.color.r,
                unit.unitImage.color.g, unit.unitImage.color.b, 0);
            unit.hpGuageBar.SetActive(false);
        }
    }

    /// <summary>
    /// 라인을 클릭했을 시 라인이 가지고 있던 유닛이 해당 라인에 소환이 됨
    /// </summary>
    /// <param name="line">전투가 벌어지는 라인</param>
    public void SpawnUnit(LineScript line)
    {
        Debug.Log("Spawn");
        newUnit.transform.SetParent(lineList[line.lineNumber].transform);
        if (playerNumber == 1)
            newUnit.transform.localPosition = new Vector3(-650, -162.5f, 0);
        else if (playerNumber == 2)
            newUnit.transform.localPosition = new Vector3(650, -162.5f, 0);
        newUnit.SetActive(true);
        checkSpawnDoing = false;
        checkClocking = false;
    }
}
