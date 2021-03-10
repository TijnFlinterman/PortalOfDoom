using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 4f;
    public float movementSpeedUpDown = 4f;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector3 movespeed;
    Vector3 moveSpeedUpDown;
    public AudioSource Death;
    public AudioSource Hurt;
    bool isDead = false;

    public int currentHP = 5;
    public int maxHP = 5;
    [SerializeField]
    private GameObject[] Health;

    public Animator animator;

    void Start()
    {
        currentHP = maxHP;
        movespeed = new Vector3(movementSpeed, 0, 0);
        moveSpeedUpDown = new Vector3(0, movementSpeedUpDown, 0);


        for (int i = 0; i <= -1; i++)
        {
            Health[i].gameObject.SetActive(false);
        }
        currentHP = 5;
    }

    void Update()
    {
        if (isDead == false)
        {
            if (currentHP <= 0)
            {
                isDead = true;
                StartCoroutine(Die());
            }
        }


        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    void FixedUpdate()
    {
        if (isDead == false)
        {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position - movespeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + movespeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + moveSpeedUpDown * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position - moveSpeedUpDown * Time.deltaTime;
        }
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EBullet")
        {
            Hurt.Play();
            currentHP--;
            Health[currentHP].gameObject.SetActive(false);
            Destroy(collision.gameObject);
        }
    }

    public IEnumerator Die()
    {
        Death.Play();
        animator.SetBool("Death", true);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(sceneName: "Gameplay");

    }

    public void TakeDamage(int damage)
    {
        Hurt.Play();
        currentHP -= damage;
        Health[currentHP].gameObject.SetActive(false);
    }
}
