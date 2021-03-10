using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfScript : MonoBehaviour
{

    public float speed;
    private Transform target;
    private GameObject targetob;
    private GameObject EnemyWall;
    public int HP = 10;
    public AudioSource dies;
    public AudioSource Growl;
    public int delay;
    public Animator anim;
    int attackDamage;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;
    bool hasDied;

    bool faceRight;

    float x;
    float y;

    Vector3 position;

    void Start()
    {
        hasDied = false;
        attackDamage = 1;
        targetob = GameObject.Find("Player");
        EnemyWall = GameObject.Find("EnemyWaller");
        faceRight = false;
        HP = 10;
        delay = 80;

        target = targetob.GetComponent<Transform>();
        position = transform.position;
    }

    void Update()
    {
        if (hasDied == false)
        {
            if (HP <= 0)
            {
                hasDied = true;
                StartCoroutine(Die());
            }
        }
        if (hasDied == false)
        {
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
    public IEnumerator Die()
    {
        dies.Play();
        EnemyWall.GetComponent<EmenyChecker>().OnKilled();
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
    public void FixedUpdate()
    {
        if (hasDied == false)
        {
            delay -= 1;
            if (delay <= 0)
            {
                Attack();
            }
        }
    }

    public void Attack()
    {

        delay = 80;
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

        foreach (Collider2D Player in hitPlayer)
        {
            Player.GetComponent<Movement>().TakeDamage(attackDamage);
            Growl.Play();
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

