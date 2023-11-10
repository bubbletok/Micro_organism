using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerInfo : MonoBehaviour
{
    [SerializeField] Slider hpBar;
    public float hp;
    public float maxhp;
    private void Update()
    {
        if (hp < 0)
        {
            Destroy(gameObject);
        }
        hpBar.value = hp/maxhp;
        if (hpBar.value <= 0)
        {
            hpBar.transform.Find("Fill Area").gameObject.SetActive(false);
        }
        else
        {
            hpBar.transform.Find("Fill Area").gameObject.SetActive(true);
        }
    }
}
