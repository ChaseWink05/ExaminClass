using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Michael

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public Text Score;

    public void IncrementScore()
    {
        score += 1;
        UpdateScoreDisplay();
        if (score == 5)
        {
            LoadNextScene();
        }

    }
    void Start()
    {
        UpdateScoreDisplay();
    }

    void UpdateScoreDisplay()
    {
        Score.text = "Score: " + score; 
    }

    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
