using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBlobScript : MonoBehaviour
{

    public float speed;
    private Transform target;
    private GameObject targetob;
    public GameObject MiniBlob;
    public int HP = 10;
    public AudioSource dies;
    public Animator anim;
    bool hasInstant;

    bool faceRight;

    float x;
    float y;

    Vector3 position;

    void Start()
    {
        targetob = GameObject.Find("Player");
        faceRight = false;
        HP = 10;

        target = targetob.GetComponent<Transform>();
        position = transform.position;
    }

    void Update()
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
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == ("Bullet"))
        {
            HP -= 1;
            Destroy(coll.gameObject);
        }
        if (HP <= 0)
        {
            if (hasInstant == false)
            {
                hasInstant = true;
                dies.Play();
                Instantiate(MiniBlob, transform.position, transform.rotation);
                Instantiate(MiniBlob, transform.position, transform.rotation);
                Instantiate(MiniBlob, transform.position, transform.rotation);
                Destroy(gameObject);
                return;
            }
        }
    }
}


