using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    // Variables
    private Vector2 startPos;
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        // setting variables
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider2D>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth) {
            transform.position = startPos;
        }
    }
}
