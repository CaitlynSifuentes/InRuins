using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Variables
    public float scrollSpeed;
    private CharacterController2D playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.isGameOver && playerControllerScript.hasGameStarted) {
        // Makes the obstacles move left based on scroll speed
        transform.Translate(Vector2.left * Time.deltaTime * scrollSpeed);
        } // end if

        // destroys the object after it is out of view
        if (transform.position.x < -16 && gameObject.CompareTag("Obstacle")) {
            Destroy(gameObject);
        } // end if
    }
}