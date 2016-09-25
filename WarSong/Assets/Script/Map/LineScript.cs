using UnityEngine;
using System.Collections;

public class LineScript : MonoBehaviour {
    public SpawnManager spawnManager;
    public int lineNumber = 0;

    public void OnClickLine()
    {
        Debug.Log("Click Line");
        if(spawnManager.getCheckSpawnDoing())
        {
            spawnManager.SpawnUnit(this);
        }
    }
}
