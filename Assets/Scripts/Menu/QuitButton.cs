using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    //Variables 
    private Button button; 

    // Start is called before the first frame update
    void Start()
    {
        // setting variables
        button = GetComponent<Button>();

        // start button
        button.onClick.AddListener(quitButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void quitButton() {
        Application.Quit ();
        Debug.Log("Game is exiting");
    }
}
