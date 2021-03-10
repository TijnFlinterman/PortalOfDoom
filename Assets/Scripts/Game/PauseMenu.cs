using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public GameObject Effect;
    public GameObject Menu;
    bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Time.timeScale = 1;
                isPaused = false;
                Menu.SetActive(!Menu.activeSelf);
                Effect.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                isPaused = true;
                Menu.SetActive(!Menu.activeSelf);
                Effect.SetActive(true);
            }
        }
    }
}
