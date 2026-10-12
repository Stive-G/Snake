using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}