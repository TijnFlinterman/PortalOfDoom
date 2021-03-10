using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DemonBackup : MonoBehaviour
{
    public Animator anim;

    public float speed;
    private Transform target;
    private GameObject targetob;
    private GameObject EnemyWall;
    public int HP = 10;
    public AudioSource Hurt;
    public AudioSource Died;

    float x;
    float y;

    bool faceRight;
    bool hasDied;

    void Start()
    {
        targetob = GameObject.Find("Player");

        target = targetob.GetComponent<Transform>();

        faceRight = false;

        EnemyWall = GameObject.Find("EnemyWaller");
    }

    private void Update()
    {

        x = transform.position.x;
        y = transform.position.y;
        if (Vector2.Distance(transform.position, target.position) > 7)
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

    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.position) > 8)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == ("Bullet"))
        {
            print("working");
            HP -= 1;
            Destroy(coll.gameObject);
            Hurt.Play();
        }
        if (HP <= 0)
        {
            if (hasDied == false)
            {
                hasDied = true;
                EnemyWall.GetComponent<EmenyChecker>().OnKilled();
                StartCoroutine("onDeath");
            }
        }
    }

    IEnumerator onDeath()
    {
        Died.Play();
        anim.SetBool("On Death", true);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
