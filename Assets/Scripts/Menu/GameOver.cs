using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Variables
    private CharacterController2D playerControllerScript;
    private Button button; 

    // Start is called before the first frame update
    void Start()
    {
        // setting variables
        playerControllerScript = GameObject.Find("Player").GetComponent<CharacterController2D>();
        button = GetComponent<Button>();

        // start button
        button.onClick.AddListener(restartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
