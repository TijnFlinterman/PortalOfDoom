using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmenyChecker : MonoBehaviour
{
    public GameObject Wall1;
    public GameObject Wall2;
    public GameObject Wall3;
    
    // Number of enemies alive
    private static int aliveCounter = 15;

    void Start()
    {
        aliveCounter = 15;
    }

    public void OnKilled()
    {
        aliveCounter--;
    }
    private void Update()
    {
        if (aliveCounter == 11)
        {
            Destroy(Wall1);
        }
        if (aliveCounter == 8)
        {
            Destroy(Wall2);
        }
        if (aliveCounter == 0)
        {
            Destroy(Wall3);
        }
    }
}
