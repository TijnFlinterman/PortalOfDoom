using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public GameObject bullet;
    Transform Target;

    public int maxhealth = 150;
    public int currentHealth;
    public float speed;
    private GameObject Portal;
    public AudioSource Shoot;
    public AudioSource Mgun;
    public AudioSource Shgun;

    private GameObject healthbar;

    public Vector2 target;

    bool newAttack;
    bool newPosition;
    bool hasDied;

    public float degreesPerSec = 360f;
    // Start is called before the first frame update
    void Start()
    {
        healthbar = GameObject.Find("HealthBarIG");
        currentHealth = maxhealth;
        healthbar.GetComponent<BossHealthBar>().SetMaxHealth(maxhealth);

        newAttack = true;
        newPosition = true;
        Portal = GameObject.Find("PortalPivot");
        Target = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            if (hasDied == false)
            {
                Portal.GetComponent<PortalManager>().BossDeath();
                hasDied = true;
                Destroy(gameObject);
            }
        }


        int randomAttack;

        if (newAttack == true)
        {
            randomAttack = Random.Range(0, 4);

            if (randomAttack == 1)
            {
                StartCoroutine("shootBullets");
                newAttack = false;
            }

            if (randomAttack == 2)
            {
                StartCoroutine("minigun");
                newAttack = false;
            }

            if (randomAttack == 3)
            {
                StartCoroutine("shotgun");
                newAttack = false;
            }
        }
    }

    void FixedUpdate()
    {
        float randomx;
        float randomy;

        if (newPosition == true)
        {

            randomx = Random.Range(9, -9);
            randomy = Random.Range(5, -5);

            target = new Vector2(randomx, randomy);

            newPosition = false;
        }

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            StartCoroutine("waitForNewPos");
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            currentHealth--;
            healthbar.GetComponent<BossHealthBar>().SetHealth(currentHealth);
            Destroy(collision.gameObject);
        }
    }

    IEnumerator shootBullets()
    {
        int amount = 0;

        yield return new WaitForSeconds(1);
        while (amount < 5)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            Shoot.Play();
            amount++;
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(2);
        newAttack = true;
        StopCoroutine("shootBullets");
    }

    IEnumerator minigun()
    {
        int amount = 0;
        print("minigun");

        while (amount < 25)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            Mgun.Play();
            amount++;
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(2);
        newAttack = true;
        StopCoroutine("minigun");
    }

    IEnumerator shotgun()
    {
        int amount = 0;

        while (amount < 12)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            Shgun.Play();
            Instantiate(bullet, transform.position + new Vector3(0,0.3f,0), transform.rotation);
            Instantiate(bullet, transform.position + new Vector3(0, -0.3f, 0), transform.rotation);
            Instantiate(bullet, transform.position + new Vector3(0, 0.6f, 0), transform.rotation);
            amount = amount + 4;
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(2);
        newAttack = true;
        StopCoroutine("shotgun");
    }

    IEnumerator waitForNewPos()
    {
        yield return new WaitForSeconds(5);
        newPosition = true;
        StopCoroutine("waitForNewPos");
    }
}
