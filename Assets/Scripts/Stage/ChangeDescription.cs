using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeDescription : MonoBehaviour
{
    [SerializeField] Sprite description;
    [SerializeField] GameObject memo;
    [SerializeField] bool canSpawn;
    [SerializeField] int unit_num;

    void OnMouseEnter()
    {
        //print("Mouse Over");
        memo.gameObject.SetActive(true);
        memo.GetComponent<Image>().sprite = description;
    }

    void OnMouseDown()
    {
        //print("Mouse Cliked");
        if (canSpawn)
        {
            //print("Can Spawn");
            GameObject spawnUnit = GameObject.Find("OurSpawner");
            if (spawnUnit != null)
            {   
                //print("Spanwer Found");
                SpawnUnit spawn = spawnUnit.GetComponent<SpawnUnit>();
                if (spawn != null)
                {
                    spawn.Spawn(unit_num);
                }
            }
        }
    }

    void OnMouseExit()
    {
        memo.SetActive(false);
    }
}
