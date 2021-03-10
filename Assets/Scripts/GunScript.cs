using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public bool animCap = false;
    public bool isShooting = false;
    public bool Left = false;
    public bool Right = false;
    public bool Up = false;
    public bool Down = false;
    public int delay = 80;

    Vector3 myRotation;

    public Animator animator;

    public GameObject BulletPrefab;
    public GameObject Gun;
    public SpriteRenderer WeaponSpriteRenderer;
    public Transform Barrel;
    public AudioSource shot;


    private void Start()
    {
        WeaponSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (isShooting == true)
        {
            delay -= 1;
        }
    }

    private void Update()
    {
        if (animator.GetBool("Death") == true)
        {
            animCap = true;
        }

        if (delay <= 0)
        {
            Instantiate(BulletPrefab, Barrel.position, Barrel.rotation);
            shot.Play();
            delay = 10;
        }


        // Reads if key is pressed or not

        if (animCap == false)
        {
            Gun.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            Gun.GetComponent<Renderer>().enabled = false;
        }


        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Left = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Left = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Right = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Right = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Up = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Up = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Down = true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Down = false;
        }
        if (Left == true && Up == false && Down == false)
        {
            myRotation = new Vector3(0f, 0f, 90f);
            Gun.transform.localEulerAngles = myRotation;
            isShooting = true;
        }
        if (Left == false && Up == true && Right == false)
        {
            myRotation = new Vector3(0f, 0f, 360f);
            Gun.transform.localEulerAngles = myRotation;
            isShooting = true;
        }
        if (Up == false && Right == true && Down == false)
        {
            myRotation = new Vector3(0f, 0f, -90f);
            Gun.transform.localEulerAngles = myRotation;
            isShooting = true;
        }
        if (Left == false && Right == false && Down == true)
        {
            myRotation = new Vector3(0f, 0f, 180f);
            Gun.transform.localEulerAngles = myRotation;
            isShooting = true;
        }
        // Corners
        if (Left == true && Right == false && Down == false && Up == true)
        {
            myRotation = new Vector3(0f, 0f, 45f);
            Gun.transform.localEulerAngles = myRotation;
            isShooting = true;
        }
        if (Left == false && Right == true && Down == false && Up == true)
        {
            myRotation = new Vector3(0f, 0f, -45f);
            Gun.transform.localEulerAngles = myRotation;
            isShooting = true;
        }
        if (Left == false && Right == true && Down == true && Up == false)
        {
            myRotation = new Vector3(0f, 0f, -135f);
            Gun.transform.localEulerAngles = myRotation;
            isShooting = true;
        }
        if (Left == true && Right == false && Down == true && Up == false)
        {
            myRotation = new Vector3(0f, 0f, 135f);
            Gun.transform.localEulerAngles = myRotation;
            isShooting = true;
        }

        if (Left == false && Right == false && Down == false && Up == false)
        {
            isShooting = false;
        }

        if (WeaponSpriteRenderer != null)
        {
            if (Left == true)
            {
                WeaponSpriteRenderer.flipX = true;
            }
        }
        if (Right == true)
        {
            WeaponSpriteRenderer.flipX = false;
        }
     }
}
