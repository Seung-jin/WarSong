using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {
    private bool checkSpawnDoing = false;
    private GameObject newCircleUnit;

    public int playerNumber;
    public CircleUnitScript circleUnit;
    public List<GameObject> lineList = new List<GameObject>();

    public bool getCheckSpawnDoing() { return checkSpawnDoing; }

    public void OnClickCircleUnitButton()
    {
        Debug.Log("CircleButton Click");
        if(!checkSpawnDoing)
        {
            checkSpawnDoing = true;
            newCircleUnit = (GameObject)Instantiate(circleUnit.gameObject);
        }
    }

    public void SpawnUnit(LineScript line)
    {
        Debug.Log("Spawn");
        newCircleUnit.transform.SetParent(lineList[line.lineNumber].transform);
        newCircleUnit.transform.localPosition = new Vector3(80, line.transform.localPosition.y, 0);
        newCircleUnit.SetActive(true);
        checkSpawnDoing = false;
    }
}
