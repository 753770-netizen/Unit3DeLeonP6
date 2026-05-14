using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackgroundX : MonoBehaviour
{
    public float speed = 10f; // Controls how fast the background moves left
    private Vector3 startPos;
    private float repeatWidth;
    private PlayerControllerX playerControllerScript; // Reference to check gameOver

    private void Start()
    {
        startPos = transform.position;

        // Fixed: Changed .size.y to .size.x for horizontal background repeating
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;

        // Find the player object and grab its controller script
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    private void Update()
    {
        // Only move the background if the game is NOT over
        if (!playerControllerScript.gameOver)
        {
            // Move the background to the left over time
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        // If background moves left past its repeat width, snap it back to start position
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}