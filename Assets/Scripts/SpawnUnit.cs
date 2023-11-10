using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnit : MonoBehaviour
{
    [SerializeField] GameObject[] spawnUnit;
    [SerializeField] Transform[] spawnPoint;
    public void Spawn(int unit_num)
    {
        int randN = Random.Range(0, spawnUnit.Length);
        Instantiate(spawnUnit[unit_num],spawnPoint[randN].position,Quaternion.identity);
    }
}
