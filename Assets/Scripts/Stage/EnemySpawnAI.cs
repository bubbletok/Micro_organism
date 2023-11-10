using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnAI : MonoBehaviour
{
    [SerializeField] GameObject[] spawnUnit;
    [SerializeField] Transform[] spawnPoint;
    [SerializeField] float spawnDelay;

    bool canSpawn = true;

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            int randUnitNum = Random.Range(0, spawnUnit.Length);
            if (spawnUnit[randUnitNum] != null)
            {
                int randPoint = Random.Range(0,spawnPoint.Length);
                Instantiate(spawnUnit[randUnitNum],spawnPoint[randPoint].transform.position, Quaternion.identity);
                canSpawn = false;
                StartCoroutine(WaitToSpawn());
            }
        }
    }

    IEnumerator WaitToSpawn()
    {
        yield return new WaitForSeconds(spawnDelay);
        canSpawn = true;
    }
}
