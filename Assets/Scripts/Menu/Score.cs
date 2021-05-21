using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Variables
    public Text scoreText;
    public Text highScoreText;
    public int score;
    public int highScore;
    private CharacterController2D playerControllerScript;

    // On Game Start
    void Awake()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("Highscore");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // setting variables
        playerControllerScript = GameObject.Find("Player").GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.isGameOver)
        {
            SaveHighScore(score);
            highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
    }

    /** SCORE ADDITION MECHANICS **/
    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("ObstacleS")) {
            score ++;
            scoreText.text = score.ToString();
        }
    }
    /** END **/


    /** HIGHSCORE MECHANICS **/
    private bool SaveHighScore(int newScore)
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        bool gotNewHighScore = newScore > highScore;

        if (gotNewHighScore)
        {
            PlayerPrefs.SetInt("HighScore", newScore);
            PlayerPrefs.Save();
        }

        return gotNewHighScore;
    }
    /** END **/
}
