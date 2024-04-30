using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Michael

public class ScoreManager : MonoBehaviour
{
    public TextManager textManager;
    public int treatCounter = 0;
    public int score = 0;
    public Text Score;
    
    

    public void IncrementScore()
    {
        score += 1;
        UpdateScoreDisplay();
        if (score == 10)
        {
            LoadNextScene();
        }

    }

    /*public void dog()
    {
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "Dog_001" && treatCounter <= 3)
            {
                treatCounter++; // Increment the treat counter
                

                if (treatCounter == 3) // If the dog has received 3 treats 
                {
                    textManager.SetText("Enough, Stop");
                    // Disable the colliders instead of destroying the treat object
                    treatCollider.enabled = false;
                    treatCollider2.enabled = false;
                    return; // Exit the method to prevent further execution
                }

                // Don't destroy the treat object here
                Destroy(gameObject);
                textManager.SetText("Bark Bark");
                
            }
        }
    }*/
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
