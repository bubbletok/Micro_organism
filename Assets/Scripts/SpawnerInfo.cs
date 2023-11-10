using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerInfo : MonoBehaviour
{
    public float hp;
    public float maxhp;
    private void Update()
    {
        if (hp < 0)
        {
            Destroy(gameObject);
        }
    }
}
