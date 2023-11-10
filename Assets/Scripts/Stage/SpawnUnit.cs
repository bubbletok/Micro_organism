using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnit : MonoBehaviour
{
    [SerializeField] GameObject[] spawnUnit;
    [SerializeField] Transform[] spawnPoint;


    float[,] aw;
    float[,] ph;
    float[,] temp;
    //bool[] oxygen;

    void Start()
    {
        aw = UnitCondition.instance.aw;
        ph = UnitCondition.instance.ph;
        temp = UnitCondition.instance.temp;
        //oxygen = UnitCondition.instance.oxygen;
    }
    public void Spawn(int unit_num)
    {
        if (GameManager.Instance.amino >= 1)
        {
            GameManager.Instance.amino--;
            int randPoint = Random.Range(0, spawnUnit.Length);
            bool isSuitable = checkIsSuitable(unit_num);
            if (isSuitable)
            {
                Instantiate(spawnUnit[unit_num], spawnPoint[randPoint].position, Quaternion.identity);
                int randPoint2;
                if (randPoint == 0) {randPoint2 = randPoint + 1;}
                else { randPoint2 = randPoint - 1; }
                Instantiate(spawnUnit[unit_num], spawnPoint[randPoint2].position, Quaternion.identity);
            }
            else
            {
                Instantiate(spawnUnit[unit_num], spawnPoint[randPoint].position, Quaternion.identity);
            }
        }
    }

    bool checkIsSuitable(int num)
    {
        GameManager game = GameManager.Instance;
        float curAw = game.aw;
        float curPh = game.ph;
        float curTemp = game.temp;
        //bool curOxygen = game.oxygen;
        /*        print(curAw + " " + curPh + " " + curTemp + " " + curOxygen);
                print(aw[num, 0] + " " + aw[num, 1]);
                print(ph[num,0] + " " + ph[num,1]);
                print(temp[num,0] + " " + temp[num,1]);
                print(oxygen[num]);*/
        return (aw[num, 0] <= curAw && curAw <= aw[num, 1]) && (ph[num, 0] <= curPh && curPh <= ph[num, 1]) && (temp[num, 0] <= curTemp && curTemp <= temp[num, 1]);/* && (oxygen[num] == curOxygen)*/;
    }
}
