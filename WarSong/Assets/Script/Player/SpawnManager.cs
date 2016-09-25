using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {
    private bool checkSpawnDoing = false;
    private GameObject newUnit;

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
            newUnit = (GameObject)Instantiate(circleUnit.gameObject);
        }
    }

    public void SpawnUnit(LineScript line)
    {
        Debug.Log("Spawn");
        newUnit.transform.SetParent(lineList[line.lineNumber].transform);
        newUnit.transform.localPosition = new Vector3(-650, -162.5f, 0);
        newUnit.SetActive(true);
        checkSpawnDoing = false;
    }
}
