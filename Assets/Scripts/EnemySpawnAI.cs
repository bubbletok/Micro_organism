using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnAI : MonoBehaviour
{
    [SerializeField] GameObject[] spawnUnit;
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
                Instantiate(spawnUnit[randUnitNum], transform.position, Quaternion.identity);
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
