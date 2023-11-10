using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float speed;
    public float dmg;
    public Vector3 dirToMove;
    public bool ourProjectile;
    public GameObject target;

    private void Start()
    {
        StartCoroutine(WaitToDestory());
    }

    IEnumerator WaitToDestory()
    {
       yield return new WaitForSeconds(10f);
        if (this != null)
        {
            Destroy(this);
        }
    }
    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
        IsOutofArea(-20, -20, 20, 20);
    }

    void IsOutofArea(float minX, float minY, float maxX, float maxY)
    {
        if (transform.position.x < minX || transform.position.x > maxX || transform.position.y < minY || transform.position.y > maxY)
        {
            Destroy(this);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += dirToMove * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(ourProjectile)
        {
            if (collision.tag == "Enemy")
            {
                UnitAI enemy = collision.GetComponent<UnitAI>();
                if (enemy != null)
                {
                    enemy.hp -= dmg;
                    Destroy(gameObject);
                }
            }
            else if (collision.tag == "EnemySpawner")
            {
                SpawnerInfo spawner = collision.GetComponent<SpawnerInfo>();
                if (spawner != null)
                {
                    spawner.hp -= dmg;
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            if (collision.tag == "OurUnit")
            {
                UnitAI unit = collision.GetComponent<UnitAI>();
                if (unit != null)
                {
                    unit.hp -= dmg;
                    Destroy(gameObject);
                }
            }
            else if (collision.tag == "OurSpawner")
            {
                SpawnerInfo spawner = collision.GetComponent<SpawnerInfo>();
                if(spawner != null)
                {
                    spawner.hp -= dmg;
                    Destroy(gameObject);
                }
            }

        }
    }

}
