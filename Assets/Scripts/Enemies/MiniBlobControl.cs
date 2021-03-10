using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBlobControl : MonoBehaviour
{

    public float speed;
    private Transform target;
    private GameObject targetob;
    private GameObject EnemyWall;
    public int HP = 2;
    public AudioSource dies;
    public AudioSource Swing;
    public int delay = 80;
    public Animator anim;
    int attackDamage;
    bool hasDied;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;

    bool faceRight;

    float x;
    float y;

    Vector3 position;

    void Start()
    {
        targetob = GameObject.Find("Player");
        faceRight = false;
        HP = 2;
        attackDamage = 1;
        target = targetob.GetComponent<Transform>();
        position = transform.position;
        EnemyWall = GameObject.Find("EnemyWaller");
    }

    void Update()
    {
        if (hasDied == false)
        {
            if (HP <= 0)
            {
                if (hasDied == false)
                {
                    hasDied = true;
                    StartCoroutine(Die());
                }

            }
            x = transform.position.x;
            y = transform.position.y;

            if (Vector2.Distance(transform.position, target.position) > 1.25)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }

            if (transform.position.x > x)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                faceRight = true;
            }
            else if (transform.position.x < x && faceRight == true)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                faceRight = false;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == ("Bullet"))
        {
            HP -= 1;
            Destroy(coll.gameObject);
        }
    }

    private void FixedUpdate()
    {
        delay -= 1;

        if (delay <= 0)
        {
            Attack();
            delay = 80;
        }
    }
    public IEnumerator Die()
    {
        dies.Play();
        EnemyWall.GetComponent<EmenyChecker>().OnKilled();
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }



    void Attack()
    {
        if (hasDied == false)
        {
            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

            foreach (Collider2D Player in hitPlayer)
            {
                Debug.Log("IgotHIT");
                Player.GetComponent<Movement>().TakeDamage(attackDamage);
                Swing.Play();
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}


