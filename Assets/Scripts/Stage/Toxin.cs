using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toxin : MonoBehaviour
{
    public bool ourUnit;
    [SerializeField] float toxicTime;
    [SerializeField] float destroyDelay;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitToDestory());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (ourUnit)
        {
            if(collision.tag == "Enemy")
            {
                UnitAI enemy = collision.GetComponent<UnitAI>();
                enemy.onToxic = toxicTime;
            }
        }
        else
        {
            if(collision.tag == "OurUnit")
            {
                UnitAI unit = collision.GetComponent<UnitAI>();
                unit.onToxic = toxicTime;
            }
        }
    }

    IEnumerator WaitToDestory()
    {
        yield return new WaitForSeconds(destroyDelay);
        if(gameObject!=null)
        {
            Destroy(gameObject);
        }
    }
}
