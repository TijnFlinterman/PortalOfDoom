using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public GameObject Fade_In;
    public GameObject Music;

    public GameObject Player;

    public void MainMenu()
    {
        StartCoroutine("ToMainMenu");
    }

    public void Play()
    {
        StartCoroutine("StartGame");
    }

    public void Settings()
    {
        StartCoroutine("StartGame");
    }

    public void EndGame()
    {
        StartCoroutine("TheEnd");
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator StartGame()
    {
        Music.SetActive(false);
        Fade_In.SetActive(true);
        yield return new WaitForSeconds(1.5f * Time.deltaTime);
        SceneManager.LoadScene(1);
    }

    IEnumerator ToMainMenu()
    {
        Player.transform.position = new Vector2(-10000,-300000);
        Time.timeScale = 1;
        Fade_In.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(0);
    }

    IEnumerator TheEnd()
    {
        Music.SetActive(false);
        Fade_In.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(0);
    }
}
