using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameText;
    [SerializeField] private TextMeshProUGUI highscoreText;

    private int counter;
    private int highscore;

    private void Awake()
    {
        counter = 0;
        scoreText.text = counter.ToString();
        LoadHighScore();

        if (instance == null)
        {
            instance = this;
            return;
        }
        Destroy(gameObject);
    }

    private void LoadHighScore()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        SetHighScoreText(highscore);
    }

    public void AddScore()
    {
        counter++;
        GetScore();
        PlayerPrefs.SetInt("total", counter);

        if (counter > highscore)
        {
            highscore = counter;
            SaveHighScore(highscore);
            SetHighScoreText(highscore);
        }
    }

    public int GetScore()
    {
        scoreText.text = counter.ToString();
        gameText.text = "Your Score: \n" + counter.ToString();
        return counter;
    }

    private void SetHighScoreText(int score)
    {
        highscoreText.text = score.ToString();
    }

    private void SaveHighScore(int score)
    {
        PlayerPrefs.SetInt("Highscore", score);
    }
    public void RestartGame()
    {
        counter = 0;
        PlayerPrefs.SetInt("total", counter);
        LoadHighScore();
    }
}
