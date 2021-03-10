using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DemonScript : MonoBehaviour
{
    public GameObject bullet;
    public Animator anim;
    private SpriteRenderer mySpriteRenderer;

    public float speed;
    private Transform target;
    private GameObject targetob;
    public int HP = 10;

    float x;
    float y;

    bool attack;
    bool faceRight;

    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        targetob = GameObject.Find("Player");

        target = targetob.GetComponent<Transform>();

        attack = true;

        faceRight = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (attack == true)
        {
            StartCoroutine("shoot");
        }

        x = transform.position.x;
        y = transform.position.y;

        if (Vector2.Distance(transform.position, target.position) > 1.25)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if (transform.position.x > x)
        {
            if (mySpriteRenderer != null)
            {
                mySpriteRenderer.flipX = true;
            }
        }
        else if (transform.position.x < x)
        {
            {
                mySpriteRenderer.flipX = false;
            }
        }

    }

    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.position) > 5)
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
        }
        if (HP <= 0)
        {
            StartCoroutine("onDeath");
        }
    }

    IEnumerator shoot()
    {
        attack = false;

        Instantiate(bullet, transform.position, transform.rotation);
        Instantiate(bullet, transform.position + new Vector3(0, 0.3f, 0), transform.rotation);
        Instantiate(bullet, transform.position + new Vector3(0, -0.3f, 0), transform.rotation);
        Instantiate(bullet, transform.position + new Vector3(0, 0.6f, 0), transform.rotation);

        yield return new WaitForSeconds(2);

        attack = true;
    }

    IEnumerator onDeath()
    {
        anim.SetBool("On Death", true);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
