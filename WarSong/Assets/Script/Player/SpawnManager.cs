using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {
    private bool checkSpawnDoing = false;   //소환 대기중인지 아닌지. 유닛 소환 버튼을 누르면 true상태
    private GameObject newUnit;
    private Unit.UnitType unitType;
    private bool checkClocking;

    public int playerNumber;
    public List<GameObject> lineList = new List<GameObject>();
    public List<GameObject> unitList = new List<GameObject>();

    public List<UnitSpawnButtonScript> unitSpawnButtonList = new List<UnitSpawnButtonScript>();
    public ClockingButtonScript clockingButton;

    public bool getCheckSpawnDoing() { return checkSpawnDoing; }

    /// <summary>
    /// 동그라미 유닛을 클릭했을 때
    /// </summary>
    public void ClickDistanceSpawnButton()
    {
        Debug.Log(playerNumber + "player : DistanceUnit Click");
        if(!checkSpawnDoing)
        {
            checkSpawnDoing = true;
            unitType = Unit.UnitType.Distance;
            newUnit = (GameObject)Instantiate(unitList[(int)unitType]);
            DistanceUnit distanceUnit = newUnit.GetComponent<DistanceUnit>();
            distanceUnit.spawnManager = this;
            distanceUnit.Initialize();
            CheckClocking(distanceUnit);
        }
    }

    public void ClickTankerSpawnButton()
    {
        Debug.Log(playerNumber + "player : TankerUnit Click");
        if(!checkSpawnDoing)
        {
            checkSpawnDoing = true;
            unitType = Unit.UnitType.Tanker;
            newUnit = (GameObject)Instantiate(unitList[(int)unitType]);
            TankerUnit tankerUnit = newUnit.GetComponent<TankerUnit>();
            tankerUnit.spawnManager = this;
            tankerUnit.Initialize();
            CheckClocking(tankerUnit);
        }
    }

    public void ClickSpeedSpawnButton()
    {
        Debug.Log(playerNumber + "player : SpeedUnit Click");
        if (!checkSpawnDoing)
        {
            checkSpawnDoing = true;
            unitType = Unit.UnitType.Speed;
            newUnit = (GameObject)Instantiate(unitList[(int)unitType]);
            SpeedUnit speedUnit = newUnit.GetComponent<SpeedUnit>();
            speedUnit.spawnManager = this;
            speedUnit.Initialize();
            CheckClocking(speedUnit);
        }
    }

    public void ClickWideSpawnButton()
    {
        Debug.Log(playerNumber + "player : WideUnit Click");
        if (!checkSpawnDoing)
        {
            checkSpawnDoing = true;
            unitType = Unit.UnitType.Wide;
            newUnit = (GameObject)Instantiate(unitList[(int)unitType]);
            WideUnit wideUnit = newUnit.GetComponent<WideUnit>();
            wideUnit.spawnManager = this;
            wideUnit.Initialize();
            CheckClocking(wideUnit);
        }
    }

    public void ClickClockingButton()
    {
        checkClocking = true;
    }

    //유닛 소환 직전 은폐버튼을 누른 상태인지 아닌지 체크
    public void CheckClocking(Unit unit)
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
        unitSpawnButtonList[(int)newUnit.GetComponent<Unit>().getUnitType()].SettingData();
        if(checkClocking)
            clockingButton.SettingData();
        newUnit.SetActive(true);
        checkSpawnDoing = false;
        checkClocking = false;
    }
}
