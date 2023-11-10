using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Streptococcus : UnitAI
{
    [SerializeField] GameObject toxin;
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        Death();
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Death()
    {
        if (hp <= 0)
        {
            if (toxin != null)
            {
                print("asdf");
                Instantiate(toxin, transform.position, Quaternion.identity);
/*                int randN = Random.Range(0, 1);
                if (randN == 0)
                {
                    Instantiate(toxin, transform.position, Quaternion.identity);
                }*/
            }
            Destroy(gameObject);
        }
    }

}
