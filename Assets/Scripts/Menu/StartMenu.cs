using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StartMenu : MonoBehaviour
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
        button.onClick.AddListener(startButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void startButton() {
        playerControllerScript.startGame();
    }
}
