using UnityEngine;
using System.Collections;

public class LineScript : MonoBehaviour {
    public SpawnManager spawnManager;
    public int lineNumber = 0;

    /// <summary>
    /// 라인을 클릭했을 때 저장하고 있던 유닛을 소환함
    /// </summary>
    public void OnClickLine()
    {
        Debug.Log("Click Line");
        if(spawnManager.getCheckSpawnDoing())
        {
            spawnManager.SpawnUnit(this);
        }
    }
}
