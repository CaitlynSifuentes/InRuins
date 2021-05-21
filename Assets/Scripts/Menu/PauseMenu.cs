using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Variables 
    public static bool isGamePaused = false;
    public GameObject pauseMenu;
    private CharacterController2D playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !playerControllerScript.isGameOver) {
            if (isGamePaused) {
                resume();
            }
            else {
                pause();
            }
        } // end if
    }

    /** PAUSE MECHANICS **/
    void pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        isGamePaused = true;
    }
    /** END **/

    /** RESUME MECHANICS **/
    public void resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    /** END **/
}
