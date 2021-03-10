using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAim : MonoBehaviour
{    
    public bool Left = false;
    public bool Right = false;
    public bool Up = false;
    public bool Down = false;

    Vector3 myRotation;

    public GameObject Arrow;
    public SpriteRenderer ArrowSpriteRenderer;

    

    private void Start()
    {
        ArrowSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Reads if key is pressed or not

        if (Input.GetKeyDown("left"))
        {
            Left = true;
        }
        if (Input.GetKeyUp("left"))
        {
            Left = false;
        }

        if (Input.GetKeyDown("right"))
        {
            Right = true;
        }
        if (Input.GetKeyUp("right"))
        {
            Right = false;
        }

        if (Input.GetKeyDown("up"))
        {
            Up = true;
        }
        if (Input.GetKeyUp("up"))
        {
            Up = false;
        }

        if (Input.GetKeyDown("down"))
        {
            Down = true;
        }
        if (Input.GetKeyUp("down"))
        {
            Down = false;
        }

        if (Left == true && Up == false && Down == false)
        {
            myRotation = new Vector3(0f, 0f, 90f);
            Arrow.transform.localEulerAngles = myRotation;
        }
        if (Left == false && Up == true && Right == false)
        {
            myRotation = new Vector3(0f, 0f, 360f);
            Arrow.transform.localEulerAngles = myRotation;
        }
        if (Up == false && Right == true && Down == false)
        {
            myRotation = new Vector3(0f, 0f, -90f);
            Arrow.transform.localEulerAngles = myRotation;
        }
        if (Left == false && Right == false && Down == true)
        {
            myRotation = new Vector3(0f, 0f, 180f);
            Arrow.transform.localEulerAngles = myRotation;
        }
        // Corners
        if (Left == true && Right == false && Down == false && Up == true)
        {
            myRotation = new Vector3(0f, 0f, 45f);
            Arrow.transform.localEulerAngles = myRotation;
        }
        if (Left == false && Right == true && Down == false && Up == true)
        {
            myRotation = new Vector3(0f, 0f, -45f);
            Arrow.transform.localEulerAngles = myRotation;
        }
        if (Left == false && Right == true && Down == true && Up == false)
        {
            myRotation = new Vector3(0f, 0f, -135f);
            Arrow.transform.localEulerAngles = myRotation;
        }
        if (Left == true && Right == false && Down == true && Up == false)
        {
            myRotation = new Vector3(0f, 0f, 135f);
            Arrow.transform.localEulerAngles = myRotation;
        }

        if (Left == false && Right == false && Down == false && Up == false)
        {
            Arrow.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            Arrow.GetComponent<Renderer>().enabled = true;
        }
    }
}
