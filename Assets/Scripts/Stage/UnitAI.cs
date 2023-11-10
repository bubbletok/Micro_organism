using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class UnitAI : MonoBehaviour
{
    public float hp;
    public float onToxic;
    [SerializeField] float maxhp;
    [SerializeField] float speed;
    [SerializeField] float dmg;
    [SerializeField] Transform target;
    [SerializeField] float attackDelay;
    [SerializeField] bool ourUnit;
    [SerializeField] GameObject attackProjectile;
    

    Animator animator;
    SpriteRenderer sprite;
    bool onAttack;
    bool canAttack;
    bool canGetToxic;
    Vector3 dirToTarget;
    GameObject attackTarget;
    List<GameObject> attackTargets = new List<GameObject>();
    // Update is called once per frame

    protected virtual void Awake()
    {
        if (ourUnit) //아군 unit 이라면 적 콜로니로 향함
        {
            target = GameObject.FindWithTag("EnemySpawner").transform;
        }

        else //적 unit 이라면 아군 콜로니로 향함
        {
            target = GameObject.FindWithTag("OurSpawner").transform;
        }
    }

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        if (target != null)
        {
            dirToTarget = (target.position- transform.position).normalized;
        }
        else
        { 
            dirToTarget = Vector3.zero;
        }
        onAttack = false;
        canAttack = true;
        canGetToxic = true;
    }

    protected virtual void Update()
    {
        IsOutofArea(-20, -20, 20, 20);
        Death();

        //go to target
        if(target == null)
        {
            if (ourUnit)
            {
                GameObject temp = GameObject.FindWithTag("EnemySpawner");
                if (temp != null)
                {
                    target = GameObject.FindWithTag("EnemySpawner").transform;
                }
                else
                {
                    dirToTarget = Vector3.zero;
                }
            }
            else
            {
                GameObject temp = GameObject.FindWithTag("OurSpawner");
                if (temp != null)
                {
                    target = GameObject.FindWithTag("OurSpawner").transform;
                }
                else
                {
                    dirToTarget = Vector3.zero;
                }
            }
        }

        //check if it has an attack target
        if (attackTargets.Count > 0)
        {
            onAttack = true;
        }
        else
        {
            onAttack = false;
        }

        //set animation state
        animator.SetBool("IsAttacking",onAttack);


        //rotate it depend on direction to target
        if(dirToTarget.x < 0)
        {
            transform.rotation = new Quaternion(0,180,0,1);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }

        //
        if(onToxic > 0)
        {
            GetToxicDamage();
            onToxic -= 0.1f;
        }
        else if (onToxic < 0)
        {
            onToxic = 0;
            canGetToxic = false;
        }

        //check if it on toxic
        if (onToxic > 0)
        {
            sprite.color = new Color(100, 0, 0);
        }
        else
        {
            sprite.color = new Color(255, 255, 255);
        }
    }
    protected virtual void FixedUpdate()
    {
        DoAction();
    }

    protected virtual void Death()
    {
        if (hp<=0)
        {
            Destroy(gameObject);
        }
    }
    void IsOutofArea(float minX, float minY, float maxX, float maxY)
    {
        if (transform.position.x < minX || transform.position.x > maxX || transform.position.y < minY || transform.position.y > maxY)
        {
            Destroy(this);
        }
    }
    void DoAction()
    {
        if (onAttack)
        {
            if (canAttack)
            {
                FindNearstTarget();
                Attack();
            }
        }
        else
        {
            Move();
        }

    }

    void GetToxicDamage()
    {
        print("TOXIC");
        if (canGetToxic)
        {

            canGetToxic = false;
            hp -= 25f;
            StartCoroutine(WaitToToxicDamage());
        }
    }

    IEnumerator WaitToToxicDamage()
    {
        yield return new WaitForSeconds(1);
        canGetToxic = true;
    }

    void Move()
    {
        transform.position += dirToTarget * speed * Time.deltaTime;
    }

    void FindNearstTarget()
    {
        float min = 999999999;
        foreach(GameObject target in attackTargets)
        {
            float dist = Vector3.Distance(target.transform.position, transform.position);
            if (dist < min)
            {
                attackTarget = target;
                min = dist;
            }
        }
    }

    void Attack()
    {
        //attack something
        if (attackTarget != null)
        {
            //attack target
            if (attackProjectile != null)
            {
                ProjectileMovement projectile = Instantiate(attackProjectile, transform.position,Quaternion.identity).GetComponent<ProjectileMovement>();
                projectile.dmg = dmg;
                projectile.dirToMove = (attackTarget.transform.position - transform.position).normalized;
                projectile.target = attackTarget;
                canAttack = false;
                //wait for attackDelay
                StartCoroutine(WaitToAttack());
            }
        }
    }

    IEnumerator WaitToAttack()
    {
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ourUnit)
        {
            if (collision.tag == "Enemy" || collision.tag == "EnemySpawner")
            {
                attackTargets.Add(collision.gameObject);
            }
        }
        else
        {
            if (collision.tag == "OurUnit" || collision.tag == "OurSpawner")
            {
                attackTargets.Add(collision.gameObject);
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (ourUnit)
        {
            if (collision.tag == "Enemy" || collision.tag == "EnemySpawner")
            {
                if (attackTargets.Count > 0 && attackTargets.Contains(collision.gameObject))
                {
                    attackTargets.Remove(collision.gameObject);
                }
            }
        }
        else
        {
            if (collision.tag == "OurUnit" || collision.tag == "OurSpawner")
            {
                if (attackTargets.Count > 0 &&  attackTargets.Contains(collision.gameObject))
                {
                    attackTargets.Remove(collision.gameObject);
                }
            }
        }
    }
}
