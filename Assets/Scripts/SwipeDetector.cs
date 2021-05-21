using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    // Variables
    private Touch theTouch;
    private Vector2 touchStartPosition, touchEndPosition;
    private CharacterController2D playerControllerScript;

    // start is called at the start of game
    void Start() {
        playerControllerScript = GameObject.Find("Player").GetComponent<CharacterController2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) {
            theTouch = Input.GetTouch(0);

            if (theTouch.phase == TouchPhase.Began) {
                touchStartPosition = theTouch.position;
            }
            else if (theTouch.phase == TouchPhase.Ended) {
                touchEndPosition = theTouch.position;

                float x = touchEndPosition.x - touchStartPosition.x;
                float y = touchEndPosition.y - touchStartPosition.y;

                if ( Mathf.Abs(x) == 0 && Mathf.Abs(y) == 0) {
                    Debug.Log("TAP");
                    playerControllerScript.jumping();
                }
                else {
                    if (y > 0) {
                        Debug.Log("Up");
                        playerControllerScript.jumping(); 
                    }
                    else {
                        Debug.Log("Down");
                        playerControllerScript.slidingFunc();
                    }    
                }
            }
        }
    }
}