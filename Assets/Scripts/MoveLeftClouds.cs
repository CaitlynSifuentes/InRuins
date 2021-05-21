using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftClouds : MonoBehaviour
{
    // Variables
    public float scrollSpeed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Makes the obstacles move left based on scroll speed
        transform.Translate(Vector2.left * Time.deltaTime * scrollSpeed);

        // destroys the object after it is out of view
        if (transform.position.x < -16 && gameObject.CompareTag("Obstacle")) {
            Destroy(gameObject);
        } // end if
    }
}