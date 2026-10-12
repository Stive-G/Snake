using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0;
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
